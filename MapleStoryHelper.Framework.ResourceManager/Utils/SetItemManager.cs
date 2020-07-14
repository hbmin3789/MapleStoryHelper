using MapleStoryHelper.Framework.ResourceManager.Common;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WzComparerR2.CharaSim;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager.Utils
{
    public class SetItemManager
    {
        private string SetItemImagePath = "SetItemInfo.img";
        public List<SetItem> SetItemOptions { get; set; }

        public SetItemManager()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            SetItemOptions = new List<SetItem>();
        }

        public void SetItemList(Wz_Node EtcNode, Wz_Node ItemNode)
        {
            var SetItemImage = EtcNode.GetImage(SetItemImagePath);
            var SetItemNode = SetItemImage.Node;

            var ItemImage = ItemNode.Nodes["ItemOption.img"].GetImage();

            for (int i = 0; i < SetItemNode.Nodes.Count; i++)
            {
                SetItem setList = SetItem.CreateFromNode(SetItemNode.Nodes[i], ItemImage.Node);
                SetItemOptions.Add(setList);
            }
        }
    }
}
