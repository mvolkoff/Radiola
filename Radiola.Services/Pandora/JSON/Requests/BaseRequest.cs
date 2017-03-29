using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    abstract internal class BaseRequest
    {
        public string userAuthToken { get; }
        public long syncTime { get; }

        public BaseRequest(string _userAuthToken, long _syncTime)
        {
            if (string.IsNullOrEmpty(_userAuthToken) || string.IsNullOrWhiteSpace(_userAuthToken))
                throw new ArgumentException("UserAuthToken argument cannot be null, whitespace or empty!");

            userAuthToken = _userAuthToken;
            syncTime = _syncTime;
        }
    }
}
