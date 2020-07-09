using MapleStoryHelper.Framework.ResourceManager.Common;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.SkillLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WzComparerR2.CharaSim;
using WzComparerR2.Common.Extension;
using WzComparerR2.PluginBase;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public partial class MapleWz
    {
        public List<SkillBase> GetSkills()
        {
            List<SkillBase> retval = new List<SkillBase>();

            List<SkillBase> skills1 = GetDefaultSkills();
            List<SkillBase> skills2 = GetVSkills1();
            List<SkillBase> skills3 = GetVSkills2();

            retval = skills1;

            for (int i = 0; i < skills2.Count; i++)
            {
                retval.Add(skills2[i]);
            }

            for (int i = 0; i < skills3.Count; i++)
            {
                retval.Add(skills3[i]);
            }

            LoadImage(ref retval);
            LoadText(ref retval);

            return retval;
        }

        private void LoadText(ref List<SkillBase> retval)
        {
            var img = StringWzStruct.WzNode.Nodes["Skill.img"].GetImage();

            for (int i=0; i < retval.Count; i++)
            {
                try
                {
                    retval[i].SkillName = retval[i].SkillCode.ToSkillName(img.Node);
                }
                catch(Exception e)
                {
                    //retval.Remove(retval[i]);
                }
            }
        }

        private void LoadImage(ref List<SkillBase> retval)
        {
            for(int i = 0; i < retval.Count; i++)
            {
                retval[i].ImgBitmapSource = retval[i].Icon.Bitmap.LoadImage();
            }
        }

        private List<SkillBase> GetDefaultSkills()
        {
            List<SkillBase> retval = new List<SkillBase>();

            var nodes = SkillWzStruct.WzNode.Nodes;

            for (int i=0;i< nodes.Count; i++)
            {
                try
                {
                    List<SkillBase> temp = GetSkillsFromJobNode(nodes[i].GetImage().Node);
                    if(temp == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < temp.Count; j++)
                    {
                        retval.Add(temp[j]);
                    }
                }
                catch(Exception e)
                {

                }
            }

            return retval;
        }

        private List<SkillBase> GetSkillsFromJobNode(Wz_Node node)
        {
            List<SkillBase> retval = new List<SkillBase>();

            var skills = node.FindNodeByPath("skill")?.Nodes;
            if(skills == null)
            {
                return null;
            }

            for (int i = 0; i < skills.Count; i++)
            {
                SkillBase newItem = SkillBase.CreateFromNode(skills[i], PluginManager.FindWz);
                newItem.SkillCode = skills[i].Text;
                retval.Add(newItem);
            }

            return retval;
        }

        private List<SkillBase> GetVSkills1()
        {
            List<SkillBase> retval = new List<SkillBase>();



            return retval;
        }

        private List<SkillBase> GetVSkills2()
        {
            List<SkillBase> retval = new List<SkillBase>();




            return retval;
        }
    }
}
