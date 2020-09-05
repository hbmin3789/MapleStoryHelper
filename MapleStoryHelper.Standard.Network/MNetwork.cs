using MapleStoryHelper.Standard.MNetwork.Common;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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

        public async Task<T> GetResponse<T>(string resource, Method method,string parameter=null)
        {
            RestRequest request = new RestRequest(resource, method);

            if (parameter != null)
            {
                request.AddParameter("application/json", parameter, ParameterType.RequestBody);
            }
            var resp = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<T>(resp.Content);
        }
    }
}
