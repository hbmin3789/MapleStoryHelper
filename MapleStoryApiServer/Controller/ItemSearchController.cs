using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryApiServer.Controller
{
    public class ItemSearchController
    {
        public List<EquipmentItem> GetEquipmentItems(string keyWord, EEquipmentCategory equipCategory)
        {
            List<EquipmentItem> item = new List<EquipmentItem>();

            item = App.wzManager.GetEquipmentItems(keyWord, equipCategory);

            return item;
        }
    }
}
