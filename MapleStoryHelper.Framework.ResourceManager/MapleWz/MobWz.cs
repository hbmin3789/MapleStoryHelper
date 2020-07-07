using MapleStoryHelper.Framework.ResourceManager.Common;
using MapleStoryHelper.Standard.MobLib.Common;
using MapleStoryHelper.Standard.MobLib.Model;
using Prism.Modularity;
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
        public List<MobBase> GetMobs(EMobMapCategory category)
        {
            List<MobBase> retval = new List<MobBase>();

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
                try
                {
                    int MobCode = Convert.ToInt32(MobName);
                    if (MobCode / 100 == CategoryCode)
                    {
                        retval.Add(nodes[i]);
                    }
                }
                catch (Exception e)
                {

                }
            }

            return retval;
        }

        private List<MobBase> GetMobsFromNodes(List<Wz_Node> nodes)
        {
            List<MobBase> retval = new List<MobBase>();

            for(int i = 0; i < nodes.Count; i++)
            {
                var image = nodes[i].GetImage();
                Mob mob = Mob.CreateFromNode(image.Node, PluginManager.FindWz);
                if(mob != null)
                {
                    int code = Convert.ToInt32(image.Node.Text.Replace(".img",""));
                    MobBase newItem = MobToMobBase(mob);

                    newItem.ImgBitmapSource = newItem.Default.Bitmap.LoadImage();
                    newItem.MobName = stringWzReader.GetMobName(code);

                    retval.Add(newItem);
                }
            }

            return retval;
        }

        private MobBase MobToMobBase(Mob mob)
        {
            MobBase retval = new MobBase();

            retval.FinalMaxHP = mob.FinalMaxHP;
            retval.MaxHP = mob.MaxHP;
            retval.Boss = mob.Boss;
            retval.Default = mob.Default;
            retval.Defense = 10;

            return retval;
        }
    }
}
