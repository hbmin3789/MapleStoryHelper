using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace WzComparerR2.Common.Extension
{
    public static class BitmapExt
    {
        public static byte[] ToByteArray(this Bitmap bitmap)
        {
            BitmapData bmpdata = null;

            try
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Png);
                byte[] bytes = stream.ToArray();

                return bytes;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }

        }
    }
}
