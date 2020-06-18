using MapleStoryHelper.Standard.Character;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using WzComparerR2.CharaSim;
using WzComparerR2.Common.Extension;

namespace MapleStoryHelper.Standard.Item.Common
{
    public static class ItemExtension
    {
        public static EquipmentItem ToEquipmentItem(this Gear gear)
        {
            EquipmentItem retval = new EquipmentItem();
            var propNames = Enum.GetValues(typeof(GearPropType));

            for (int i = 0; i < propNames.Length; i++)
            {
                try
                {
                    switch (propNames.GetValue(i).ToString())
                    {
                        case "reqJob":
                            retval.CharacterCategory = (ECharacterJob)gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "islot":
                            //retval.EquipmentCategory = (EEquipmentCategory)item.ChildNodes[j].Value;
                            break;
                        case "reqLevel":
                            retval.RequiredLevel = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incSTR":
                            retval.Status.Str = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incDEX":
                            retval.Status.Dex = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incINT":
                            retval.Status.Int = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incLUK":
                            retval.Status.Luk = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incPAD":
                            retval.Status.AttackPower = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incMAD":
                            retval.Status.MagicAttack = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incMHP":
                            retval.Status.HP = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "incMMP":
                            retval.Status.MP = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "tuc":
                            retval.MaxScroll = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "bossReward":
                            //retval. = Convert.ToInt32(item.ChildNodes[j].Value);
                            break;
                        case "setItemID":
                            retval.RequiredLevel = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                    }
                }
                catch
                {

                }
                
            }
            MemoryStream ms = new MemoryStream();
            gear.Icon.Bitmap.MakeTransparent();
            gear.Icon.Bitmap.Save(ms, ImageFormat.Png);
            retval.ImgByte = ms.ToArray();

            return retval;
        }
    }
}
