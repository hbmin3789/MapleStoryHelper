using MapleStoryHelper.Standard.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryUWPPriceCalc.ViewModel
{
    public class ItemPriceViewModel : ViewModelBase
    {
        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        private ItemBase _selectedItem;
        public ItemBase SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
    }
}
