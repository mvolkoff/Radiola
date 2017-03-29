using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    internal class AudioUrlItem : IAudio
    {
        public string Bitrate { get; private set; }

        public string Encoding { get; private set; }

        public string Protocol { get; private set; }

        public string AudioUrl { get; private set; }

        public AudioUrlItem(JToken data)
        {
            Bitrate = data["bitrate"].Value<string>() ?? string.Empty;
            Encoding = data["encoding"].Value<string>() ?? string.Empty;
            Protocol = data["protocol"].Value<string>() ?? string.Empty;
            AudioUrl = data["audioUrl"].Value<string>() ?? string.Empty;
        }
    }
}
