using Radiola.Services.Pandora.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Concrete
{
    public class GenreStation : IGenreStation
    {
        public string StationID { get; set; }
        public string StationToken { get; set; }
        public string StationName { get; set; }
    }
}
