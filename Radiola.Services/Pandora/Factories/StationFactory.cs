using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.Concrete;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Factories
{
    internal class StationFactory
    {
        public static IUserStation CreateUserStation(RequiredInformation requiredInfo, JToken stationData)
        {
            return new UserStation(requiredInfo, stationData);
        }

        public static IGenreCategory CreateGenreCategory(RequiredInformation requiredInfo, JToken categoryData)
        {
            return new GenreCategory(requiredInfo, categoryData);
        }

        public static IStationFeedback GetStationFeedback(RequiredInformation requiredInfo, JToken feedbackData)
        {
            return new StationFeedback(requiredInfo, feedbackData);
        }

        public static IStationMusic GetStationMusicInfo(JToken musicData)
        {
            return new StationMusic(musicData);
        }

        public static IArtistInfo GetArtistInfo(JToken artistData)
        {
            return new ArtistInfo(artistData);
        }
    }
}
