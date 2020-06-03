using System;
using System.Collections.Generic;
using System.Text;
using WzComparerR2.Common.Extension;

namespace WzComparerR2.CharaSim
{
    public abstract class ItemBase : ICloneable
    {
        public ItemBase()
        {
        }

        public int ItemID { get; set; }
        public BitmapOrigin Icon { get; set; }
        public BitmapOrigin IconRaw { get; set; }
        public BitmapOrigin Sample { get; set; }
        public byte[] byteArr { get; set; }

        public virtual ItemBaseType Type
        {
            get { return (ItemBaseType)(this.ItemID / 1000000); }
        }

        public object IconBitmap()
        {
            object retval = new object();


            return retval;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
