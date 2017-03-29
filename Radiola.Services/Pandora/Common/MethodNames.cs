using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Common
{
    internal static class MethodNames
    {
        #region Documented Methods
        public const string ad_getAdMetadata = "ad.getAdMetadata";
        public const string ad_registerAd = "ad.registerAd";
        public const string auth_partnerLogin = "auth.partnerLogin";
        public const string auth_userLogin = "auth.userLogin";
        public const string bookmark_addArtistBookmark = "bookmark.addArtistBookmark";
        public const string bookmark_addSongBookmark = "bookmark.addSongBookmark";
        public const string music_search = "music.search";
        public const string station_addFeedback = "station.addFeedback";
        public const string station_addMusic = "station.addMusic";
        public const string station_createStation = "station.createStation";
        public const string station_deleteFeedback = "station.deleteFeedback";
        public const string station_deleteMusic = "station.deleteMusic";
        public const string station_deleteStation = "station.deleteStation";
        public const string station_getGenreStationsChecksum = "station.getGenreStationsChecksum";
        public const string station_getGenreStations = "station.getGenreStations";
        public const string station_getPlaylist = "station.getPlaylist";
        public const string station_getStation = "station.getStation";
        public const string station_renameStation = "station.renameStation";
        public const string station_shareStation = "station.shareStation";
        public const string station_transformSharedStation = "station.transformSharedStation";
        public const string test_checkLicensing = "test.checkLicensing";
        public const string track_explainTrack = "track.explainTrack";
        public const string user_canSubscribe = "user.canSubscribe";
        public const string user_changeSettings = "user.changeSettings";
        public const string user_createUser = "user.createUser";
        public const string user_emailPassword = "user.emailPassword";
        public const string user_getBookmarks = "user.getBookmarks";
        public const string user_getSettings = "user.getSettings";
        public const string user_getStationListChecksum = "user.getStationListChecksum";
        public const string user_getStationList = "user.getStationList";
        public const string user_getUsageInfo = "user.getUsageInfo";
        public const string user_setQuickMix = "user.setQuickMix";
        public const string user_sleepSong = "user.sleepSong";
        public const string user_startComplimentaryTrial = "user.startComplimentaryTrial";
        public const string user_validateUsername = "user.validateUsername";
        #endregion

        #region NonDocumented Methods
        private const string accessory_accessoryConnect = "accessory.accessoryConnect";
        private const string auth_getAdMetadata = "auth.getAdMetadata";
        private const string auth_partnerAdminLogin = "auth.partnerAdminLogin";
        private const string bookmark_deleteArtistBookmark = "bookmark.deleteArtistBookmark";
        private const string bookmark_deleteSongBookmark = "bookmark.deleteSongBookmark";
        private const string device_associateDeviceForCasting = "device.associateDeviceForCasting";
        private const string device_createDevice = "device.createDevice";
        private const string device_disassociateCastingDevice = "device.disassociateCastingDevice";
        private const string device_disassociateDevice = "device.disassociateDevice";
        private const string music_getSearchRecommendations = "music.getSearchRecommendations";
        private const string music_getTrack = "music.getTrack";
        private const string music_publishSongShare = "music.publishSongShare";
        private const string music_shareMusic = "music.shareMusic";
        private const string station_publishStationShare = "station.publishStationShare";
        private const string test_echo = "test.echo";
        private const string track_trackStarted = "track.trackStarted";
        private const string user_accountMessageDismissed = "user.accountMessageDismissed";
        private const string user_acknowledgeSubscriptionExpiration = "user.acknowledgeSubscriptionExpiration";
        private const string user_associateDevice = "user.associateDevice";
        private const string user_authorizeFacebook = "user.authorizeFacebook";
        private const string user_disconnectFacebook = "user.disconnectFacebook";
        private const string user_facebookAuthFailed = "user.facebookAuthFailed";
        private const string user_getFacebookInfo = "user.getFacebookInfo";
        private const string user_purchaseAmazonPayToPlay = "user.purchaseAmazonPayToPlay";
        private const string user_purchaseAmazonSubscription = "user.purchaseAmazonSubscription";
        private const string user_purchaseGooglePayToPlay = "user.purchaseGooglePayToPlay";
        private const string user_purchaseGoogleSubscription = "user.purchaseGoogleSubscription";
        private const string user_purchaseItunesSubscription = "user.purchaseItunesSubscription";
        private const string user_setAwareOfProfile = "user.setAwareOfProfile";
        private const string user_setExplicitContentFilter = "user.setExplicitContentFilter";
        #endregion
    }
}
