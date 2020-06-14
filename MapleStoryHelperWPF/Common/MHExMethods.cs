using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MapleStoryHelperWPF.Common
{
    public static class MHExMethods
    {
        public static async Task<BitmapImage> LoadImage(this object data)
        {
            if (data is byte[])
            {
                if (data == null || (data as byte[]).Length == 0) return null;
                var image = new BitmapImage();
                using (var mem = new MemoryStream(data as byte[]))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }

            if (data is BitmapImage)
            {
                return data as BitmapImage;
            }

            return null;
        }

        public static T DeepCopy<T>(this object data)
        {
            var serialized = JsonConvert.SerializeObject(data);
            T retval = JsonConvert.DeserializeObject<T>(serialized);
            return retval;
        }
    }
}
