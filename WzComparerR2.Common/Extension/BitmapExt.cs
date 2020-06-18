using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(ptr, bytedata, 0, numbytes);

                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }

        }
    }
}
