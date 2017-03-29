using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using Radiola.Services.Common.Messages;
using Radiola.Services.Pandora;
using Radiola.Services.Pandora.Extensions;
using Radiola.Services.Playback;
using Radiola.UI.Services.Navigation;
using Radiola.UI.Styling.Icons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;

namespace Radiola.UI.ViewModels.StreamingServices
{
    public class PandoraPlaybackViewModel : ViewModelBase, INavigable
    {
        private INavigationServiceEx _navigationServise;
        private IPandoraService _pandoraService;
        private IPlaybackService _playbackService;
        private Queue<ITrack> _trackQueue;

        private string _stationToken;
        public string StationToken
        {
            get { return _stationToken; }
            set { Set(ref _stationToken, value); }
        }

        private string _playPauseIcon = Icon.GetIcon("PlayIcon");
        public string PlayPauseIcon
        {
            get { return _playPauseIcon; }
            set { Set(ref _playPauseIcon, value); }
        }

        private string _muteIcon = Icon.GetIcon("UnMutedIcon");
        public string MuteIcon
        {
            get { return _muteIcon; }
            set { Set(ref _muteIcon, value); }
        }

        private ObservableCollection<TrackItem> _trackList = new ObservableCollection<TrackItem>();
        public ObservableCollection<TrackItem> TrackList
        {
            get { return _trackList; }
            set { Set(ref _trackList, value); }
        }

        private TrackItem _selectedTrack;
        public TrackItem SelectedTrack
        {
            get { return _selectedTrack; }
            set { Set(ref _selectedTrack, value); }
        }

        private int _selectedTrackIndex;
        public int SelectedTrackIndex
        {
            get { return _selectedTrackIndex; }
            set { Set(ref _selectedTrackIndex, value); }
        }

        private double _volume;
        public double Volume
        {
            get { return _volume; }
            set
            {
                Set(ref _volume, value);
                if (_playbackService != null)
                    _playbackService.Volume = value;
            }
        }

        private double _percentagePosition;
        public double PercentagePosition
        {
            get { return _percentagePosition; }
            set { Set(ref _percentagePosition, value); }
        }

        private string _position;
        public string Position
        {
            get { return _position; }
            set { Set(ref _position, value); }
        }

        private string _duration;
        public string Duration
        {
            get { return _duration; }
            set { Set(ref _duration, value); }
        }

        public RelayCommand TogglePlayPauseCommand { get; private set; }
        public RelayCommand SkipNextCommand { get; private set; }
        public RelayCommand ThumbUpCommand { get; private set; }
        public RelayCommand ThumbDownCommand { get; private set; }
        public RelayCommand IncreaseVolumeCommand { get; private set; }
        public RelayCommand DecreaseVolumeCommand { get; private set; }
        public RelayCommand<bool> ToggleMuteCommand { get; private set; }

        public PandoraPlaybackViewModel(INavigationServiceEx navigationServise, IPandoraService pandoraService, IPlaybackService playbackService)
        {
            _navigationServise = navigationServise;
            _pandoraService = pandoraService;
            _playbackService = playbackService;

            TogglePlayPauseCommand = new RelayCommand(TogglePlayPause);
            SkipNextCommand = new RelayCommand(SkipNext, CanSkipNext);
            ThumbUpCommand = new RelayCommand(() => { });
            ThumbDownCommand = new RelayCommand(() => { });
            IncreaseVolumeCommand = new RelayCommand(IncreaseVolume, CanIncreaseVolume);
            DecreaseVolumeCommand = new RelayCommand(DecreaseVolume, CanDecreaseVolume);
            ToggleMuteCommand = new RelayCommand<bool>(ToggleMute);

            Messenger.Default.Register<MediaEndedMessage>(this, (message) => { SkipNext(); });
            Messenger.Default.Register<MediaPlaybackSession>(this, (session) =>
            {
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    Position = session.Position.ToString(@"hh\:mm\:ss");
                    Duration = session.NaturalDuration.ToString(@"hh\:mm\:ss");
                    PercentagePosition = (session.Position.TotalSeconds / session.NaturalDuration.TotalSeconds) * 100;
                });
            });
        }

        public async void Activate(object parameter)
        {
            if (StationToken?.Equals((string)parameter) ?? false) return;

            StationToken = (string)parameter;
            _trackQueue = new Queue<ITrack>(await _pandoraService.RetrievePlaylistAsync(StationToken));
            SkipNext();
            Volume = 0.0;
        }

        public void Deactivate(object parameter)
        {
            //throw new NotImplementedException();
        }

        #region Helpers
        private void TogglePlayPause()
        {
            switch (_playbackService.PlaybackState)
            {
                case MediaPlaybackState.Playing:
                    {
                        _playbackService.Pause();
                        PlayPauseIcon = Icon.GetIcon("PlayIcon");
                    }
                    break;
                case MediaPlaybackState.Paused:
                    {
                        _playbackService.Play();
                        PlayPauseIcon = Icon.GetIcon("PauseIcon");
                    }
                    break;
            }
        }

        private void SkipNext()
        {
            DispatcherHelper.CheckBeginInvokeOnUI(async () =>
            {
                if (_trackQueue.Count != 0)
                {
                    var track = _trackQueue.Dequeue();
                    TrackList.Add(new TrackItem
                    {
                        TrackToken = track.TrackToken,
                        AlbumArtUrl = track.AlbumArtUrl,
                        SongName = track.SongName,
                        ArtistName = track.ArtistName,
                        AlbumName = track.AlbumName,
                        IsPositive = track.IsPositive,
                        ThumbUpCommand = new RelayCommand(() => { }),
                        ThumbDownCommand = new RelayCommand(() => { })
                    });

                    SelectedTrack = TrackList.LastOrDefault();
                    SelectedTrackIndex = TrackList.IndexOf(SelectedTrack);

                    _playbackService.SetMediaSource(track.ToMediaPlaybackItem());
                    _playbackService.Play();
                }
                else
                {
                    _trackQueue = new Queue<ITrack>(await _pandoraService.RetrievePlaylistAsync(StationToken));
                    SkipNext();
                }
            });
        }
        private bool CanSkipNext()
        {
            return true;
        }

        private void IncreaseVolume()
        {
            _playbackService.IncreaseVolume(0.02);
        }
        private bool CanIncreaseVolume()
        {
            return true;
        }

        private void DecreaseVolume()
        {
            _playbackService.DecreaseVolume(0.02);
        }
        private bool CanDecreaseVolume()
        {
            return true;
        }

        private void ToggleMute(bool value)
        {
            _playbackService.IsMuted = value;
            MuteIcon = value ? Icon.GetIcon("MutedIcon") : Icon.GetIcon("UnMutedIcon");
        }
        #endregion
    }
}
