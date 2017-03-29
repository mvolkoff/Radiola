using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Radiola.Services.Pandora;
using Radiola.UI.Services.Navigation;
using Radiola.UI.Styling.Icons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.UI.ViewModels.StreamingServices
{
    public class PandoraStationDetailsViewModel : ViewModelBase, INavigable
    {
        private bool _canFilterThumbsUp = false;
        private bool _canFilterThumbsDown = true;

        private INavigationServiceEx _navigationService;
        private IPandoraService _pandoraService;
        private IStationFeedback _feedback;

        private string _stationToken;
        public string StationToken
        {
            get { return _stationToken; }
            set { Set(ref _stationToken, value); }
        }

        private string _header = "StationName";
        public string Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }

        private string _artUrl;
        public string ArtUrl
        {
            get { return _artUrl; }
            set { Set(ref _artUrl, value); }
        }

        private string _dateCreated;
        public string DateCreated
        {
            get { return _dateCreated; }
            set { Set(ref _dateCreated, value); }
        }

        private int _totalThumbsUp;
        public int TotalThumbsUp
        {
            get { return _totalThumbsUp; }
            set { Set(ref _totalThumbsUp, value); }
        }

        private int _totalThumbsDown;
        public int TotalThumbsDown
        {
            get { return _totalThumbsDown; }
            set { Set(ref _totalThumbsDown, value); }
        }

        private ObservableCollection<IArtistInfo> _stationArtists;
        public ObservableCollection<IArtistInfo> StationArtists
        {
            get { return _stationArtists; }
            set { Set (ref _stationArtists, value); }
        }

        private ObservableCollection<ITrack> _thumbsHistory;
        public ObservableCollection<ITrack> ThumbsHistory
        {
            get { return _thumbsHistory; }
            set { Set(ref _thumbsHistory, value); }
        }

        public RelayCommand FilterThumbsUpCommand { get; }

        public RelayCommand FilterThumbsDownCommand { get; }

        public RelayCommand<string> PlayStationCommand { get; }

        public PandoraStationDetailsViewModel(INavigationServiceEx navigationService, IPandoraService pandoraService)
        {
            _navigationService = navigationService;
            _pandoraService = pandoraService;

            FilterThumbsUpCommand = new RelayCommand(FilterThumbsUp, () => { return _canFilterThumbsUp; });
            FilterThumbsDownCommand = new RelayCommand(FilterThumbsDown, () => { return _canFilterThumbsDown; });

            PlayStationCommand = new RelayCommand<string>((token) => { _navigationService.NavigateTo(PageKeys.PANDORA_PLAYBACK, token); });
        }

        public async void Activate(object parameter)
        {
            var station = await _pandoraService.RetrieveExtendedUserStationInfoAsync(parameter.ToString());

            StationToken = station.StationToken;
            Header = station.StationName;
            ArtUrl = station.ArtUrl;
            DateCreated = station.DateCreated.ToString();
            TotalThumbsUp = station.Feedback.TotalThumbsUp;
            TotalThumbsDown = station.Feedback.TotalThumbsDown;

            StationArtists = new ObservableCollection<IArtistInfo>(from artist in station.Music.Artists select artist);

            _feedback = station.Feedback;
            ThumbsHistory = new ObservableCollection<ITrack>(from thumbsUp in _feedback.ThumbsUp select thumbsUp);
        }

        public void Deactivate(object parameter)
        {
            //throw new NotImplementedException();
        }

        #region Helpers
        private void FilterThumbsUp()
        {
            ThumbsHistory = new ObservableCollection<ITrack>(from thumbsUp in _feedback.ThumbsUp select thumbsUp);

            _canFilterThumbsUp = false;
            _canFilterThumbsDown = true;

            FilterThumbsUpCommand.RaiseCanExecuteChanged();
            FilterThumbsDownCommand.RaiseCanExecuteChanged();
        }

        private void FilterThumbsDown()
        {
            ThumbsHistory = new ObservableCollection<ITrack>(from thumbsDown in _feedback.ThumbsDown select thumbsDown);

            _canFilterThumbsUp = true;
            _canFilterThumbsDown = false;

            FilterThumbsUpCommand.RaiseCanExecuteChanged();
            FilterThumbsDownCommand.RaiseCanExecuteChanged();
        }
        #endregion
    }
}
