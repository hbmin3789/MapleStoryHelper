using MapleStoryHelper.Standard.Item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WzComparerR2.CharaSim;
using WzComparerR2.PluginBase;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Standard.Resources.ResourceManager
{
    public class WzReader
    {
        public static async Task<List<EquipmentItem>> GetEquipmentItems(string FilePath)
        {
            List<EquipmentItem> retval = new List<EquipmentItem>();

            //Wz_Structure wzSt = new Wz_Structure();

            //wzSt.Load(FilePath);

            //var node = wzSt.WzNode;

            //int temp = 0;

            //string itemCodes = Properties.MapleStoryHelperResource.Txt_ItemCodes.ToString();

            //for (int i = 0; i < node.Nodes.Count; i++)
            //{

            //    if (int.TryParse((node.Nodes[i].Text.Split(new char[] { '.' })[0]), out temp) == true)
            //    {
            //        continue;
            //    }

            //    for (int j = 0; j < node.Nodes[i].Nodes.Count; j++)
            //    {
            //        var equipNode = node.Nodes[i];
            //        EquipmentItem newItem = new EquipmentItem();

            //        string itemCode = equipNode.Nodes[j].Text.Split(new char[] { '.' })[0].Remove(0,1);

            //        if (itemCodes.Contains(itemCode) == false)
            //        {
            //            continue;
            //        }

            //        var imgNode = equipNode.FindNodeByPath(equipNode.Nodes[j].Text);
            //        Wz_Image image;

            //        if ((image = imgNode.GetValue<Wz_Image>()) == null || !image.TryExtract())
            //        {
            //            continue;
            //        }                        

            //        MHXmlReader.SetEquipInfo(ref newItem, imgNode);
            //        newItem.ItemCode = imgNode.Text.Split(new char[] { '.' })[0];
            //        try
            //        {
            //            newItem.ImgBitmapSource = Gear.CreateFromNode(image.Node, PluginManager.FindWz);
            //        }
            //        catch
            //        {
            //            continue;
            //        }

            //        retval.Add(newItem);
            //    }

            //}



            return retval;
        }
    }
}
