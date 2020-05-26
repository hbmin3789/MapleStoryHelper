using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Resources.Attributes
{
    public class WeaponResourceInfoAttribute : ResourceInfoAttribute
    {
        public double WeaponConst = 1.0;

        public WeaponResourceInfoAttribute(string name, string itemCode, EEquipmentCategory category, int setItemID, double wpConst)
                                         : base(name, itemCode, category, setItemID)
        {
            ResourceName = name;
            Category = category;
            ItemCode = itemCode;
            SetItemID = setItemID;
            WeaponConst = wpConst;
        }

    }
}
