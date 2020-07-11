using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Resources.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Standard.Resources
{
    public class MHXmlReader
    {
        public static EquipmentItem GetEquipmentInfo(string Code, EEquipmentCategory category)
        {
            EquipmentItem retval = new EquipmentItem();

            //var resType = typeof(Properties.MapleStoryHelperResource);
            //var properties = resType.GetProperties(BindingFlags.Public | BindingFlags.Static);
            //for (int i = 0; i < properties.Count(); i++)
            //{
            //    var attribute = GetResourceNameAttribute(properties[i]);
            //    if (attribute is EquipmentResourceInfoAttribute && attribute.ItemCode == Code)
            //    {
            //        (retval as EquipmentItem).JobCategory = (attribute as EquipmentResourceInfoAttribute).JobCategory;
            //    }
            //    if (attribute is WeaponResourceInfoAttribute && attribute.ItemCode == Code)
            //    {
            //        (retval as EquipmentItem).JobCategory = (attribute as WeaponResourceInfoAttribute).JobCategory;
            //        (retval as EquipmentItem).WeaponConst = (attribute as WeaponResourceInfoAttribute).WeaponConst;
            //    }
            //}

            //var xmlList = GetEquipmentXmlList(category);


            //for (int i = 0; i < xmlList.Count; i++)
            //{
            //    if (xmlList[i]?.LastChild?.Attributes["name"].Value?.Equals(Code) == true)
            //    {
            //        SetEquipInfo(ref retval, xmlList[i].ChildNodes.Item(0));
            //    }
                
            //}

            return retval;
        }

        #warning 주석처리 해놓은것은 나중에 추가해야 할 수도 있음
        private static void SetEquipInfo(ref EquipmentItem retval, XmlNode item)
        {
            for (int j = 0; j < item.ChildNodes.Count; j++)
            {
                switch (item?.ChildNodes[j]?.Attributes["name"]?.Value?.ToString())
                {
                    case "reqJob":
                        retval.CharacterCategory = (ECharacterJob)Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "islot":
                        //retval.EquipmentCategory = (EEquipmentCategory)item.ChildNodes[j].Value;
                        break;
                    case "reqLevel":
                        retval.RequiredLevel = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incSTR":
                        retval.Status.Str = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incDEX":
                        retval.Status.Dex = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incINT":
                        retval.Status.Int = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incLUK":
                        retval.Status.Luk= Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incPAD":
                        retval.Status.AttackPower = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incMAD":
                        retval.Status.MagicAttack = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incMHP":
                        retval.Status.HP = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "incMMP":
                        retval.Status.MP = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "tuc":
                        retval.MaxScroll = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                    case "bossReward":
                        //retval. = Convert.ToInt32(item.ChildNodes[j].Value);
                        break;
                    case "setItemID":
                        retval.RequiredLevel = Convert.ToInt32(item.ChildNodes[j].Attributes["value"].Value);
                        break;
                }
            }
        }

        public static bool SetEquipInfo(ref EquipmentItem retval, Wz_Node item)
        {
            Wz_Image image;
            if ((image = item.GetValue<Wz_Image>()) == null || image.TryExtract() == false)
            {
                return false;
            }

            item = image.Node;
            item = item.FindNodeByPath("info");

            if (item == null)
            {
                return false;
            }
            for (int i = 0; i < item?.Nodes?.Count; i++)
            {
                int val = 0;
                if (item.Nodes[i].Value != null)
                {
                    try
                    {
                        val = Convert.ToInt32(item.Nodes[i].Value);
                    }
                    catch
                    {
                        continue;
                    }
                }
                switch (item.Nodes[i].Text)
                {
                    case "reqJob":
                        retval.CharacterCategory = (ECharacterJob)val;
                        break;
                    case "islot":
                        //retval.EquipmentCategory = (EEquipmentCategory)item.Nodes[i].ChildNodes[j].Value;
                        break;
                    case "reqLevel":
                        retval.RequiredLevel = val;
                        break;
                    case "incSTR":
                        retval.Status.Str = val;
                        break;
                    case "incDEX":
                        retval.Status.Dex = val;
                        break;
                    case "incINT":
                        retval.Status.Int = val;
                        break;
                    case "incLUK":
                        retval.Status.Luk = val;
                        break;
                    case "incPAD":
                        retval.Status.AttackPower = val;
                        break;
                    case "incMAD":
                        retval.Status.MagicAttack = val;
                        break;
                    case "incMHP":
                        retval.Status.HP = val;
                        break;
                    case "incMMP":
                        retval.Status.MP = val;
                        break;
                    case "tuc":
                        retval.MaxScroll = val;
                        break;
                    case "bossReward":
                        //retval. = Convert.ToInt32(item.Nodes[i].ChildNodes[j].Value);
                        break;
                    case "imdR":
                        retval.Status.IgnoreDef = val;
                        break;
                    case "bdR":
                        retval.Status.BossDamage = val;
                        break;
                }
            }

            return true;
        }

        public static bool SetEquipInfo(ref EquipmentStruct retval, Wz_Node item)
        {
            Wz_Image image;
            if ((image = item.GetValue<Wz_Image>()) == null || image.TryExtract() == false)
            {
                return false;
            }

            item = image.Node;
            item = item.FindNodeByPath("info");

            if (item == null)
            {
                return false;
            }
            for (int i = 0; i < item?.Nodes?.Count; i++)
            {
                int val = 0;
                if (item.Nodes[i].Value != null)
                {
                    try
                    {
                        val = Convert.ToInt32(item.Nodes[i].Value);
                    }
                    catch
                    {
                        continue;
                    }
                }
                switch (item.Nodes[i].Text)
                {
                    case "reqJob":
                        retval.CharacterCategory = val;
                        break;
                    case "islot":
                        //retval.EquipmentCategory = (EEquipmentCategory)item.Nodes[i].ChildNodes[j].Value;
                        break;
                    case "reqLevel":
                        retval.ReqLevel = val;
                        break;
                    case "incSTR":
                        retval.Str = val;
                        break;
                    case "incDEX":
                        retval.Dex = val;
                        break;
                    case "incINT":
                        retval.Int = val;
                        break;
                    case "incLUK":
                        retval.Luk = val;
                        break;
                    case "incPAD":
                        retval.Attack = val;
                        break;
                    case "incMAD":
                        retval.Magic = val;
                        break;
                    case "incMHP":
                        retval.HP = val;
                        break;
                    case "incMMP":
                        retval.MP = val;
                        break;
                    case "tuc":
                        retval.MaxScroll = val;
                        break;
                    case "bossReward":
                        //retval. = Convert.ToInt32(item.Nodes[i].ChildNodes[j].Value);
                        break;
                    case "imdR":
                        retval.IgnoreDef = val;
                        break;
                }
            }

            return true;
        }

        protected static List<XmlDocument> GetEquipmentXmlList(EEquipmentCategory category)
        {
            List<XmlDocument> retval = new List<XmlDocument>();

            //var resType = typeof(Properties.MapleStoryHelperResource);
            //var properties = resType.GetProperties(BindingFlags.Public | BindingFlags.Static);

            //for (int i = 0; i < properties.Length; i++)
            //{
            //    var attribute = GetResourceNameAttribute(properties[i]);

            //    if (properties[i].Name.Contains("Xml_") == true &&
            //        attribute?.Category == category)
            //    {
            //        XmlDocument newItem = new XmlDocument();
            //        newItem.LoadXml(properties[i].GetValue(properties[i]).ToString());
            //        retval.Add(newItem);
            //    }
            //}

            return retval;
        }

        protected static ResourceInfoAttribute GetResourceNameAttribute(PropertyInfo propertyInfo)
        {
            var attrs = propertyInfo.GetCustomAttributes().ToList();

            for (int i = 0; i < attrs.Count(); i++)
            {
                if (attrs[i] is WeaponResourceInfoAttribute)
                {
                    return attrs[i] as WeaponResourceInfoAttribute;
                }

                if (attrs[i] is ResourceInfoAttribute)
                {
                    return attrs[i] as ResourceInfoAttribute;
                }
            }

            return null;
        }
    }
}
