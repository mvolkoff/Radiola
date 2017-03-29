using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora
{
    public interface IGenreCategory
    {
        string GenreName { get; }
        IEnumerable<IGenreStation> Stations { get; }
    }
}
