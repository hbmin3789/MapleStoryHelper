using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.IO;

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

        private byte[] _image;
        public byte[] Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        private string _itemCode = "";
        public string ItemCode
        {
            get => _itemCode;
            set => SetProperty(ref _itemCode, value);
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

        #endregion
    }
}
