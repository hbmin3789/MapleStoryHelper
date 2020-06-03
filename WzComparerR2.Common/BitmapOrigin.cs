using System;
using System.Collections.Generic;
using System.Text;
using WzComparerR2.WzLib;
using WzComparerR2.Common;

namespace WzComparerR2
{
    public struct BitmapOrigin
    {
        public static byte[] GetByteArr(Wz_Node node, GlobalFindNodeFunction findNode)
        {
            BitmapOrigin bp = new BitmapOrigin();
            Wz_Uol uol = node.GetValue<Wz_Uol>(null);
            if (uol != null)
            {
                node = uol.HandleUol(node);
            }

            //获取linkNode
            var linkNode = node.GetLinkedSourceNode(findNode);
            Wz_Png png = linkNode?.GetValue<Wz_Png>() ?? (Wz_Png)node.Value;

            return png?.ExtractBitmapImage();
        }
    }
}
