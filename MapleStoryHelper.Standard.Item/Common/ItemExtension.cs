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
                            retval.EquipmentCategory = GetEquipmentCategory(gear);
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

            if(Gear.IsLeftWeapon(gear.type) == true)
            {
                retval.WeaponConst = GetWeaponConst(gear);
            }

            MemoryStream ms = new MemoryStream();
            gear.Icon.Bitmap.MakeTransparent();
            gear.Icon.Bitmap.Save(ms, ImageFormat.Png);
            retval.ImgByte = ms.ToArray();

            return retval;
        }

        private static double GetWeaponConst(Gear gear)
        {
            double retval = 0.0;
            switch (gear.type)
            {
                case GearType.staff:
                case GearType.wand:
                    retval = 1.0;
                    break;
                case GearType.ohSword:
                case GearType.ohAxe:
                case GearType.ohBlunt:
                case GearType.shiningRod:
                case GearType.espLimiter:
                case GearType.magicGuntlet:
                    retval = 1.2;
                    break;
                case GearType.thSword:
                case GearType.thAxe:
                case GearType.thBlunt:
                case GearType.swordZL:
                    retval = 1.34;
                    break;
                case GearType.crossbow:
                    retval = 1.35;
                    break;
                case GearType.spear:
                case GearType.polearm:
                case GearType.swordZB:
                    retval = 1.49;
                    break;
                case GearType.energySword:
                case GearType.gun:
                case GearType.handCannon:
                    retval = 1.5;
                    break;
                case GearType.soulShooter:
                case GearType.GauntletBuster:
                case GearType.knuckle:
                    retval = 1.7;
                    break;
                case GearType.throwingGlove:
                    retval = 1.75;
                    break;
                default:
                    retval = 1.3;
                    break;
            }

            return retval;
        }

        private static EEquipmentCategory GetEquipmentCategory(Gear gear)
        {
            EEquipmentCategory retval = EEquipmentCategory.Ring;

            switch (gear.PropsString[GearPropType.islot])
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
                case "Si":
                case "Wp":

                    if(Gear.IsLeftWeapon(gear.type) == true)
                    {
                        retval = EEquipmentCategory.Weapon;
                        break;
                    }

                    if(Gear.IsSubWeapon(gear.type) == true)
                    {
                        retval = EEquipmentCategory.SubWeapon;
                        break;
                    }

                    retval = EEquipmentCategory.Emblem;
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
            }

            return retval;
        }
    }
}
