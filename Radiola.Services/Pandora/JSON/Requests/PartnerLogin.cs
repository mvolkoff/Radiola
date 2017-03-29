using Radiola.Services.Pandora.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    sealed internal class PartnerLogin
    {
        public string username { get; }
        public string password { get; }
        public string deviceModel { get; }
        public string version { get; }
        public bool includeUrls { get; }
        public bool returnDeviceType { get; }
        public bool returnUpdatePromptVersions { get; }

        public PartnerLogin() : this(
            PandoraConstants.PARTNER_USERNAME,
            PandoraConstants.PARTNER_PASSWORD,
            PandoraConstants.PARTNER_DEVICE_ID,
            PandoraConstants.API_VERSION,
            true)
        { }

        public PartnerLogin(string _username, string _password, string _deviceModel, string _version, bool _includeUrls, bool _returnDeviceType = false, bool _returnUpdatePromptVersions = false)
        {
            username = _username;
            password = _password;
            deviceModel = _deviceModel;
            version = _version;
            includeUrls = _includeUrls;
            returnDeviceType = _returnDeviceType;
            returnUpdatePromptVersions = _returnUpdatePromptVersions;
        }
    }
}
