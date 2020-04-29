using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MapleStoryHelper.Standard.Item.Equipment.Converter
{
    public class EquipCategoryStringToEEquipmentCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string category = value as string;
            EEquipmentCategory retval = EEquipmentCategory.Ring;

            switch (category)
            {
                case "링":
                    retval = EEquipmentCategory.Ring;
                    break;
                case "포켓":
                    retval = EEquipmentCategory.Pocket;
                    break;
                case "펜던트":
                    retval = EEquipmentCategory.Pendant;
                    break;
                case "무기":
                    retval = EEquipmentCategory.Weapon;
                    break;
                case "벨트":
                    retval = EEquipmentCategory.Belt;
                    break;
                case "모자":
                    retval = EEquipmentCategory.Cap;
                    break;
                case "얼굴장식":
                    retval = EEquipmentCategory.Face;
                    break;
                case "눈장식":
                    retval = EEquipmentCategory.Eye;
                    break;
                case "상의":
                    retval = EEquipmentCategory.Clothes;
                    break;
                case "하의":
                    retval = EEquipmentCategory.Pants;
                    break;
                case "신발":
                    retval = EEquipmentCategory.Shoes;
                    break;
                case "귀고리":
                    retval = EEquipmentCategory.Ear;
                    break;
                case "어깨장식":
                    retval = EEquipmentCategory.Shoulder;
                    break;
                case "장갑":
                    retval = EEquipmentCategory.Gloves;
                    break;
                case "안드":
                    retval = EEquipmentCategory.Android;
                    break;
                case "엠블럼":
                    retval = EEquipmentCategory.Emblem;
                    break;
                case "뱃지":
                    retval = EEquipmentCategory.Badge;
                    break;
                case "칭호":
                    retval = EEquipmentCategory.Medal;
                    break;
                case "보조무기":
                    retval = EEquipmentCategory.SubWeapon;
                    break;
                case "망토":
                    retval = EEquipmentCategory.Cape;
                    break;
                case "하트":
                    retval = EEquipmentCategory.Heart;
                    break;
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
