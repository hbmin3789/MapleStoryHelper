using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryUWPPriceCalc.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> _menuItems;
        public ObservableCollection<ViewModelBase> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public MainViewModel()
        {
            InitializeVariables();
            InitializeMenuItems();
        }

        private void InitializeVariables()
        {
            _menuItems = new ObservableCollection<ViewModelBase>();
        }

        private void InitializeMenuItems()
        {
            MenuItems.Add(new ItemPriceViewModel());
        }
    }
}
