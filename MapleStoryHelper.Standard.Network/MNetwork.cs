using MapleStoryHelper.Standard.MNetwork.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelper.Standard.MNetwork
{
    public class MNetwork
    {
        private RestClient client;

        public MNetwork(string address)
        {
            client = new RestClient(address);
        }

        public async Task<MResponse<T>> GetResponse<T>(string resource, Method method,string parameter=null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            MResponse<T> retval = new MResponse<T>();
            RestRequest request = new RestRequest(resource, method);

            if (parameter != null)
            {
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", parameter, ParameterType.RequestBody);
            }

            try
            {
                var resp = await client.ExecuteAsync(request);

                string json = JToken.Parse(resp.Content).ToString();
                var data = JsonConvert.DeserializeObject<MResponse<T>>(json);
                return data;
            }
            catch(Exception e)
            {
                Debug.Write("MNetwork.cs GetResponse<T>() Network Error : ");
                Debug.WriteLine(e.Message);
            }

            return retval;
        }
    }
}
