using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Resources.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MapleStoryHelper.Standard.Resources
{
    public class MHResourceManager
    {
        /// <summary>
        /// 장비 아이템의 정보를 불러옵니다.(이름, 이미지, 스테이터스 등)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="category">장비아이템 카테고리</param>
        /// <returns></returns>
        public static List<EquipmentItem> GetEquipmentList(EEquipmentCategory category)
        {
            List<EquipmentItem> retval = new List<EquipmentItem>();

            AddInfoToList(ref retval, category);

            return retval;
        }

        private static void AddInfoToList(ref List<EquipmentItem> retval, EEquipmentCategory category)
        {
            var imgList = GetEquipmentImageList(category);

            var resType = typeof(Properties.MapleStoryHelperResource);
            var properties = resType.GetProperties(BindingFlags.Public | BindingFlags.Static);
            var attributes = GetResourceInfoAttributes(properties);

            int idx = 0;

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name.Contains("Item_") == true &&
                    attributes?[i]?.Category == category)
                {
                    EquipmentItem newItem = MHXmlReader.GetEquipmentInfo(attributes[i].ItemCode, category);

                    newItem.ImgByte = imgList[idx];
                    newItem.EquipmentCategory = category;
                    newItem.Name = attributes[i].ResourceName;
                    newItem.ItemCode = attributes[i].ItemCode;

                    retval.Add(newItem);
                    idx++;
                }
            }
        }

        private static List<byte[]> GetEquipmentImageList(EEquipmentCategory category)
        {
            List<byte[]> retval = new List<byte[]>();

            var resType = typeof(Properties.MapleStoryHelperResource);
            var properties = resType.GetProperties(BindingFlags.Public | BindingFlags.Static);

            for (int i = 0; i < properties.Length; i++)
            {
                var attribute = GetResourceNameAttribute(properties[i]);

                if (properties[i].Name.Contains("Item_") == true &&
                    attribute?.Category == category)
                {
                    retval.Add(properties[i].GetValue(null) as byte[]);
                }
            }

            return retval;
        }

        #region Attribute

        private static List<ResourceInfoAttribute> GetResourceInfoAttributes(IEnumerable<PropertyInfo> propertyInfo)
        {
            var retval = new List<ResourceInfoAttribute>();

            for (int i = 0; i < propertyInfo.Count(); i++)
            {
                var newItem = GetResourceNameAttribute(propertyInfo.ElementAt(i));
                retval.Add(newItem);
            }

            return retval;
        }

        private static ResourceInfoAttribute GetResourceNameAttribute(PropertyInfo propertyInfo)
        {
            var attrs = propertyInfo.GetCustomAttributes().ToList();

            for (int i = 0; i < attrs.Count(); i++)
            {
                if (attrs[i] is ResourceInfoAttribute)
                {
                    return attrs[i] as ResourceInfoAttribute;
                }
            }

            return null;
        }

        #endregion
    }
}
