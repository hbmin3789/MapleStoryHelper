using MapleStoryHelper.Standard;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MapleStoryResourceSavior.Converter
{
    public class StringToEItemCategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (value as ComboBoxItem).Content.ToString();
            EItemCategory retval = EItemCategory.Etc;

            switch (str)
            {
                case "장비":
                    retval = EItemCategory.Equipment;
                    break;
                case "소비":
                    retval = EItemCategory.Consume;
                    break;
                case "기타":
                    retval = EItemCategory.Etc;
                    break;
                case "설치":
                    retval = EItemCategory.Install;
                    break;
                case "캐쉬":
                    retval = EItemCategory.Cash;
                    break;
            }

            return retval;
        }
    }
}
