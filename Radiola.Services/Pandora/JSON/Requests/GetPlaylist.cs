using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class GetPlaylist : BaseRequest
    {
        public string stationToken { get; }
        public string additionalAudioUrl { get; }
        public bool stationIsStarting { get; }
        public bool includeTrackLength { get; }
        public bool includeAudioToken { get; }
        public bool xplatformAdCapable { get; }
        public bool includeAudioReceiptUrl { get; }
        public bool includeBackstageAdUrl { get; }
        public bool includeSharingAdUrl { get; }
        public bool includeSocialAdUrl { get; }
        public bool includeCompetitiveSepIndicator { get; }
        public bool includeCompletePlaylist { get; }
        public bool includeTrackOptions { get; }
        public bool audioAdPodCapable { get; }

        public GetPlaylist(
            string _userAuthToken,
            long _syncTime,
            string _stationToken,
            string _additionalAudioUrl = "",
            bool _stationIsStarting = false,
            bool _includeTrackLength = false,
            bool _includeAudioToken = false,
            bool _xplatformAdCapable = false,
            bool _includeAudioReceiptUrl = false,
            bool _includeBackstageAdUrl = false,
            bool _includeSharingAdUrl = false,
            bool _includeSocialAdUrl = false,
            bool _includeCompetitiveSepIndicator = false,
            bool _includeCompletePlaylist = false,
            bool _includeTrackOptions = false,
            bool _audioAdPodCapable = false) : base(_userAuthToken, _syncTime)
        {
            stationToken = _stationToken;
            additionalAudioUrl = _additionalAudioUrl;
            stationIsStarting = _stationIsStarting;
            includeTrackLength = _includeTrackLength;
            includeAudioToken = _includeAudioToken;
            xplatformAdCapable = _xplatformAdCapable;
            includeAudioReceiptUrl = _includeAudioReceiptUrl;
            includeBackstageAdUrl = _includeBackstageAdUrl;
            includeSharingAdUrl = _includeSharingAdUrl;
            includeSocialAdUrl = _includeSocialAdUrl;
            includeCompetitiveSepIndicator = _includeCompetitiveSepIndicator;
            includeCompletePlaylist = _includeCompletePlaylist;
            includeTrackOptions = _includeTrackOptions;
            audioAdPodCapable = _audioAdPodCapable;
        }
    }
}
