using MapleStoryHelper.Standard.Resources.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MapleStoryHelper.Standard.Resources
{
    public class MHResourceManager
    {
        public static List<MHResource> GetRingList()
        {
            List<MHResource> retval = new List<MHResource>();

            var imageDatas = GetRingResourceList();
            for(int i = 0; i < imageDatas.Count; i++)
            {
                MHResource newItem = new MHResource();

                newItem.ImageData = imageDatas[i];

                retval.Add(newItem);
            }

            return retval;
        }

        private static List<byte[]> GetRingResourceList()
        {
            List<byte[]> retval = new List<byte[]>();

            var type = typeof(Properties.MapleStoryHelperResource);
            var attributes = type.GetCustomAttribute(typeof(ResourceNameAttribute));
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);

            for(int i = 0; i < properties.Length; i++)
            {
                if(properties[i].Name.Contains("Item_") == true &&
                   properties[i].Name.Contains("Ring") == true)
                {
                    retval.Add(properties[i].GetValue(null) as byte[]);
                }
            }

            return retval;
        }
    }
}
