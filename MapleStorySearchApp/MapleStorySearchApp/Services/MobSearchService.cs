using MapleStoryHelper.Standard.MNetwork;
using MapleStoryHelper.Standard.MobLib.Common;
using MapleStoryHelper.Standard.MobLib.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MapleStorySearchApp.Services
{
    public class MobSearchService
    {
        private const string MOB_SEARCH_URL = "/MobSearch";
        private MNetwork networkManager;

        public MobSearchService(MNetwork manager)
        {
            networkManager = manager;
        }

        public async Task<List<MobBase>> GetMobs(string keyWord, EMobMapCategory category)
        {
            JObject job = new JObject();
            job.Add("keyWord", keyWord);
            job.Add("category", category.ToString());
            var resp = await networkManager.GetResponse<List<MobBase>>(MOB_SEARCH_URL, Method.POST, job.ToString());

            return resp.Data;
        }
    }
}
