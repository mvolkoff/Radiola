using System;

namespace Radiola.Services.Pandora.Extensions
{
    internal static class DoubleExtensions
    {
        public static DateTime FromJavaTimeStamp(this double javaTimeStamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(Math.Round(javaTimeStamp / 1000)).ToLocalTime();
        }
    }
}
