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
