using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.Common
{
    internal enum ErrorCodes
    {
        UNKNOWN_ERROR = -2,
        SUCCESS = -1,
        INTERNAL_ERROR = 0, // It can denote that your account has been temporarily blocked due to having too frequent station.getPlaylist calls.
        MAINTENANCE_MODE = 1,
        URL_PARAM_MISSING_METHOD = 2,
        URL_PARAM_MISSING_AUTH_TOKEN = 3,
        URL_PARAM_MISSING_PARTNER_ID = 4,
        URL_PARAM_MISSING_USER_ID = 5,
        SECURE_PROTOCOL_REQUIRED = 6,
        CERTIFICATE_REQUIRED = 7,
        PARAMETER_TYPE_MISMATCH = 8,
        PARAMETER_MISSING = 9, // Usually occurs when one or more required parameters are missing for the method called.
        PARAMETER_VALUE_INVALID = 10,
        API_VERSION_NOT_SUPPORTED = 11,
        LICENSING_RESTRICTIONS = 12, // Pandora not available in this country.
        INSUFFICIENT_CONNECTIVITY = 13, // Bad sync time?
        UNKNOWN_METHOD_NAME = 14,
        WRONG_PROTOCOL_HTTP_HTTPS = 15,
        READ_ONLY_MODE = 1000,
        INVALID_AUTH_TOKEN = 1001, // Occurs once a user auth token expires.
        INVALID_PARTNER_LOGIN = 1002, // auth.partnerLogin auth.userLogin. Can also occur for a user login.
        LISTENER_NOT_AUTHORIZED = 1003, // station.getPlaylist - Pandora One Subscription or Trial Expired. Possibly account suspended?
        USER_NOT_AUTHORIZED = 1004, // User not authorized to perform action.
        MAX_STATIONS_REACHED = 1005, // Station limit reached.
        STATION_DOES_NOT_EXIST = 1006, // Station does not exist.
        COMPLIMENTARY_PERIOD_ALREADY_IN_USE = 1007,
        CALL_NOT_ALLOWED = 1008, // station.addFeedback - Returned when attempting to add feedback to shared station.
        DEVICE_NOT_FOUND = 1009,
        PARTNER_NOT_AUTHORIZED = 1010,
        INVALID_USERNAME = 1011,
        INVALID_PASSWORD = 1012,
        USERNAME_ALREADY_EXISTS = 1013,
        DEVICE_ALREADY_ASSOCIATED_TO_ACCOUNT = 1014,
        UPGRADE_DEVICE_MODEL_INVALID = 1015,
        EXPLICIT_PIN_INCORRECT = 1018,
        EXPLICIT_PIN_MALFORMED = 1020,
        DEVICE_MODEL_INVALID = 1023,
        ZIP_CODE_INVALID = 1024,
        BIRTH_YEAR_INVALID = 1025,
        BIRTH_YEAR_TOO_YOUNG = 1026,
        INVALID_COUNTRY_CODE = 1027,
        DEVICE_DISABLED = 1034,
        DAILY_TRIAL_LIMIT_REACHED = 1035,
        INVALID_SPONSOR = 1036,
        USER_ALREADY_USED_TRIAL = 1037,
        PLAYLIST_EXCEEDED = 1039// Too many requests for a new playlist.
    }
}
