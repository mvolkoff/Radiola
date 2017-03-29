using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.Factories;
using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    internal class StationFeedback : IStationFeedback
    {
        public int TotalThumbsUp { get { return ThumbsUp?.Count() ?? 0; } }
        public IEnumerable<ITrack> ThumbsUp { get; private set; }

        public int TotalThumbsDown { get { return ThumbsDown?.Count() ?? 0; } }
        public IEnumerable<ITrack> ThumbsDown { get; private set; }

        public StationFeedback(RequiredInformation requiredInfo, JToken feedbackData)
        {
            var thumbsUpData = feedbackData["thumbsUp"];
            if (thumbsUpData != null)
                ThumbsUp = from thumbUp in thumbsUpData select TrackFactory.CreateTrack(requiredInfo, thumbUp);

            var thumbsDownData = feedbackData["thumbsDown"];
            if (thumbsDownData != null)
                ThumbsDown = from thumbDown in thumbsDownData select TrackFactory.CreateTrack(requiredInfo, thumbDown);
        }
    }
}
