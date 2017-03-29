using Newtonsoft.Json;
using Radiola.Services.Pandora.Common;
using Radiola.Services.Pandora.Exceptions;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Factories
{
    internal class RequestFactory
    {
        public static string GetRequest(string methodName, RequiredInformation requiredInfo, params KeyValuePair<string, object>[] additionalInfo)
        {
            switch (methodName)
            {
                #region Documented Methods
                case MethodNames.ad_getAdMetadata:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.ad_registerAd:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.auth_partnerLogin:
                    {
                        return JsonConvert.SerializeObject(new PartnerLogin());
                    }
                case MethodNames.auth_userLogin:
                    {
                        string username = string.Empty;
                        string password = string.Empty;
                        
                        if (requiredInfo == null)
                            throw new ArgumentNullException();

                        var userNames = from userName
                                        in additionalInfo
                                        where userName.Key.Equals("username")
                                        select userName;
                        if (userNames.Count() == 0)
                            throw new ArgumentException("Parameter username not found");
                        else
                            username = userNames.FirstOrDefault().Value.ToString();

                        var passwords = from pass
                                        in additionalInfo
                                        where pass.Key.Equals("password")
                                        select pass;
                        if (passwords.Count() == 0)
                            throw new ArgumentException("Parameter password not found");
                        else
                            password = passwords.FirstOrDefault().Value.ToString();
                        
                        return JsonConvert.SerializeObject(new UserLogin(username, password, requiredInfo.AuthToken, requiredInfo.SyncTime));
                    }
                case MethodNames.bookmark_addArtistBookmark:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.bookmark_addSongBookmark:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.music_search:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_addFeedback:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_addMusic:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_createStation:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_deleteFeedback:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_deleteMusic:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_deleteStation:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_getGenreStationsChecksum:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_getGenreStations:
                    {
                        if (requiredInfo == null)
                            throw new ArgumentNullException();

                        return JsonConvert.SerializeObject(new GetGenreStations(requiredInfo.AuthToken, requiredInfo.SyncTime));
                    }
                case MethodNames.station_getPlaylist:
                    {
                        string stationToken = string.Empty;

                        if (requiredInfo == null)
                            throw new ArgumentNullException();

                        var tokens = from token
                                     in additionalInfo
                                     where token.Key.Equals("stationToken")
                                     select token;
                        if (tokens.Count() == 0)
                            throw new ArgumentException("Parameter stationToken not found");
                        else
                            stationToken = tokens.FirstOrDefault().Value.ToString();

                        return JsonConvert.SerializeObject(new GetPlaylist(requiredInfo.AuthToken, requiredInfo.SyncTime, stationToken));
                    }
                case MethodNames.station_getStation:
                    {
                        string stationToken = string.Empty;

                        if (requiredInfo == null)
                            throw new ArgumentNullException();

                        var tokens = from token
                                     in additionalInfo
                                     where token.Key.Equals("stationToken")
                                     select token;
                        if (tokens.Count() == 0)
                            throw new ArgumentException("Parameter stationToken not found");
                        else
                            stationToken = tokens.FirstOrDefault().Value.ToString();

                        return JsonConvert.SerializeObject(new GetExtendedStationInfo(requiredInfo.AuthToken, requiredInfo.SyncTime, stationToken));
                    }
                case MethodNames.station_renameStation:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_shareStation:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.station_transformSharedStation:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.test_checkLicensing:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.track_explainTrack:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_canSubscribe:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_changeSettings:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_createUser:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_emailPassword:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_getBookmarks:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_getSettings:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_getStationListChecksum:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_getStationList:
                    {
                        if (requiredInfo == null)
                            throw new ArgumentNullException();

                        return JsonConvert.SerializeObject(new GetUserStations(requiredInfo.AuthToken, requiredInfo.SyncTime));
                    }
                case MethodNames.user_getUsageInfo:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_setQuickMix:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_sleepSong:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_startComplimentaryTrial:
                    {
                        throw new NotImplementedException();
                    }
                case MethodNames.user_validateUsername:
                    {
                        throw new NotImplementedException();
                    }
                #endregion

                #region NonDocumented Methods
                //case MethodNames.accessory_accessoryConnect:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.auth_getAdMetadata:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.auth_partnerAdminLogin:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.bookmark_deleteArtistBookmark:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.bookmark_deleteSongBookmark:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.device_associateDeviceForCasting:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.device_createDevice:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.device_disassociateCastingDevice:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.device_disassociateDevice:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.music_getSearchRecommendations:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.music_getTrack:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.music_publishSongShare:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.music_shareMusic:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.station_publishStationShare:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.test_echo:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.track_trackStarted:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_accountMessageDismissed:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_acknowledgeSubscriptionExpiration:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_associateDevice:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_authorizeFacebook:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_disconnectFacebook:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_facebookAuthFailed:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_getFacebookInfo:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_purchaseAmazonPayToPlay:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_purchaseAmazonSubscription:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_purchaseGooglePayToPlay:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_purchaseGoogleSubscription:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_purchaseItunesSubscription:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_setAwareOfProfile:
                //    {
                //        throw new NotImplementedException();
                //    }
                //case MethodNames.user_setExplicitContentFilter:
                //    {
                //        throw new NotImplementedException();
                //    }
                #endregion
                default: throw new PandoraException("Unsupported method name! MethodName: " + methodName);
            }
        }
    }
}
