using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.Concrete;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radiola.Services.Pandora.Common;

namespace Radiola.Services.Pandora.Factories
{
    internal class TrackFactory
    {
        public static ITrack CreateTrack(RequiredInformation requiredInfo, JToken trackData)
        {
            return new Track(requiredInfo, trackData);
        }

        public static IDictionary<QualityNames, IAudio> CreateAudioMap(JToken audioUrlMap)
        {
            var result = new Dictionary<QualityNames, IAudio>();

            var item = audioUrlMap["highQuality"];
            if (item != null)
                result.Add(QualityNames.HighQuality, CreateAudioUrlItem(item));

            item = audioUrlMap["mediumQuality"];
            if (item != null)
                result.Add(QualityNames.MediumQuality, CreateAudioUrlItem(item));

            item = audioUrlMap["lowQuality"];
            if (item != null)
                result.Add(QualityNames.LowQuality, CreateAudioUrlItem(item));

            return result;
        }

        internal static IAudio CreateAudioUrlItem(JToken item)
        {
            return new AudioUrlItem(item);
        }
    }
}
