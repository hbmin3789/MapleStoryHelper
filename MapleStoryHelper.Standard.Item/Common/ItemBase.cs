using Newtonsoft.Json;
using Prism.Mvvm;
using System;

namespace MapleStoryHelper.Standard.Item
{
    public class ItemBase : BindableBase , ICloneable
    {
        #region Property

        private EItemCategory _itemCategory = EItemCategory.Etc;
        public EItemCategory ItemCategory 
        {
            get => _itemCategory;
            set => SetProperty(ref _itemCategory, value);
        }

        private string _name = "";
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _imgSrc = "";
        public string ImgSrc
        {
            get => _imgSrc;
            set => SetProperty(ref _imgSrc, value);
        }

        private string _itemCode = "";
        public string ItemCode
        {
            get => _itemCode;
            set => SetProperty(ref _itemCode, value);
        }

        
        private object _imgBitmapSource;
        [JsonIgnore]
        public object ImgBitmapSource
        {
            get => _imgBitmapSource;
            set => SetProperty(ref _imgBitmapSource, value);
        }

        private byte[] _imgByte;
        public byte[] ImgByte
        {
            get => _imgByte;
            set => SetProperty(ref _imgByte, value);
        }

        private bool _isCash = false;
        public bool IsCash
        {
            get => _isCash;
            set => SetProperty(ref _isCash, value);
        }

        #endregion

        #region Constructor

        public ItemBase()
        {
                        
        }

        public ItemBase(string itemname)
        {
            Name = itemname;
        }

        public ItemBase(EItemCategory category)
        {
            ItemCategory = category;
        }

        public ItemBase(string itemname, EItemCategory category)
        {
            Name = itemname;
            ItemCategory = category;
        }

        public ItemBase(string itemname, EItemCategory category, string imgSrc)
        {
            Name = itemname;
            ItemCategory = category;
            ImgSrc = imgSrc;
        }

        public ItemBase(ItemBase item)
        {
            ItemCategory = item.ItemCategory;
            Name = item.Name;
            ImgSrc = item.ImgSrc;
            ItemCode = item.ItemCode;
            IsCash = item.IsCash;
            ImgBitmapSource = item.ImgBitmapSource;
            ImgByte = item.ImgByte;
        }

        #endregion
        

        public virtual object Clone()
        {
            ItemBase retval = new ItemBase();

            retval.ImgBitmapSource = this.ImgBitmapSource;
            retval.ImgSrc = this.ImgSrc;
            retval.IsCash = this.IsCash;
            retval.ItemCategory = this.ItemCategory;
            retval.ItemCode = this.ItemCode;
            retval.Name = this.Name;
            retval.ImgByte = this.ImgByte;

            return retval;
        }
    }
}
