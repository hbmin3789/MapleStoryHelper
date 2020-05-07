using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    public class ItemBase : BindableBase , ICloneable
    {
        private string _primaryKey;
        [Key]
        [Column("key")]
        public string PrimaryKey
        {
            get => _primaryKey;
            set => SetPriaryKey(value);
        }

        

        #region Property

        private EItemCategory _itemCategory = EItemCategory.Etc;
        [Column("item_category")]
        public EItemCategory ItemCategory 
        {
            get => _itemCategory;
            set => SetProperty(ref _itemCategory, value);
        }

        private string _name = "";
        [Column("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _imgSrc = "";
        [Column("image_source")]
        public string ImgSrc
        {
            get => _imgSrc;
            set => SetProperty(ref _imgSrc, value);
        }

        private string _itemCode = "";
        [Column("item_code")]
        public string ItemCode
        {
            get => _itemCode;
            set => SetProperty(ref _itemCode, value);
        }

        
        private object _imgBitmapSource;
        [NotMapped]
        public object ImgBitmapSource
        {
            get => _imgBitmapSource;
            set => SetProperty(ref _imgBitmapSource, value);
        }

        private byte[] _imgByte;
        [NotMapped]
        public byte[] ImgByte
        {
            get => _imgByte;
            set => SetProperty(ref _imgByte, value);
        }

        private bool _isCash = false;
        [Column("is_cash")]
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
            PrimaryKey = item.PrimaryKey;
            ItemCategory = item.ItemCategory;
            Name = item.Name;
            ImgSrc = item.ImgSrc;
            ItemCode = item.ItemCode;
            IsCash = item.IsCash;
            ImgBitmapSource = item.ImgBitmapSource;
            ImgByte = item.ImgByte;
        }

        #endregion
        
        
        protected virtual void SetPriaryKey(string value)
        {
            SetProperty(ref _primaryKey, value);
        }

        /// <summary>
        /// PrimaryKey가 새로 부여됩니다.
        /// </summary>
        /// <returns></returns>
        public virtual object Clone()
        {
            ItemBase retval = new ItemBase();

            retval.ImgBitmapSource = this.ImgBitmapSource;
            retval.ImgSrc = this.ImgSrc;
            retval.IsCash = this.IsCash;
            retval.ItemCategory = this.ItemCategory;
            retval.ItemCode = this.ItemCode;
            retval.Name = this.Name;
            retval.PrimaryKey = new Guid().ToString();
            retval.ImgByte = this.ImgByte;

            return retval;
        }
    }
}
