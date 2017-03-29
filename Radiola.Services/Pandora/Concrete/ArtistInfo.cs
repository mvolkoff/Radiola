using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    internal class ArtistInfo : IArtistInfo
    {
        public string ArtistName { get; private set; }

        public string ArtUrl { get; private set; }

        public string MusicToken { get; private set; }

        public string SeedId { get; private set; }

        public string PandoraId { get; private set; }

        public string PandoraType { get; private set; }

        public ArtistInfo(JToken artistData)
        {
            ArtistName = artistData.Value<string>("artistName") ?? string.Empty;
            ArtUrl = artistData.Value<string>("artUrl") ?? string.Empty;
            MusicToken = artistData.Value<string>("musicToken") ?? string.Empty;
            SeedId = artistData.Value<string>("seedId") ?? string.Empty;
            PandoraId = artistData.Value<string>("pandoraId") ?? string.Empty;
            PandoraType = artistData.Value<string>("pandoraType") ?? string.Empty;
        }
    }
}
