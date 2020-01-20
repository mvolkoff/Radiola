using Radiola.Services.Pandora.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora
{
    public interface IPandoraService
    {
        #region Properties
        List<IUserStation> UserStations { get; }
        string UserStationsChecksum { get; }

        List<IGenreCategory> GenreCategories { get; }
        string GenreStationsChecksum { get; }
        #endregion

        #region Methods

        #region Authentication
        Task<bool> ConnectAsync(string username, string password);
        #endregion

        #region Stations
        Task<List<IUserStation>> RetrieveUserStationsAsync();
        Task<string> GetUserStationsChecksumAsync();
        Task<ISearchResult> SearchAsync(string searchText);
        Task CreateUserStationAsync(string musicToken);
        Task CreateUserStationAsync(string trackToken, MusicType musicType);
        Task AddMusicAsync(string stationToken, string musicToken);
        Task DeleteMusicAsync(string seedId);
        Task RenameStationAsync(string stationToken, string stationName);
        Task DeleteStationAsync(string stationToken);
        Task<IUserStation> RetrieveExtendedUserStationInfoAsync(string stationToken);
        Task DeleteFeedbackAsync(string feedbackId);
        Task<List<IGenreCategory>> RetrieveGenreCategoriesAsync();
        Task<string> GetGenreStationsChecksumAsync();
        Task ShareStationAsync(string stationToken, string[] emails);
        Task TransformSharedStationAsync(string stationToken);
        Task ModifyQuickMixAsync(string[] quickMixStationIds);

        Task<IUserStation> GetUserStationByIDAsync(string id);
        #endregion

        #region Play
        Task<IEnumerable<ITrack>> RetrievePlaylistAsync(string stationToken);
        Task RateTrackAsync(string stationToken, string trackToken, bool isPositive);
        Task TiredOfThisTrackAsync(string trackToken);
        Task<IEnumerable<IExplanation>> ExplainTrackAsync(string trackToken);
        #endregion

        #endregion
    }
}
