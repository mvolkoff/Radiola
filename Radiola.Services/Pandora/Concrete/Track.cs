using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.Common;
using Radiola.Services.Pandora.Factories;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace Radiola.Services.Pandora.Concrete
{
    internal class Track : ITrack
    {
        #region Properties
        internal RequiredInformation RequiredInfo { get; private set; }

        public string AlbumArtUrl { get; private set; }

        public string AlbumIdentity { get; private set; }

        public string AlbumName { get; private set; }

        public bool AllowFeedback { get; private set; }

        public string ArtistName { get; private set; }

        public IDictionary<QualityNames, IAudio> AudioUrlMap { get; private set; }

        public string CategoryDescriptor { get; private set; }

        public DateTime DateCreated { get; private set; }

        public string FeedbackId { get; private set; }

        public bool IsFeatured { get; private set; }

        public bool IsPositive { get; private set; }

        public string MusicId { get; private set; }

        public string MusicToken { get; private set; }

        public string PandoraId { get; private set; }

        public string PandoraType { get; private set; }

        public string ProgramDescriptor { get; private set; }

        public string SongIdentity { get; private set; }

        public string SongName { get; private set; }

        public int SongRating { get; private set; }

        public string StationId { get; private set; }

        public double TrackGain { get; private set; }

        public string TrackToken { get; private set; }

        public string TrackType { get; private set; }
        #endregion


        public Track(RequiredInformation requiredInfo, JToken trackData)
        {
            RequiredInfo = requiredInfo;

            AlbumArtUrl = trackData.Value<string>("albumArtUrl") ?? string.Empty;
            AlbumIdentity = trackData.Value<string>("albumIdentity") ?? string.Empty;
            AlbumName = trackData.Value<string>("albumName") ?? string.Empty;
            AllowFeedback = trackData.Value<bool?>("allowFeedback") ?? false;
            ArtistName = trackData.Value<string>("artistName") ?? string.Empty;

            var audioUrlMap = trackData["audioUrlMap"];
            if (audioUrlMap != null)
            {
                AudioUrlMap = TrackFactory.CreateAudioMap(audioUrlMap);
            }

            CategoryDescriptor = trackData.Value<string>("categoryDescriptor") ?? string.Empty;

            var dateCreated = trackData["dateCreated"];
            if (dateCreated != null)
            {
                DateCreated = Time.FromJavaTimeStamp(dateCreated.Value<double?>("time") ?? 0);
            }

            FeedbackId = trackData.Value<string>("feedbackId") ?? string.Empty;
            IsFeatured = trackData.Value<bool?>("isFeatured") ?? false;
            IsPositive = trackData.Value<bool?>("isPositive") ?? false;
            MusicId = trackData.Value<string>("musicId") ?? string.Empty;
            MusicToken = trackData.Value<string>("musicToken") ?? string.Empty;
            PandoraId = trackData.Value<string>("pandoraId") ?? string.Empty;
            PandoraType = trackData.Value<string>("pandoraType") ?? string.Empty;
            ProgramDescriptor = trackData.Value<string>("programDescriptor") ?? string.Empty;
            SongIdentity = trackData.Value<string>("songIdentity") ?? string.Empty;
            SongName = trackData.Value<string>("songName") ?? string.Empty;
            SongRating = trackData.Value<int?>("songRating") ?? 0;
            StationId = trackData.Value<string>("stationId") ?? string.Empty;
            TrackGain = double.Parse(trackData.Value<string>("trackGain") ?? "0", CultureInfo.InvariantCulture);
            TrackToken = trackData.Value<string>("trackToken") ?? string.Empty;
            TrackType = trackData.Value<string>("trackType") ?? string.Empty;
        }
    }
}
