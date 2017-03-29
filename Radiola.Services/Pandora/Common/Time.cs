using Radiola.Services.Pandora.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Common
{
    internal class Time
    {
        public static int Unix()
        {
            return DateTime.UtcNow.ToEpochTime();
        }

        public static DateTime FromJavaTimeStamp(double javaTimeStamp)
        {
            return javaTimeStamp.FromJavaTimeStamp();
        }
    }
}
