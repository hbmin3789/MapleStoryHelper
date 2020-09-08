using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Converter
{
    public class EItemCategoryToStringConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            EItemCategory category = (EItemCategory)value;
            string retval = "";

            switch (category)
            {
                case EItemCategory.Etc:
                    retval = "기타";
                    break;
                case EItemCategory.Cash:
                    retval = "캐쉬";
                    break;
                case EItemCategory.Equipment:
                    retval = "장비";
                    break;
                case EItemCategory.Consume:
                    retval = "소비";
                    break;
                case EItemCategory.Install:
                    retval = "설치";
                    break;
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
