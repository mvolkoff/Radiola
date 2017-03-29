using GalaSoft.MvvmLight.Messaging;
using Radiola.Services.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace Radiola.Services.Playback.Concrete
{
    public class PlaybackService : IPlaybackService, IDisposable
    {
        #region Fields
        private MediaPlayer _player;
        #endregion

        #region Properties
        private bool _isMuted;
        public bool IsMuted
        {
            get { return _isMuted; }
            set
            {
                if (_player != null)
                    _player.IsMuted = value;

                _isMuted = value;
            }
        }

        public double Volume
        {
            get { return _player?.Volume ?? 0; }
            set
            {
                if (_player != null)
                    _player.Volume = value;
            }
        }

        public TimeSpan Duration
        {
            get { return _player?.PlaybackSession?.NaturalDuration ?? new TimeSpan(0, 0, 0); }
        }

        public MediaPlaybackState PlaybackState
        {
            get { return _player?.PlaybackSession?.PlaybackState ?? MediaPlaybackState.None; }
        }
        #endregion

        #region Ctor
        public PlaybackService()
        {
            _player = new MediaPlayer();
            _player.MediaEnded += (sender, args) =>
            {
                Messenger.Default.Send(new MediaEndedMessage());
            };
            _player.PlaybackSession.PositionChanged += (sender, args) =>
            {
                Messenger.Default.Send(sender);
            };
        }
        #endregion

        #region Metods
        public void SetMediaSource(IMediaPlaybackSource source)
        {
            if (_player.PlaybackSession.PlaybackState == MediaPlaybackState.Playing)
                _player.Pause();

            _player.Source = source;
        }

        public void Play()
        {
            _player.Play();
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void SkipNext()
        {
            var playbackList = _player.Source as MediaPlaybackList;
            if (playbackList == null)
                return;

            playbackList.MoveNext();
        }

        public void IncreaseVolume(double value)
        {
            if (_player.Volume < 1.0)
                _player.Volume += value;
        }

        public void DecreaseVolume(double value)
        {
            if (_player.Volume > 0.0)
                _player.Volume -= value;
        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                _player.Dispose();
                _player = null;

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~PlaybackService() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
