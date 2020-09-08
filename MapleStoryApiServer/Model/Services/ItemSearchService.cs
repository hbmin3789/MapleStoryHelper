using MapleStoryApiServer.Controller;
using MapleStoryApiServer.Interfaces.Services;
using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.MNetwork.Model;
using MapleStoryHelper.Standard.Server.Model.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryApiServer.Model.Services
{
    public class ItemSearchService : IItemSearchService
    {
        private ItemSearchController controller = new ItemSearchController();

        public string EquipItem(Stream body)
        {
            

            string bodyParameter = new StreamReader(body as Stream).ReadToEnd();
            var paramter = JsonConvert.DeserializeObject<EquipItemSearchRequest>(bodyParameter);

            MResponse<List<EquipmentItem>> retval = new MResponse<List<EquipmentItem>>();
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";

            retval.Data = controller.GetEquipmentItems(paramter.KeyWord, paramter.Category);
            retval.Status = 200;
            retval.Message = "Good!";

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            string temp = JsonConvert.SerializeObject(retval,Formatting.Indented);

            return temp;
        }
    }
}
