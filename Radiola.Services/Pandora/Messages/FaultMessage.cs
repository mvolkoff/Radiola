using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Messages
{
    public class FaultMessage
    {
        public string DisplayedMessage { get; private set; }
        public Exception FaultDetails { get; private set; }

        public FaultMessage(string message, Exception faultDetails = null)
        {
            DisplayedMessage = message;
            FaultDetails = faultDetails;
        }
    }
}
