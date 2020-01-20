using GalaSoft.MvvmLight.Messaging;
using Radiola.Services.Pandora.Common;
using Radiola.Services.Pandora.Factories;
using Radiola.Services.Pandora.JSON;
using Radiola.Services.Pandora.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    public class PandoraService : IPandoraService
    {
        #region Fields
        private long _timeSynced;
        #endregion

        #region Properties
        private RequiredInformation _requiredInfo = new RequiredInformation();
        internal RequiredInformation RequiredInfo
        {
            get { return _requiredInfo; }
            set { _requiredInfo = value; }
        }

        public string UserStationsChecksum { get; private set; }
        public string GenreStationsChecksum { get; private set; }

        public List<IUserStation> UserStations { get; private set; }
        public List<IGenreCategory> GenreCategories { get; private set; }
        #endregion

        #region Methods
        public Task<bool> ConnectAsync(string username, string password)
        {
            return Task.Run(() => Connect(username, password));
        }

        public Task<List<IGenreCategory>> RetrieveGenreCategoriesAsync()
        {
            return Task.Run(() => RetrieveGenreCategories());
        }

        public Task<List<IUserStation>> RetrieveUserStationsAsync()
        {
            return Task.Run(() => RetrieveUserStations());
        }

        public Task<IUserStation> GetUserStationByIDAsync(string id)
        {
            return Task.Run(() => GetUserStationByID(id));
        }

        public Task<IUserStation> RetrieveExtendedUserStationInfoAsync(string stationToken)
        {
            return Task.Run(() => RetrieveExtendedUserStationInfo(stationToken));
        }

        public Task<IEnumerable<ITrack>> RetrievePlaylistAsync(string stationToken)
        {
            return Task.Run(() => RetrievePlaylist(stationToken));
        }

        public Task<string> GetUserStationsChecksumAsync()
        {
            return Task.Run(() => GetUserStationsChecksum());
        }

        public Task<ISearchResult> SearchAsync(string searchText)
        {
            return Task.Run(() => Search(searchText));
        }

        public Task CreateUserStationAsync(string musicToken)
        {
            return Task.Run(() => CreateUserStation(musicToken));
        }

        public Task CreateUserStationAsync(string trackToken, MusicType musicType)
        {
            return Task.Run(() => CreateUserStation(trackToken, musicType));
        }

        public Task AddMusicAsync(string stationToken, string musicToken)
        {
            return Task.Run(() => AddMusic(stationToken, musicToken));
        }

        public Task DeleteMusicAsync(string seedId)
        {
            return Task.Run(() => DeleteMusic(seedId));
        }

        public Task RenameStationAsync(string stationToken, string stationName)
        {
            return Task.Run(() => RenameStation(stationToken, stationName));
        }

        public Task DeleteStationAsync(string stationToken)
        {
            return Task.Run(() => DeleteStation(stationToken));
        }

        public Task DeleteFeedbackAsync(string feedbackId)
        {
            return Task.Run(() => DeleteFeedback(feedbackId));
        }

        public Task<string> GetGenreStationsChecksumAsync()
        {
            return Task.Run(() => GetGenreStationsChecksum());
        }

        public Task ShareStationAsync(string stationToken, string[] emails)
        {
            return Task.Run(() => ShareStation(stationToken, emails));
        }

        public Task TransformSharedStationAsync(string stationToken)
        {
            return Task.Run(() => TransformSharedStation(stationToken));
        }

        public Task ModifyQuickMixAsync(string[] quickMixStationIds)
        {
            return Task.Run(() => ModifyQuickMix(quickMixStationIds));
        }

        public Task RateTrackAsync(string stationToken, string trackToken, bool isPositive)
        {
            return Task.Run(() => RateTrack(stationToken, trackToken, isPositive));
        }

        public Task TiredOfThisTrackAsync(string trackToken)
        {
            return Task.Run(() => TiredOfThisTrack(trackToken));
        }

        public Task<IEnumerable<IExplanation>> ExplainTrackAsync(string trackToken)
        {
            return Task.Run(() => ExplainTrack(trackToken));
        }
        #endregion

        #region Helpers
        private bool Connect(string username, string password)
        {
            var result = false;

            var busyMessage = new AwaitableOperationMessage { Message = "Connecting...", IsRunning = true };
            Messenger.Default.Send(busyMessage);

            try
            {
                //PartnerID authorization
                var partnerLoginRequest = new JSONRequest(MethodNames.auth_partnerLogin, true, null);
                var res = new JSONResult(partnerLoginRequest.StringRequestAsync().Result);
                if (res.IsFault)
                {
                    busyMessage.IsRunning = false;
                    Messenger.Default.Send(busyMessage);

                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return false;
                }

                var data = res.Result;

                RequiredInfo.SyncTime = Cryptography.DecryptSyncTime(data["syncTime"].ToString());
                _timeSynced = Time.Unix();

                RequiredInfo.PartnerID = data["partnerId"].ToString();
                RequiredInfo.AuthToken = data["partnerAuthToken"].ToString();

                //UserAuthToken authorization
                var userAuthRequest = new JSONRequest(
                    MethodNames.auth_userLogin,
                    true,
                    RequiredInfo,
                    new KeyValuePair<string, object>("username", username),
                    new KeyValuePair<string, object>("password", password));
                res = null;

                res = new JSONResult(userAuthRequest.StringRequestAsync().Result);
                if (res.IsFault)
                {
                    busyMessage.IsRunning = false;
                    Messenger.Default.Send(busyMessage);

                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return false;
                }
                data = res.Result;

                RequiredInfo.AuthToken = data["userAuthToken"].ToString();
                RequiredInfo.UserID = data["userId"].ToString();

                // Retrieving station lists
                UserStations = RetrieveUserStations();
                GenreCategories = RetrieveGenreCategories();

                result = true;
            }
            catch (Exception ex)
            {
                busyMessage.IsRunning = false;
                Messenger.Default.Send(busyMessage);

                Messenger.Default.Send(new FaultMessage(ex.Message, ex));

                // TODO: Записать сообщение в лог
                return false;
            }

            busyMessage.IsRunning = false;
            Messenger.Default.Send(busyMessage);
            return result;
        }

        private List<IGenreCategory> RetrieveGenreCategories()
        {
            var result = new List<IGenreCategory>();

            try
            {
                var retrieveGenreStationsRequest = new JSONRequest(MethodNames.station_getGenreStations, false, RequiredInfo);
                var res = new JSONResult(retrieveGenreStationsRequest.StringRequestAsync().Result);

                if (res.IsFault)
                {
                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return null;
                }

                var data = res.Result;
                //GenreStationsChecksum = data["checksum"].ToString();
                foreach (var station in data["categories"])
                {
                    result.Add(StationFactory.CreateGenreCategory(RequiredInfo, station));
                }
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(new FaultMessage(ex.Message, ex));
                return null;
            }

            return result;
        }

        private List<IUserStation> RetrieveUserStations()
        {
            var result = new List<IUserStation>();

            try
            {
                var retrieveStationsRequest = new JSONRequest(MethodNames.user_getStationList, false, RequiredInfo);
                var res = new JSONResult(retrieveStationsRequest.StringRequestAsync().Result);

                if (res.IsFault)
                {
                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return null;
                }

                var data = res.Result;
                UserStationsChecksum = data["checksum"].ToString();
                foreach (var station in data["stations"])
                {
                    result.Add(StationFactory.CreateUserStation(RequiredInfo, station));
                }
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(new FaultMessage(ex.Message, ex));
                return null;
            }

            return result;
        }

        private IUserStation GetUserStationByID(string id)
        {
            return (from station
                    in UserStations
                    where station.StationId.Equals(id)
                    select station).FirstOrDefault();
        }

        private IUserStation RetrieveExtendedUserStationInfo(string stationToken)
        {
            IUserStation result = null;

            try
            {
                var retrieveExUserStationInfoRequest = new JSONRequest(
                    MethodNames.station_getStation,
                    false,
                    RequiredInfo,
                    new KeyValuePair<string, object>("stationToken", stationToken));
                var res = new JSONResult(retrieveExUserStationInfoRequest.StringRequestAsync().Result);

                if (res.IsFault)
                {
                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return null;
                }

                var data = res.Result;
                result = StationFactory.CreateUserStation(RequiredInfo, data);
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(new FaultMessage(ex.Message, ex));
                return null;
            }

            return result;
        }

        private IEnumerable<ITrack> RetrievePlaylist(string stationToken)
        {
            var result = new List<ITrack>();

            try
            {
                var retrievePlaylistRequest = new JSONRequest(
                    MethodNames.station_getPlaylist,
                    false,
                    RequiredInfo,
                    new KeyValuePair<string, object>("stationToken", stationToken));
                var res = new JSONResult(retrievePlaylistRequest.StringRequestAsync().Result);

                if (res.IsFault)
                {
                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return null;
                }

                var data = res.Result;
                foreach (var item in data["items"])
                {
                    if (item["songName"] == null) continue;

                    result.Add(TrackFactory.CreateTrack(RequiredInfo, item));
                }
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(new FaultMessage(ex.Message, ex));
                return null;
            }

            return result;
        }

        private string GetUserStationsChecksum()
        {
            var result = UserStationsChecksum;

            try
            {
                var getUserStationsChecksumRequest = new JSONRequest(MethodNames.user_getStationListChecksum, false, RequiredInfo);
                var res = new JSONResult(getUserStationsChecksumRequest.StringRequestAsync().Result);

                if (res.IsFault)
                {
                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return null;
                }

                result = res.Result.Value<string>("checksum") ?? UserStationsChecksum;
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(new FaultMessage(ex.Message, ex));
                return null;
            }

            return result;
        }

        private ISearchResult Search(string searchText)
        {
            ISearchResult result = null;

            try
            {
                var searchRequest = new JSONRequest(MethodNames.music_search,
                    false,
                    RequiredInfo,
                    new KeyValuePair<string, object>("searchText", searchText));
                var res = new JSONResult(searchRequest.StringRequestAsync().Result);

                if (res.IsFault)
                {
                    Messenger.Default.Send(new FaultMessage(res.Fault.Message));
                    return null;
                }

                var data = res.Result;
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(new FaultMessage(ex.Message, ex));
                return null;
            }

            return result;
        }

        private void CreateUserStation(string musicToken)
        {
            throw new NotImplementedException();
        }

        private void CreateUserStation(string trackToken, MusicType musicType)
        {
            throw new NotImplementedException();
        }

        private void AddMusic(string stationToken, string musicToken)
        {
            throw new NotImplementedException();
        }

        private void DeleteMusic(string seedId)
        {
            throw new NotImplementedException();
        }

        private void RenameStation(string stationToken, string stationName)
        {
            throw new NotImplementedException();
        }

        private void DeleteStation(string stationToken)
        {
            throw new NotImplementedException();
        }

        private void DeleteFeedback(string feedbackId)
        {
            throw new NotImplementedException();
        }

        private string GetGenreStationsChecksum()
        {
            throw new NotImplementedException();
        }

        private void ShareStation(string stationToken, string[] emails)
        {
            throw new NotImplementedException();
        }

        private void TransformSharedStation(string stationToken)
        {
            throw new NotImplementedException();
        }

        private void ModifyQuickMix(string[] quickMixStationIds)
        {
            throw new NotImplementedException();
        }

        private void RateTrack(string stationToken, string trackToken, bool isPositive)
        {
            throw new NotImplementedException();
        }

        private void TiredOfThisTrack(string trackToken)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<IExplanation> ExplainTrack(string trackToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
