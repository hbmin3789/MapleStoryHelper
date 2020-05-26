using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Resources.Attributes
{
    public class WeaponResourceInfoAttribute : ResourceInfoAttribute
    {
        public int SetItemID { get; set; }

        public WeaponResourceInfoAttribute(string name, string itemCode, EEquipmentCategory category,int setItemID) : base(name, itemCode, category)
        {
            ResourceName = name;
            Category = category;
            ItemCode = itemCode;
            SetItemID = setItemID;
        }

    }
}
