using MapleStoryHelper.Standard.MobLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WzComparerR2;
using WzComparerR2.CharaSim;
using WzComparerR2.PluginBase;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public partial class MapleWz
    {
        public List<Mob> GetMobs(EMobMapCategory category)
        {
            List<Mob> retval = new List<Mob>();

            List<Wz_Node> nodes = GetMobNodes(category);
            retval = GetMobsFromNodes(nodes);

            return retval;
        }

        private List<Wz_Node> GetMobNodes(EMobMapCategory category)
        {
            var retval = new List<Wz_Node>();
            int CategoryCode = (int)category;
            var nodes = MobWzStruct.WzNode.Nodes;

            for(int i = 0; i < nodes.Count; i++)
            {
                var MobName = nodes[i].Text.Replace(".img", "");
                int MobCode = Convert.ToInt32(MobName);
                if(MobCode / 100 == CategoryCode)
                {
                    retval.Add(nodes[i]);
                }
            }

            return retval;
        }

        private List<Mob> GetMobsFromNodes(List<Wz_Node> nodes)
        {
            List<Mob> retval = new List<Mob>();

            for(int i = 0; i < nodes.Count; i++)
            {
                Mob newItem = Mob.CreateFromNode(nodes[i], PluginManager.FindWz);
                if(newItem != null)
                {
                    retval.Add(newItem);
                }
            }

            return retval;
        }
    }
}
