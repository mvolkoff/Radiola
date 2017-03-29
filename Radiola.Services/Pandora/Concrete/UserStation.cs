using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.Common;
using Radiola.Services.Pandora.Factories;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    public class UserStation : IUserStation
    {
        #region Properties
        internal RequiredInformation RequiredInfo { get; private set; }

        public bool AllowAddMusic { get; private set; }

        public bool AllowDelete { get; private set; }

        public bool AllowEditDescription { get; private set; }

        public bool AllowRename { get; private set; }

        public string ArtUrl { get; private set; }

        public bool IsGenreStation { get; private set; }

        public bool IsQuickMix { get; private set; }

        public bool IsShared { get; private set; }

        public bool RequiresCleanAds { get; private set; }

        public string StationDetailUrl { get; private set; }

        public string StationId { get; private set; }

        public string StationName { get; private set; }

        public string StationSharingUrl { get; private set; }

        public string StationToken { get; private set; }

        public bool SuppressVideoAds { get; private set; }

        public DateTime DateCreated { get; private set; }

        public IStationFeedback Feedback { get; private set; }

        public IEnumerable<string> Genre { get; private set; }

        public IStationMusic Music { get; private set; }
        #endregion

        internal UserStation(RequiredInformation requiredInfo, JToken stationData)
        {
            RequiredInfo = requiredInfo;

            AllowAddMusic = stationData.Value<bool?>("allowAddMusic") ?? false;
            AllowDelete = stationData.Value<bool?>("allowDelete") ?? false;
            AllowEditDescription = stationData.Value<bool?>("allowEditDescription") ?? false;
            AllowRename = stationData.Value<bool?>("allowRename") ?? false;
            ArtUrl = stationData.Value<string>("artUrl") ?? string.Empty;
            IsGenreStation = stationData.Value<bool?>("isGenreStation") ?? false;
            IsQuickMix = stationData.Value<bool?>("isQuickMix") ?? false;
            IsShared = stationData.Value<bool?>("isShared") ?? false;
            RequiresCleanAds = stationData.Value<bool?>("requiresCleanAds") ?? false;
            StationDetailUrl = stationData.Value<string>("stationDetailUrl") ?? string.Empty;
            StationId = stationData.Value<string>("stationId") ?? string.Empty;
            StationName = stationData.Value<string>("stationName") ?? string.Empty;
            StationSharingUrl = stationData.Value<string>("stationSharingUrl") ?? string.Empty;
            StationToken = stationData.Value<string>("stationToken") ?? string.Empty;
            SuppressVideoAds = stationData.Value<bool?>("suppressVideoAds") ?? false;

            var dateCreated = stationData["dateCreated"];
            if (dateCreated != null)
            {
                DateCreated = Time.FromJavaTimeStamp(dateCreated.Value<double?>("time") ?? 0);
            }

            var feedbackData = stationData["feedback"];
            if (feedbackData != null)
            {
                Feedback = StationFactory.GetStationFeedback(RequiredInfo, feedbackData);
            }

            var genreData = stationData["genre"];
            if (genreData != null)
            {
                Genre = from genre in genreData select genre.ToString();
            }

            var musicData = stationData["music"];
            if (musicData != null)
            {
                Music = StationFactory.GetStationMusicInfo(musicData);
            }
        }
    }
}
