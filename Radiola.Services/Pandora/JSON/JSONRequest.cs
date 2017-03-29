using Radiola.Services.Pandora.Common;
using Radiola.Services.Pandora.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Radiola.Services.Pandora.JSON
{
    internal class JSONRequest
    {
        //TODO: Добавить подробное логирование

        private const string _userAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.7 (KHTML, like Gecko) Chrome/16.0.912.63 Safari/535.7";

        public string URI { get; private set; }
        public string Data { get; private set; }

        public JSONRequest(string methodName, bool useSSL, RequiredInformation requiredInfo, params KeyValuePair<string, object>[] additionalInfo)
        {
            if (string.IsNullOrEmpty(methodName) || string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("Please specify methodName argument");

            if (requiredInfo != null)
            {
                URI = (useSSL ? "https://" : "http://") + PandoraConstants.RPC_URL + "?method=" + methodName;

                URI += !string.IsNullOrEmpty(requiredInfo.PartnerID) && !string.IsNullOrWhiteSpace(requiredInfo.PartnerID) ? "&partner_id=" + requiredInfo.PartnerID : string.Empty;
                URI += !string.IsNullOrEmpty(requiredInfo.AuthToken) && !string.IsNullOrWhiteSpace(requiredInfo.AuthToken) ? "&auth_token=" + Uri.EscapeDataString(requiredInfo.AuthToken) : string.Empty;
                URI += !string.IsNullOrEmpty(requiredInfo.UserID) && !string.IsNullOrWhiteSpace(requiredInfo.UserID) ? "&user_id=" + requiredInfo.UserID : string.Empty;
            }
            else
                URI = (useSSL ? "https://" : "http://") + PandoraConstants.RPC_URL + "?method=" + methodName;

            if (methodName == MethodNames.auth_partnerLogin)
                Data = RequestFactory.GetRequest(methodName, requiredInfo, additionalInfo);
            else
                Data = Cryptography.out_key.Encrypt(RequestFactory.GetRequest(methodName, requiredInfo, additionalInfo));
        }

        public async Task<string> StringRequestAsync()
        {
            var response = string.Empty;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("utf8"));
                client.DefaultRequestHeaders.Add("User-Agent", _userAgent);
                try
                {
                    var result = await client.PostAsync(new Uri(URI), new StringContent(Data, Encoding.UTF8, "text/json"));

                    result.EnsureSuccessStatusCode();

                    response = await result.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {

                }
            }
            return response;
        }

        public async Task<byte[]> ByteRequestAsync(string url)
        {
            byte[] response = null;

            using (var client = new HttpClient())
            {
                try
                {
                    var result = client.GetAsync(new Uri(url)).Result;

                    result.EnsureSuccessStatusCode();

                    response = await result.Content.ReadAsByteArrayAsync();
                }
                catch (Exception ex)
                {

                }
            }
            return response;
        }
    }
}
