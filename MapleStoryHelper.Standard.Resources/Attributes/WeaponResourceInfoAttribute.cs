using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Resources.Attributes
{
    public class WeaponResourceInfoAttribute : EquipmentResourceInfoAttribute
    {
        public double WeaponConst = 1.0;

        public WeaponResourceInfoAttribute(string name, string itemCode, EEquipmentCategory category, EJobCategory jobCategory, int setItemID, double wpConst)
                                         : base(name, itemCode, category, jobCategory, setItemID)
        {
            ResourceName = name;
            Category = category;
            ItemCode = itemCode;
            SetItemID = setItemID;
            WeaponConst = wpConst;
        }

    }
}
