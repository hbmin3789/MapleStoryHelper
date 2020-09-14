using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WzComparerR2.CharaSim;
using WzComparerR2.PluginBase;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager.Common
{
    public static class ItemExtension
    {
        /// <summary>
        /// 해당 노드의 image를 구체화합니다.
        /// </summary>
        /// <param name="node">image를 구할 부모 노드 ex) Weapon.img, Cap.img, etc</param>
        /// <param name="keyWord">image를 구할 노드 이름 ex) 01111.img</param>
        /// <returns></returns>
        public static Wz_Image GetImage(this Wz_Node parentNode, string keyWord)
        {            
            var imgNode = parentNode.FindNodeByPath(keyWord);
            Wz_Image image;

            if(imgNode == null)
            {
                return null;
            }

            if ((image = imgNode.GetValue<Wz_Image>()) == null || !image.TryExtract())
            {
                return null;
            }

            return image;
        }

        public static Wz_Image GetImage(this Wz_Node node)
        {
            Wz_Image image;
            if ((image = node.GetValue<Wz_Image>()) == null || !image.TryExtract())
            {
                return null;
            }

            return image;
        }

        public static string GetItemCodeByOutLink(this string OutLink)
        {
            string retval = "";

            OutLink = OutLink.Replace(".img", "");
            var strArr = OutLink.Split(new char[] { '/' });

            for (int i = 0; i < strArr.Length; i++)
            {
                int result = 0;
                if (int.TryParse(strArr[i], out result) == true)
                {
                    retval = string.Format("0{0}.img", result);
                }
            }

            return retval;
        }

        public static EquipmentItem ToEquipmentItem(this Gear gear, Wz_Node node)
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
                            retval.Advancement = (EAdvancement)gear.Props[(GearPropType)propNames.GetValue(i)];
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
                        case "imdR":
                            retval.Status.IgnoreDef = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "bdR":
                            retval.Status.BossDamage = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        //case "bossReward":
                        //    retval. = Convert.ToInt32(item.ChildNodes[j].Value);
                        //    break;
                        case "setItemID":
                            retval.SetItemID = gear.Props[(GearPropType)propNames.GetValue(i)];
                            break;
                        case "jokerToSetItem":
                            if(gear.Props[(GearPropType)propNames.GetValue(i)] == 1)
                            {
                                retval.IsJoker = true;
                            }
                            else
                            {
                                retval.IsJoker = false;
                            }
                            break;
                    }
                }
                catch
                {

                }

            }

            retval.GearType = gear.type;
            retval.EquipmentCategory = GetEquipmentCategory(gear);
            retval.ItemCode = node.Text.Replace(".img", "");

            if (Gear.IsWeapon(gear.type) == true)
            {
                retval.WeaponConst = GetWeaponConst(gear);
            }

            MemoryStream ms = new MemoryStream();

            if (gear.Icon.OutLink?.Length > 0)
            {
                string itemCode = GetItemCodeByOutLink(gear.Icon.OutLink);
                var image = node.ParentNode.GetImage(itemCode);
                if(image == null)
                {
                    return null;
                }
                gear = Gear.CreateFromNode(image.Node, PluginManager.FindWz);
            }

            gear.Icon.Bitmap.MakeTransparent();
            gear.Icon.Bitmap.Save(ms, ImageFormat.Png);
            retval.Image = ms.ToArray();

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
                case GearType.magicGauntlet:
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

        public static EEquipmentCategory GetEquipmentCategory(Gear gear)
        {
            EEquipmentCategory retval = EEquipmentCategory.Ring;

            switch (gear.type)
            {
                case GearType.cap:
                    retval = EEquipmentCategory.Cap;
                    break;
                case GearType.ring:
                    retval = EEquipmentCategory.Ring;
                    break;
                case GearType.pocket:
                    retval = EEquipmentCategory.Pocket;
                    break;
                case GearType.pendant:
                    retval = EEquipmentCategory.Pendant;
                    break;
                case GearType.eyeAccessory:
                    retval = EEquipmentCategory.Eye;
                    break;
                case GearType.cape:
                    retval = EEquipmentCategory.Cape;
                    break;
                case GearType.coat:
                    retval = EEquipmentCategory.Coat;
                    break;
                case GearType.longcoat:
                    retval = EEquipmentCategory.Longcoat;
                    break;
                case GearType.pants:
                    retval = EEquipmentCategory.Pants;
                    break;
                case GearType.shoes:
                    retval = EEquipmentCategory.Shoes;
                    break;
                case GearType.emblem:
                    retval = EEquipmentCategory.Emblem;
                    break;
                case GearType.weapon:
                    retval = EEquipmentCategory.Weapon;
                    break;
                case GearType.subWeapon:
                    retval = EEquipmentCategory.SubWeapon;
                    break;
                case GearType.android:
                    retval = EEquipmentCategory.Android;
                    break;
                case GearType.faceAccessory:
                    retval = EEquipmentCategory.Face;
                    break;
                case GearType.belt:
                    retval = EEquipmentCategory.Belt;
                    break;
                case GearType.medal:
                    retval = EEquipmentCategory.Medal;
                    break;
                case GearType.badge:
                    retval = EEquipmentCategory.Badge;
                    break;
                case GearType.earrings:
                    retval = EEquipmentCategory.Ear;
                    break;
                case GearType.shoulderPad:
                    retval = EEquipmentCategory.Shoulder;
                    break;
                case GearType.glove:
                    retval = EEquipmentCategory.Glove;
                    break;
                case GearType.machineHeart:
                    retval = EEquipmentCategory.Heart;
                    break;
            }

            return retval;
        }

        public static EEquipmentCategory ToEquipmentCategory(this GearType type)
        {
            EEquipmentCategory retval = EEquipmentCategory.Ring;

            if(Gear.IsLeftWeapon(type) == true)
            {
                return EEquipmentCategory.Weapon;
            }

            switch (type)
            {
                case GearType.cap:
                    retval = EEquipmentCategory.Cap;
                    break;
                case GearType.ring:
                    retval = EEquipmentCategory.Ring;
                    break;
                case GearType.pocket:
                    retval = EEquipmentCategory.Pocket;
                    break;
                case GearType.pendant:
                    retval = EEquipmentCategory.Pendant;
                    break;
                case GearType.eyeAccessory:
                    retval = EEquipmentCategory.Eye;
                    break;
                case GearType.cape:
                    retval = EEquipmentCategory.Cape;
                    break;
                case GearType.coat:
                    retval = EEquipmentCategory.Coat;
                    break;
                case GearType.longcoat:
                    retval = EEquipmentCategory.Longcoat;
                    break;
                case GearType.pants:
                    retval = EEquipmentCategory.Pants;
                    break;
                case GearType.shoes:
                    retval = EEquipmentCategory.Shoes;
                    break;
                case GearType.emblem:
                    retval = EEquipmentCategory.Emblem;
                    break;
                case GearType.weapon:
                    retval = EEquipmentCategory.Weapon;
                    break;
                case GearType.subWeapon:
                    retval = EEquipmentCategory.SubWeapon;
                    break;
                case GearType.android:
                    retval = EEquipmentCategory.Android;
                    break;
                case GearType.faceAccessory:
                    retval = EEquipmentCategory.Face;
                    break;
                case GearType.belt:
                    retval = EEquipmentCategory.Belt;
                    break;
                case GearType.medal:
                    retval = EEquipmentCategory.Medal;
                    break;
                case GearType.badge:
                    retval = EEquipmentCategory.Badge;
                    break;
                case GearType.earrings:
                    retval = EEquipmentCategory.Ear;
                    break;
                case GearType.shoulderPad:
                    retval = EEquipmentCategory.Shoulder;
                    break;
                case GearType.glove:
                    retval = EEquipmentCategory.Glove;
                    break;
                case GearType.machineHeart:
                    retval = EEquipmentCategory.Heart;
                    break;
            }

            return retval;
        }
    }
}
