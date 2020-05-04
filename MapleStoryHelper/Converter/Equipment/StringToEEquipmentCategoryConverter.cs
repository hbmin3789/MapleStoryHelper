using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MapleStoryHelper.Converter.Equipment
{
    public class StringToEEquipmentCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string val = value.ToString();

            switch (val)
            {
                case "반지":
                    return EEquipmentCategory.Ring;
                case "포켓":
                    return EEquipmentCategory.Pocket;
                    
                case "펜던트":
                    return EEquipmentCategory.Pendant;
                    
                case "무기":
                    return EEquipmentCategory.Weapon;
                    
                case "벨트":
                    return EEquipmentCategory.Belt;
                    
                case "모자":
                    return EEquipmentCategory.Cap;
                    
                case "얼굴장식":
                    return EEquipmentCategory.Face;
                    
                case "눈장식":
                    return EEquipmentCategory.Eye;
                    
                case "상의":
                    return EEquipmentCategory.Clothes;
                    
                case "하의":
                    return EEquipmentCategory.Pants;
                    
                case "신발":
                    return EEquipmentCategory.Shoes;
                    
                case "귀고리":
                    return EEquipmentCategory.Ear;
                    
                case "어깨장식":
                    return EEquipmentCategory.Shoulder;
                    
                case "장갑":
                    return EEquipmentCategory.Gloves;
                case "안드":
                    return EEquipmentCategory.Android;
                case "엠블럼":
                    return EEquipmentCategory.Emblem;
                case "뱃지":
                    return EEquipmentCategory.Badge;
                case "칭호":
                    return EEquipmentCategory.Medal;
                case "보조무기":
                    return EEquipmentCategory.SubWeapon;
                case "망토":
                    return EEquipmentCategory.Cape;
                case "하트":
                    return EEquipmentCategory.Heart;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
