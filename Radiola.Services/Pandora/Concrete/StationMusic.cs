using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    internal class StationMusic : IStationMusic
    {
        public IEnumerable<IArtistInfo> Artists { get; }

        public StationMusic(JToken musicData)
        {
            var artistsData = musicData["artists"];
            if (artistsData != null)
            {
                Artists = from artist in artistsData select StationFactory.GetArtistInfo(artist);
            }
        }
    }
}
