using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager.Common
{
    public static class MobExMethods
    {
        public static string GetMobName(this int code, Wz_Node stringNode)
        {
            var image = stringNode.FindNodeByPath("Mob.img").GetImage();
            var nodes = image.Node.Nodes;
            for (int i = 0; i < nodes.Count; i++)
            {
                try
                {
                    int curCode = Convert.ToInt32(nodes[i].Text.Replace(".img", ""));
                    if(curCode == code)
                    {
                        return nodes[i].Nodes.First().Value.ToString();
                    }
                }
                catch(Exception e)
                {

                }
            }

            return "";
        }

    }
}
