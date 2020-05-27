using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Resources.Attributes
{
    public class EquipmentResourceInfoAttribute : ResourceInfoAttribute
    {
        public EJobCategory JobCategory { get; set; }

        public EquipmentResourceInfoAttribute(string name, string itemCode, EEquipmentCategory category, EJobCategory jobCategory, int setItemID)
                                         : base(name, itemCode, category, setItemID)
        {
            ResourceName = name;
            Category = category;
            ItemCode = itemCode;
            SetItemID = setItemID;
        }
    }
}
