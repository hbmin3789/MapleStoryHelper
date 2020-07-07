﻿using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WzComparerR2.Common.Extension;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public static class MHExMethods
    {
        public static BitmapImage LoadImage(this object data)
        {
            if(data is Bitmap)
            {
                data = (data as Bitmap).ToByteArray();
            }

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

        public static BitmapImage LoadImage(this string data)
        {
            return new BitmapImage(new Uri(data, UriKind.Relative));
        }

        public static T DeepCopy<T>(this object data)
        {
            var serialized = JsonConvert.SerializeObject(data);
            T retval = JsonConvert.DeserializeObject<T>(serialized);
            return retval;
        }
    }
}
