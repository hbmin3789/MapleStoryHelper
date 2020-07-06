using MapleStoryHelper.Standard.Character.Model;
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

        public List<EquipmentItem> GetEquipmentItems(Character character, EEquipmentCategory category, string keyWord)
        {
            var items = stringWzReader.GetEquipmentItems(category, keyWord);
            //if(category == EEquipmentCategory.Weapon || category == EEquipmentCategory.SubWeapon)
            //{
            //    for(int i = 0; i < items.Count; i++)
            //    {
            //        var categories = items[i].GetWeaponJob();
            //        var list = categories.Where(x => x == character.CharacterJob).ToList();
            //        if(list.Count == 0) 
            //        {
            //            items.RemoveAt(i);
            //            i--;
            //        }
            //    }
            //}

            for (int i = 0; i < items.Count; i++)
            {
                items[i].ImgBitmapSource = items[i].ImgByte.LoadImage();
            }
            return items;
        }

        #endregion
    }
}
