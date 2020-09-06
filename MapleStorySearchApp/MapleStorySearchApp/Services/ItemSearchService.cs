using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.MNetwork;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MapleStorySearchApp.Services
{
    public class ItemSearchService
    {
        private MNetwork networkManager;

        public ItemSearchService()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            networkManager = new MNetwork(NetworkInfo.IP);
        }

        public async Task<List<EquipmentItem>> SearchItem(string KeyWord)
        {
            var resp = await networkManager.GetResponse<List<EquipmentItem>>("", Method.GET);
            if(resp.Status != 200)
            {
                return null;
            }

            return resp.Data;
        }
    }
}
