using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora
{
    public interface IStationFeedback
    {
        int TotalThumbsUp { get; }
        IEnumerable<ITrack> ThumbsUp { get; }

        int TotalThumbsDown { get; }
        IEnumerable<ITrack> ThumbsDown { get; }
    }
}
