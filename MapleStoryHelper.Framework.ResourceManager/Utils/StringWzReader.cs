using MapleStoryHelper.Framework.ResourceManager.Common;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using WzComparerR2.CharaSim;
using WzComparerR2.PluginBase;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager.Utils
{
    public class StringWzReader
    {
        Wz_Structure StringWz;
        Wz_Structure CharacterWz;

        Wz_Node CharacterNode
        {
            get => CharacterWz.WzNode;
        }
        Wz_Node StringNode
        {
            get => StringWz.WzNode;
        }

        public StringWzReader()
        {
            InitVariables();
        }

        #region Initialize

        private void InitVariables()
        {
            StringWz = new Wz_Structure();
        }

        public void Load(Wz_Structure wz_String, Wz_Structure wz_Character)
        {
            StringWz = wz_String;
            CharacterWz = wz_Character;
        }

        #endregion

        public List<EquipmentItem> GetEquipmentItems(EEquipmentCategory category,string keyWord)
        {
            List<EquipmentItem> retval = new List<EquipmentItem>();

            var node = GetEquipCategoryNode(category);
            List<string> itemCodes, itemNames;
            (itemCodes, itemNames) = GetEquipmentItemCodes(node, keyWord);

            retval = GetEquipmentItems(category, itemCodes);

            for(int i = 0; i < retval.Count; i++)
            {
                retval[i].Name = itemNames[i];
            }

            return retval;
        }

        private Wz_Node GetEquipCategoryNode(EEquipmentCategory category)
        {            
            Wz_Image image = StringNode.GetImage("Eqp.img");

            var EquipNode = image.Node.FindNodeByPath("Eqp");

            string categoryString = CategoryManager.GetEquipmentCategoryString(category);

            var CategoryNode = EquipNode.FindNodeByPath(categoryString);

            return CategoryNode;
        }

        private (List<string>,List<string>) GetEquipmentItemCodes(Wz_Node EquipNode,string keyWord)
        {
            List<string> retval = new List<string>();
            List<string> retvalName = new List<string>();

            for(int i = 0; i < EquipNode.Nodes.Count; i++)
            {
                var CurNode = EquipNode.Nodes[i];
                string itemName = "";
                itemName = CurNode.FindNodeByPath("name")?.Value.ToString();
                if (itemName != null && itemName.Contains(keyWord))
                {
                    string itemCode = "0" + CurNode.Text + ".img";
                    retval.Add(itemCode);
                    retvalName.Add(itemName);
                }
            }

            return (retval,retvalName);
        }

        private List<EquipmentItem> GetEquipmentItems(EEquipmentCategory category, List<string> itemCodes)
        {
            List<EquipmentItem> retval = new List<EquipmentItem>();

            string categoryString = CategoryManager.GetEquipmentCategoryString(category);
            var CategoryNode = CharacterNode.FindNodeByPath(categoryString);
            for (int i = 0; i < itemCodes.Count; i++)
            {
                try
                {
                    var image = CategoryNode.GetImage(itemCodes[i]);
                    var imageNode = CategoryNode.FindNodeByPath(itemCodes[i]);
                    var gear = Gear.CreateFromNode(image.Node, PluginManager.FindWz);
                    EquipmentItem newItem = gear.ToEquipmentItem(imageNode);
                    retval.Add(newItem);
                }
                catch (Exception e)
                {

                }
            }
            


            return retval;
        }
    }
}
