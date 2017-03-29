using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora
{
    public interface IAudio
    {
        string Bitrate { get; }
        string Encoding { get; }
        string AudioUrl { get; }
        string Protocol { get; }
    }
}
