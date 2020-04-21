using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    public class ItemBase : BindableBase
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
        }

        #endregion
        
        
        protected virtual void SetPriaryKey(string value)
        {
            SetProperty(ref _primaryKey, value);
        }
    }
}
