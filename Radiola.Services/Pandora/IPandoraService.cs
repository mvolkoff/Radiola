using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora
{
    public interface IPandoraService
    {
        List<IUserStation> UserStations { get; }
        List<IGenreCategory> GenreCategories { get; }

        Task<bool> ConnectAsync(string username, string password);

        Task<List<IUserStation>> RetrieveUserStationsAsync();
        Task<IUserStation> RetrieveExtendedUserStationInfoAsync(string stationToken);
        Task<IUserStation> GetUserStationByIDAsync(string id);

        Task<List<IGenreCategory>> RetrieveGenreCategoriesAsync();

        Task<IEnumerable<ITrack>> RetrievePlaylistAsync(string stationToken);
    }
}
