using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class GetGenreStations : BaseRequest
    {
        public GetGenreStations(string _userAuthToken, long _syncTime) : base(_userAuthToken, _syncTime)
        { }
    }
}
