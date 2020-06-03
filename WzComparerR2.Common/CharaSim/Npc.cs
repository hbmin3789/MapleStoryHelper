using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WzComparerR2.WzLib;

namespace WzComparerR2.CharaSim
{
    public class Npc
    {
        public Npc()
        {
            this.ID = -1;
            //this.Animates = new LifeAnimateCollection();
        }

        public int ID { get; set; }
        public bool Shop { get; set; }

        public int? Link { get; set; }

        public BitmapOrigin Default { get; set; }

        //public LifeAnimateCollection Animates { get; private set; }

        public static Npc CreateFromNode(Wz_Node node, GlobalFindNodeFunction findNode)
        {
            int npcID;
            Match m = Regex.Match(node.Text, @"^(\d{7})\.img$");
            if (!(m.Success && Int32.TryParse(m.Result("$1"), out npcID)))
            {
                return null;
            }

            Npc npcInfo = new Npc();
            npcInfo.ID = npcID;
            Wz_Node infoNode = node.FindNodeByPath("info");

            //加载基础属性
            if (infoNode != null)
            {
                foreach (var propNode in infoNode.Nodes)
                {
                    switch (propNode.Text)
                    {
                        case "shop": npcInfo.Shop = propNode.GetValueEx<int>(0) != 0; break;
                        case "link": npcInfo.Link = propNode.GetValueEx<int>(0); break;
                    }
                }
            }


            return npcInfo;
        }
    }
}
