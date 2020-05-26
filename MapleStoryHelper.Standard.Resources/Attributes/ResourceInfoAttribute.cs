using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Resources.Attributes
{
    public class ResourceInfoAttribute : Attribute
    {
        public string ResourceName { get; set; }
        public EEquipmentCategory Category { get; set; }
        public string ItemCode { get; set; }
        public int SetItemID { get; set; }

        public ResourceInfoAttribute(string name, string itemCode, EEquipmentCategory category)
        {
            ResourceName = name;
            Category = category;
            ItemCode = itemCode;
        }

        public ResourceInfoAttribute(string name, string itemCode, EEquipmentCategory category,int SetItemID)
        {
            ResourceName = name;
            Category = category;
            ItemCode = itemCode;
        }

    }
}
