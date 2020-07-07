using MapleStoryHelper.Framework.ResourceManager.Common;
using MapleStoryHelper.Standard.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WzComparerR2.CharaSim;
using WzComparerR2.PluginBase;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public partial class MapleWz
    {
        public List<Skill> GetSkills()
        {
            List<Skill> retval = new List<Skill>();

            List<Skill> skills1 = GetDefaultSkills();
            List<Skill> skills2 = GetVSkills1();
            List<Skill> skills3 = GetVSkills2();

            retval = skills1;

            for (int i = 0; i < skills2.Count; i++)
            {
                retval.Add(skills2[i]);
            }

            for (int i = 0; i < skills3.Count; i++)
            {
                retval.Add(skills3[i]);
            }

            return retval;
        }

        private List<Skill> GetDefaultSkills()
        {
            List<Skill> retval = new List<Skill>();

            var nodes = SkillWzStruct.WzNode.Nodes;

            for (int i=0;i< nodes.Count; i++)
            {
                try
                {
                    int code = Convert.ToInt32(nodes[i].Text.Replace(".img", ""));

                    List<Skill> temp = GetSkillsFromJobNode(nodes[i].GetImage().Node);

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

        private List<Skill> GetSkillsFromJobNode(Wz_Node node)
        {
            List<Skill> retval = new List<Skill>();

            var skills = node.FindNodeByPath("skill").Nodes;

            for(int i = 0; i < skills.Count; i++)
            {
                var newItem = Skill.CreateFromNode(skills[i], PluginManager.FindWz);
                retval.Add(newItem);
            }

            return retval;
        }

        private List<Skill> GetVSkills1()
        {
            List<Skill> retval = new List<Skill>();



            return retval;
        }

        private List<Skill> GetVSkills2()
        {
            List<Skill> retval = new List<Skill>();




            return retval;
        }
    }
}
