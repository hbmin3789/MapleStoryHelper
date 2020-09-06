using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.MNetwork;
using MapleStorySearchApp.Services;
using MapleStorySearchApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MapleStorySearchApp.ViewModels
{
    public class ItemSearchViewModel : BindableBase
    {
        ItemSearchService itemSearch;

        private ObservableCollection<EquipmentItem> _equipmentItems;
        public ObservableCollection<EquipmentItem> EquipmentItems
        {
            get => _equipmentItems;
            set => SetProperty(ref _equipmentItems, value);
        }

        private string _keyWord;
        public string KeyWord
        {
            get => _keyWord;
            set => SetProperty(ref _keyWord, value);
        }

        public DelegateCommand SearchCommand { get; set; }

        public ItemSearchViewModel()
        {
            InitVariables();
            InitCommands();
        }

        private void InitVariables()
        {
            itemSearch = new ItemSearchService();
        }

        private void InitCommands()
        {
            SearchCommand = new DelegateCommand(Search);
        }

        private async void Search()
        {
            var result = await itemSearch.SearchItem(KeyWord);
            if(result == null)
            {
                return;
            }

            EquipmentItems = new ObservableCollection<EquipmentItem>(result);
        }
    }
}
