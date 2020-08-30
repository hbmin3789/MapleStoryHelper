﻿using MapleStoryHelper.Standard.Character.Model;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public partial class MapleWz
    {
        #region GetItems

        public List<EquipmentItem> GetEquipmentItems(string keyWord, EEquipmentCategory category)
        {
            return stringWzReader.GetEquipmentItems(category, keyWord);
        }

        #endregion
    }
}
