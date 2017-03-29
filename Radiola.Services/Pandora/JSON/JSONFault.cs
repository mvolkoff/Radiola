using Radiola.Services.Pandora.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class JSONFault
    {
        public ErrorCodes Code { get; set; }
        public string Message { get; set; }
    }
}
