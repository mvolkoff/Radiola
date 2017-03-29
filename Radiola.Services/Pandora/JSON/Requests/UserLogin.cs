using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    sealed internal class UserLogin
    {
        public string loginType = "user";
        public string username { get; }
        public string password { get; }
        public string partnerAuthToken { get; }
        public bool returnGenreStations { get; }
        public bool returnCapped { get; }
        public bool includePandoraOneInfo { get; }
        public bool includeDemographics { get; }
        public bool includeAdAttributes { get; }
        public bool returnStationList { get; }
        public bool includeStationArtUrl { get; }
        public bool includeStationSeeds { get; }
        public bool includeShuffleInsteadOfQuickMix { get; }
        public string stationArtSize { get; }
        public bool returnCollectTrackLifetimeStats { get; }
        public bool returnIsSubscriber { get; }
        public bool xplatformAdCapable { get; }
        public bool complimentarySponsorSupported { get; }
        public bool includeSubscriptionExpiration { get; }
        public bool returnHasUsedTrial { get; }
        public bool returnUserstate { get; }
        public bool includeAccountMessage { get; }
        public bool includeUserWebname { get; }
        public bool includeListeningHours { get; }
        public bool includeFacebook { get; }
        public bool includeTwitter { get; }
        public bool includeDailySkipLimit { get; }
        public bool includeSkipDelay { get; }
        public bool includeGoogleplay { get; }
        public bool includeShowUserRecommendations { get; }
        public bool includeAdvertiserAttributes { get; }
        public long syncTime { get; }

        public UserLogin(
            string _username,
            string _password,
            string _partnerAuthToken,
            long _syncTime,
            bool _returnGenreStations = false,
            bool _returnCapped = false,
            bool _includePandoraOneInfo = false,
            bool _includeDemographics = false,
            bool _includeAdAttributes = false,
            bool _returnStationList = false,
            bool _includeStationArtUrl = false,
            bool _includeStationSeeds = false,
            bool _includeShuffleInsteadOfQuickMix = false,
            string _stationArtSize = "W130H130",
            bool _returnCollectTrackLifetimeStats = false,
            bool _returnIsSubscriber = false,
            bool _xplatformAdCapable = false,
            bool _complimentarySponsorSupported = false,
            bool _includeSubscriptionExpiration = false,
            bool _returnHasUsedTrial = false,
            bool _returnUserstate = false,
            bool _includeAccountMessage = false,
            bool _includeUserWebname = false,
            bool _includeListeningHours = false,
            bool _includeFacebook = false,
            bool _includeTwitter = false,
            bool _includeDailySkipLimit = false,
            bool _includeSkipDelay = false,
            bool _includeGoogleplay = false,
            bool _includeShowUserRecommendations = false,
            bool _includeAdvertiserAttributes = false)
        {
            if (string.IsNullOrEmpty(_username) || string.IsNullOrWhiteSpace(_username))
                throw new ArgumentException("Username argument cannot be null, whitespace or empty!");

            if (string.IsNullOrEmpty(_password) || string.IsNullOrWhiteSpace(_password))
                throw new ArgumentException("Password argument cannot be null, whitespace or empty!");

            if (string.IsNullOrEmpty(_partnerAuthToken) || string.IsNullOrWhiteSpace(_partnerAuthToken))
                throw new ArgumentException("PartnerAuthToken argument cannot be null, whitespace or empty!");

            username = _username;
            password = _password;
            partnerAuthToken = _partnerAuthToken;
            syncTime = _syncTime;
            returnGenreStations = _returnGenreStations;
            returnCapped = _returnCapped;
            includePandoraOneInfo = _includePandoraOneInfo;
            includeDemographics = _includeDemographics;
            includeAdAttributes = _includeAdAttributes;
            returnStationList = _returnStationList;
            includeStationArtUrl = _includeStationArtUrl;
            includeStationSeeds = _includeStationSeeds;
            includeShuffleInsteadOfQuickMix = _includeShuffleInsteadOfQuickMix;
            stationArtSize = _stationArtSize;
            returnCollectTrackLifetimeStats = _returnCollectTrackLifetimeStats;
            returnIsSubscriber = _returnIsSubscriber;
            xplatformAdCapable = _xplatformAdCapable;
            complimentarySponsorSupported = _complimentarySponsorSupported;
            includeSubscriptionExpiration = _includeSubscriptionExpiration;
            returnHasUsedTrial = _returnHasUsedTrial;
            returnUserstate = _returnUserstate;
            includeAccountMessage = _includeAccountMessage;
            includeUserWebname = _includeUserWebname;
            includeListeningHours = _includeListeningHours;
            includeFacebook = _includeFacebook;
            includeTwitter = _includeTwitter;
            includeDailySkipLimit = _includeDailySkipLimit;
            includeSkipDelay = _includeSkipDelay;
            includeGoogleplay = _includeGoogleplay;
            includeShowUserRecommendations = _includeShowUserRecommendations;
            includeAdvertiserAttributes = _includeAdvertiserAttributes;
        }
    }
}
