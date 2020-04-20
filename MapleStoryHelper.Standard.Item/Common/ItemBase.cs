using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    public class ItemBase : BindableBase
    {
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

        private string _imgCode = "";
        [Column("image_code")]
        public string ImgCode
        {
            get => _imgCode;
            set => SetProperty(ref _imgCode, value);
        }

        private bool _isCash;
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

        #endregion
    }
}
