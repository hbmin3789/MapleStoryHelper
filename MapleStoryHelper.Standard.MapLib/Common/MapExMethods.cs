using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.MapLib.Common
{
    public static class MapExMethods
    {
        public static string NameOf(this EMapCategory value)
        {
            string retval = "";

            switch (value)
            {
                case EMapCategory.RoadofVanishing:
                    retval = "소멸의 여로";
                    break;
                case EMapCategory.ChewChewIsland:
                    retval = "츄츄 아일랜드";
                    break;
                case EMapCategory.Lacheln:
                    retval = "레헬른";
                    break;
                case EMapCategory.Arcana:
                    retval = "아르카나";
                    break;
                case EMapCategory.Morass:
                    retval = "모라스";
                    break;
                case EMapCategory.Esfera:
                    retval = "에스페라";
                    break;
            }

            return retval;
        }
    }
}
