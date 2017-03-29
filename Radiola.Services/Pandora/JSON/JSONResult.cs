using Newtonsoft.Json.Linq;
using Radiola.Services.Pandora.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class JSONResult : JObject
    {
        private ErrorCodes FaultCode
        {
            get
            {
                if (!IsFault)
                    return ErrorCodes.SUCCESS;

                int c = (this["code"].ToObject<int>());

                try
                {
                    return (ErrorCodes)c;
                }
                catch
                {
                    return ErrorCodes.UNKNOWN_ERROR;
                }
            }
        }
        private string FaultString => !IsFault ? "Operation completed successfully." : this["message"].ToString() + ". Error code: " + FaultCode;

        public JToken Result => this["result"];

        public bool IsFault
        {
            get
            {
                if (!this.TryGetValue("stat", out JToken v)) return false;

                return v.ToString() == "fail";
            }
        }

        public JSONFault Fault => new JSONFault { Code = FaultCode, Message = FaultString };

        public JSONResult(string data)
        {
            JObject r = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(data);
            foreach (KeyValuePair<string, JToken> kvp in r)
            {
                this.Add(kvp.Key, kvp.Value);
            }
        }
    }
}
