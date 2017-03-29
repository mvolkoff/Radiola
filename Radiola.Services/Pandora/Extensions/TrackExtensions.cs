using Radiola.Services.Pandora.Common;
using System;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace Radiola.Services.Pandora.Extensions
{
    public static class TrackExtensions
    {
        public static IMediaPlaybackSource ToMediaPlaybackItem(this ITrack track)
        {
            IMediaPlaybackSource result = null;

            if (track == null)
                throw new ArgumentNullException();

            // Create the media source from the Uri
            var source = MediaSource.CreateFromUri(new Uri(track.AudioUrlMap[QualityNames.HighQuality].AudioUrl));

            // Create a configurable playback item backed by the media source
            result = new MediaPlaybackItem(source);

            return result;
        }
    }
}
