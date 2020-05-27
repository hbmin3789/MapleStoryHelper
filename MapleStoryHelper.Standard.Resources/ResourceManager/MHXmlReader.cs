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

namespace MapleStoryHelper.Standard.Resources
{
    public class MHXmlReader
    {
        public static EquipmentItem GetEquipmentInfo(string Code, EEquipmentCategory category)
        {
            EquipmentItem retval;

            retval = new EquipmentItem();

            if (category == EEquipmentCategory.Weapon)
            {
                retval = new Weapon();

                var resType = typeof(Properties.MapleStoryHelperResource);
                var properties = resType.GetProperties(BindingFlags.Public | BindingFlags.Static);
                for(int i = 0; i < properties.Count(); i++)
                {
                    var attribute = GetResourceNameAttribute(properties[i]);
                    if(attribute is WeaponResourceInfoAttribute &&
                       attribute.ItemCode == Code)
                    {
                        (retval as Weapon).WeaponConst = (attribute as WeaponResourceInfoAttribute).WeaponConst;
                    }
                }
            }

            var xmlList = GetEquipmentXmlList(category);


            for (int i = 0; i < xmlList.Count; i++)
            {
                if (xmlList[i]?.LastChild?.Attributes["name"].Value?.Equals(Code) == true)
                {
                    SetEquipInfo(ref retval, xmlList[i].ChildNodes.Item(0));
                }
                
            }

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

        protected static List<XmlDocument> GetEquipmentXmlList(EEquipmentCategory category)
        {
            List<XmlDocument> retval = new List<XmlDocument>();

            var resType = typeof(Properties.MapleStoryHelperResource);
            var properties = resType.GetProperties(BindingFlags.Public | BindingFlags.Static);

            for (int i = 0; i < properties.Length; i++)
            {
                var attribute = GetResourceNameAttribute(properties[i]);

                if (properties[i].Name.Contains("Xml_") == true &&
                    attribute?.Category == category)
                {
                    XmlDocument newItem = new XmlDocument();
                    newItem.LoadXml(properties[i].GetValue(properties[i]).ToString());
                    retval.Add(newItem);
                }
            }

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
