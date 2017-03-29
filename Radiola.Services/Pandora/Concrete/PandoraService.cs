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

        internal string StationsChecksum { get; private set; }
        internal string GenreStationsChecksum { get; private set; }

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
                StationsChecksum = data["checksum"].ToString();
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
        #endregion
    }
}
