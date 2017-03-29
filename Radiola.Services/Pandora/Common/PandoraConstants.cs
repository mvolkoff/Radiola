using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Common
{
    internal static class PandoraConstants
    {
        public static readonly string RPC_URL = @"tuner.pandora.com/services/json/";
        public static readonly int HTTP_TIMEOUT = 30;
        //public static readonly string AUDIO_FORMAT = PAudioFormat.MP3;

        public static readonly int PLAYLIST_VALIDITY_TIME = (int)(60 * 60 * 0.5);

        public static readonly string PARTNER_USERNAME = "android";
        public static readonly string PARTNER_PASSWORD = "AC7IBG09A3DTSYM4R41UJWL07VLN8JI7";
        public static readonly string PARTNER_DEVICE_ID = "android-generic";
        public static readonly string API_VERSION = "5";
        public static readonly string CRYPT_IN_KEY = @"R=U!LH$O2B#";
        public static readonly string CRYPT_OUT_KEY = @"6#26FRL$ZWD";
    }
}
