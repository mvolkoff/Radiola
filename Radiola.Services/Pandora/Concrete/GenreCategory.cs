using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    public class GenreCategory : IGenreCategory
    {
        #region Properties
        internal RequiredInformation RequiredInfo { get; private set; }

        public string GenreName { get; private set; }

        public IEnumerable<IGenreStation> Stations { get; private set; }
        #endregion

        internal GenreCategory(RequiredInformation requiredInfo, JToken categoryData)
        {
            RequiredInfo = requiredInfo;

            GenreName = categoryData.Value<string>("categoryName") ?? string.Empty;

            Stations = from station
                       in categoryData["stations"]
                       select new GenreStation
                       {
                           StationID = station.Value<string>("stationId") ?? string.Empty,
                           StationToken = station.Value<string>("stationToken") ?? string.Empty,
                           StationName = station.Value<string>("stationName") ?? string.Empty
                       };
        }
    }
}
