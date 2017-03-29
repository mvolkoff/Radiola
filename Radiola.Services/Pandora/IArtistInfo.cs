using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora
{
    public interface IArtistInfo
    {
        string ArtistName { get; }
        string ArtUrl { get; }
        string MusicToken { get; }
        string SeedId { get; }
        string PandoraId { get; }
        string PandoraType { get; }
    }
}
