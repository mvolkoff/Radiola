using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class RequiredInformation
    {
        public string AuthToken { get; set; }
        public string PartnerID { get; set; }
        public string UserID { get; set; }
        public long SyncTime { get; set; }
    }
}
