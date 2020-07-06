using MapleStoryHelper.Standard.MobLib.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.MobLib.Converter
{
    public class EMobCategoryToStringConverter
    {
        public object Convert(object value)
        {
            string retval = "";

            switch ((EMobMapCategory)value)
            {
                case EMobMapCategory.RoadofVanishing:
                    retval = "소멸의 여로";
                    break;
                case EMobMapCategory.ChewChewIsland:
                    retval = "츄츄 아일랜드";
                    break;
                case EMobMapCategory.Lacheln:
                    retval = "레헬른";
                    break;
                case EMobMapCategory.Arcana:
                    retval = "아르카나";
                    break;
                case EMobMapCategory.Morass:
                    retval = "모라스";
                    break;
                case EMobMapCategory.Esfera:
                    retval = "에스페라";
                    break;
            }

            return retval;
        }
    }
}
