﻿using MapleStoryHelper.Framework.ResourceManager.Utils;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WzComparerR2.CharaSim;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager.Common
{
    public static class SetItemExMethods
    {
        public static string GetItemParts(this SetItem setItem, Wz_Node stringWzNode)
        {
            StringBuilder sb = new StringBuilder();
            var parts = setItem.ItemIDs.Parts;
            for (int i = 0; i < parts.Count; i++)
            {
                var itemIds = parts[i].Value.ItemIDs;
                foreach(var code in itemIds)
                {
                    if(code.Value == true)
                    {
                        string name = code.Key.GetItemName(stringWzNode);
                        sb.Append(name);
                        sb.Append("\n");
                    }
                }
            }

            return sb.ToString();
        }

        public static string GetItemName(this int itemCode, Wz_Node stringWzNode)
        {
            Wz_Node node = stringWzNode.FindNodeByPath("Eqp.img").GetImage().Node.FindNodeByPath("Eqp");

            string itemCategory = GetItemCategory(itemCode);

            for (int i = 0; i < node.Nodes.Count; i++) 
            {
                if (itemCategory == node.Nodes[i].Text)
                {
                    for (int j = 0; j < node.Nodes[i].Nodes.Count; j++)
                    {
                        if(node.Nodes[i].Nodes[j].Text == itemCode.ToString())
                        {
                            var nameNode = node.Nodes[i].Nodes[j].FindNodeByPath("name");
                            if(nameNode == null)
                            {
                                return null;
                            }

                            return nameNode.Value.ToString();
                        }
                    }
                }
            }

            return null;
        }

        public static string GetItemCategory(this int itemCode)
        {
            GearType type = Gear.GetGearType(itemCode);
            EEquipmentCategory category = type.ToEquipmentCategory();
            return CategoryManager.GetEquipmentCategoryString(category);
        }
    }
}
