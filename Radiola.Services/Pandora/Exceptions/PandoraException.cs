using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Exceptions
{
    public class PandoraException : Exception
    {
        public PandoraException(string message) : base(message)
        { }

        public PandoraException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
