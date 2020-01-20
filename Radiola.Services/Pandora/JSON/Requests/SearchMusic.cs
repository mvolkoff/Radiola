using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class SearchMusic : BaseRequest
    {
        public string searchText { get; }
        public bool includeNearMatches { get; }
        public bool includeGenreStations { get; }

        public SearchMusic(string _userAuthToken,
            long _syncTime,
            string _searchText,
            bool _includeNearMatches = true,
            bool _includeGenreStations = true) : base(_userAuthToken, _syncTime)
        {
            searchText = _searchText;
            includeNearMatches = _includeNearMatches;
            includeGenreStations = _includeGenreStations;
        }
    }
}
