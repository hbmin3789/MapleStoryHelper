using MapleStoryApiServer.Interfaces.Services;
using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryApiServer.Model.Services
{
    public class ItemSearchService : IItemSearchService
    {
        public void ItemSearch(EItemCategory itemCategory, string keyWord, EEquipmentCategory equipCategory)
        {
            switch (itemCategory)
            {
                case EItemCategory.Equipment:

                    break;
            }
        }
    }
}
