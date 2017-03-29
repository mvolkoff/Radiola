using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class GetUserStations : BaseRequest
    {
        public bool includeStationArtUrl { get; }
        public string stationArtSize { get; }
        public bool includeAdAttributes { get; }
        public bool includeStationSeeds { get; }
        public bool includeShuffleInsteadOfQuickMix { get; }
        public bool includeRecommendations { get; }
        public bool includeExplanations { get; }

        public GetUserStations(string _userAuthToken,
            long _syncTime,
            bool _includeStationArtUrl = true,
            string _stationArtSize = "W1920H1920",
            bool _includeAdAttributes = false,
            bool _includeStationSeeds = false,
            bool _includeShuffleInsteadOfQuickMix = false,
            bool _includeRecommendations = false,
            bool _includeExplanations = false) : base(_userAuthToken, _syncTime)
        {
            includeStationArtUrl = _includeStationArtUrl;
            stationArtSize = _stationArtSize;
            includeAdAttributes = _includeAdAttributes;
            includeStationSeeds = _includeStationSeeds;
            includeShuffleInsteadOfQuickMix = _includeShuffleInsteadOfQuickMix;
            includeRecommendations = _includeRecommendations;
            includeExplanations = _includeExplanations;
        }
    }
}
