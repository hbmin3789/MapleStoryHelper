using MapleStoryApiServer.Controller;
using MapleStoryApiServer.Interfaces.Services;
using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Server.Model.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryApiServer.Model.Services
{
    public class ItemSearchService : IItemSearchService
    {
        private ItemSearchController controller = new ItemSearchController();

        public string EquipItem(string keyWord, EEquipmentCategory equipCategory)
        {
            MResponse<List<EquipmentItem>> retval = new MResponse<List<EquipmentItem>>();
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            retval.Data = controller.GetEquipmentItems(keyWord, equipCategory);
            retval.Status = 200;
            retval.Message = "Good!";
            string temp = JsonConvert.SerializeObject(retval,Formatting.Indented);
            return temp;
        }
    }
}
