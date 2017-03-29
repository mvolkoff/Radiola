using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Extensions
{
    internal static class DateTimeExtensions
    {
        public static int ToEpochTime(this DateTime time)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (int)time.Subtract(epoch).TotalSeconds;
        }
    }
}
