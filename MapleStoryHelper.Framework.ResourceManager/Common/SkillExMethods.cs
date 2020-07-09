using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager.Common
{
    public static class SkillExMethods
    {
        public static string ToSkillName(this string skillCode, Wz_Node stringWz)
        {
            string retval = stringWz?.Nodes[skillCode]?.FindNodeByPath("name")?.Value?.ToString(); ;
            if(retval == null)
            {
                return "";
            }
            return retval;
        }
    }
}
