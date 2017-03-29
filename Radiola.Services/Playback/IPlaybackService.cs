using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace Radiola.Services.Playback
{
    public interface IPlaybackService
    {
        MediaPlaybackState PlaybackState { get; }
        bool IsMuted { get; set; }
        double Volume { get; set; }
        TimeSpan Duration { get; }

        void Pause();
        void Play();
        void SetMediaSource(IMediaPlaybackSource mediaPlaybackSource);
        void SkipNext();
        void IncreaseVolume(double value);
        void DecreaseVolume(double value);
    }
}
