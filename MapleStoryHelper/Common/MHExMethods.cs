using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace MapleStoryHelper.Common
{
    public static class MHExMethods
    {
        public static async Task<BitmapImage> LoadImage(this object data)
        {
            if(data is byte[])
            {
                var imageData = data as byte[];
                InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();

                DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0));

                writer.WriteBytes(imageData);
                await writer.StoreAsync();

                var image = new BitmapImage();
                await image.SetSourceAsync(stream);
                return image;
            }

            if(data is BitmapImage)
            {
                return data as BitmapImage;
            }

            return null;
        }
    }
}
