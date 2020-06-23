﻿using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelper.Framework.ResourceManager.Utils
{
    public static class CategoryManager
    {
        public static string GetEquipmentCategoryString(EEquipmentCategory category)
        {
            switch (category)
            {
                case EEquipmentCategory.Pendant:
                case EEquipmentCategory.Belt:
                case EEquipmentCategory.Badge:
                case EEquipmentCategory.Ear:
                case EEquipmentCategory.Emblem:
                case EEquipmentCategory.Eye:
                case EEquipmentCategory.Medal:
                case EEquipmentCategory.Pocket:
                case EEquipmentCategory.Shoulder:
                case EEquipmentCategory.Face:
                    return "Accessory";
                case EEquipmentCategory.Heart:
                case EEquipmentCategory.Android:
                    return "Android";
                case EEquipmentCategory.SubWeapon:
                case EEquipmentCategory.Weapon:
                    return "Weapon";
            }

            return category.ToString();
        }
    }
}
