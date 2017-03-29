using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Messages
{
    public class AwaitableOperationMessage
    {
        public string Message { get; set; }
        public bool IsRunning { get; set; }
    }
}
