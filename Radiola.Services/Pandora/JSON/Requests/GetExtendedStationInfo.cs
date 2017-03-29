using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class GetExtendedStationInfo : BaseRequest
    {
        public string stationToken { get; }
        public bool includeExtendedAttributes { get; }
        
        public GetExtendedStationInfo(string _userAuthToken, long _syncTime, string _stationToken, bool _includeExtendedAttributes = true) : base(_userAuthToken, _syncTime)
        {
            stationToken = _stationToken;
            includeExtendedAttributes = _includeExtendedAttributes;
        }
    }
}
