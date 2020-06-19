using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
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
                            retval.EquipmentCategory = GetEquipmentCategory(gear.PropsString[(GearPropType)propNames.GetValue(i)]);
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
                        //case "tuc":
                        //    retval.MaxScroll = gear.Props[(GearPropType)propNames.GetValue(i)];
                        //    break;
                        //case "bossReward":
                        //    retval. = Convert.ToInt32(item.ChildNodes[j].Value);
                        //    break;
                        //case "setItemID":
                        //    retval.RequiredLevel = gear.Props[(GearPropType)propNames.GetValue(i)];
                        //    break;
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

        public static EEquipmentCategory GetEquipmentCategory(string keyWord)
        {
            EEquipmentCategory retval = EEquipmentCategory.Ring;

            switch (keyWord)
            {
                case "Cp":
                    retval = EEquipmentCategory.Cap;
                    break;
                case "Ri":
                    retval = EEquipmentCategory.Ring;
                    break;
                case "Po":
                    retval = EEquipmentCategory.Pocket;
                    break;
                case "Pe":
                    retval = EEquipmentCategory.Pendant;
                    break;
                case "Ay":
                    retval = EEquipmentCategory.Eye;
                    break;
                case "Sr":
                    retval = EEquipmentCategory.Cape;
                    break;
                case "Ma":
                    retval = EEquipmentCategory.Clothes;
                    break;
                case "MaPn":
                    retval = EEquipmentCategory.Clothes;
                    break;
                case "Pn":
                    retval = EEquipmentCategory.Pants;
                    break;
                case "So":
                    retval = EEquipmentCategory.Shoes;
                    break;
                case "Wp":
                    retval = EEquipmentCategory.Weapon;
                    break;
                case "Tm":
                    retval = EEquipmentCategory.Android;
                    break;
                case "Af":
                    retval = EEquipmentCategory.Face;
                    break;
                case "Be":
                    retval = EEquipmentCategory.Belt;
                    break;
                case "Me":
                    retval = EEquipmentCategory.Medal;
                    break;
                case "Ba":
                    retval = EEquipmentCategory.Badge;
                    break;
                case "Ae":
                    retval = EEquipmentCategory.Ear;
                    break;
                case "Sh":
                    retval = EEquipmentCategory.Shoulder;
                    break;
                case "Gv":
                    retval = EEquipmentCategory.Gloves;
                    break;
                case "Si":
#warning 나중에 고칠것
                    //retval = EEquipmentCategory.SubWeapon;
                    retval = EEquipmentCategory.Emblem;
                    break;
            }

            return retval;
        }
    }
}
