﻿using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Common;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

        private void InitVariables()
        {
            StringWz = new Wz_Structure();
        }

        public void Load(Wz_Structure wz_String, Wz_Structure wz_Character)
        {
            StringWz = wz_String;
            CharacterWz = wz_Character;
        }

        public List<EquipmentItem> GetEquipmentItems(EEquipmentCategory category,string keyWord)
        {
            List<EquipmentItem> retval = new List<EquipmentItem>();

            var node = GetEquipCategoryNode(category);
            var itemCodes = GetEquipmentItemCodes(node, keyWord);

            retval = GetEquipmentItems(category, itemCodes);

            return retval;
        }

        private Wz_Node GetEquipCategoryNode(EEquipmentCategory category)
        {            
            Wz_Image image = GetImage(StringNode, "Eqp.img");

            var EquipNode = image.Node.FindNodeByPath("Eqp");

            string categoryString = CategoryManager.GetEquipmentCategoryString(category);

            var CategoryNode = EquipNode.FindNodeByPath(categoryString);

            return CategoryNode;
        }

        private List<string> GetEquipmentItemCodes(Wz_Node EquipNode,string keyWord)
        {
            List<string> retval = new List<string>();

            for(int i = 0; i < EquipNode.Nodes.Count; i++)
            {
                var CurNode = EquipNode.Nodes[i];
                string itemName = CurNode.FindNodeByPath("name").Value.ToString();
                
                if (itemName.Contains(keyWord))
                {
                    string itemCode = "0" + CurNode.Text + ".img";
                    retval.Add(itemCode);
                }
            }

            return retval;
        }

        private List<EquipmentItem> GetEquipmentItems(EEquipmentCategory category, List<string> itemCodes)
        {
            List<EquipmentItem> retval = new List<EquipmentItem>();

            string categoryString = CategoryManager.GetEquipmentCategoryString(category);
            var CategoryNode = CharacterNode.FindNodeByPath(categoryString);

            for (int i = 0; i < itemCodes.Count; i++) 
            {
                var image = GetImage(CategoryNode, itemCodes[i]);
                var gear = Gear.CreateFromNode(image.Node, PluginManager.FindWz);
                EquipmentItem newItem = gear.ToEquipmentItem();
                retval.Add(newItem);
            }


            return retval;
        }

        private Wz_Image GetImage(Wz_Node node, string keyWord)
        {
            var imgNode = node.FindNodeByPath(keyWord);
            Wz_Image image;

            if ((image = imgNode.GetValue<Wz_Image>()) == null || !image.TryExtract())
            {
                return null;
            }

            return image;
        }
    }
}
