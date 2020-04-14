using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    public class ItemBase : BindableBase
    {
        #region Property

        private EItemCategory _itemCategory = EItemCategory.Etc;
        public EItemCategory ItemCategory 
        {
            get => _itemCategory;
            set => SetProperty(ref _itemCategory, value);
        }

        private string _itemName = "";
        public string ItemName
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        private string _itemImgSrc = "";
        public string ItemImgSrc
        {
            get => _itemImgSrc;
            set => SetProperty(ref _itemImgSrc, value);
        }

        #endregion

        #region Constructor

        public ItemBase()
        {
                        
        }

        public ItemBase(string itemname)
        {
            ItemName = itemname;
        }

        public ItemBase(EItemCategory category)
        {
            ItemCategory = category;
        }

        public ItemBase(string itemname, EItemCategory category)
        {
            ItemName = itemname;
            ItemCategory = category;
        }

        public ItemBase(string itemname, EItemCategory category, string imgSrc)
        {
            ItemName = itemname;
            ItemCategory = category;
            ItemImgSrc = imgSrc;
        }

        #endregion
    }
}
