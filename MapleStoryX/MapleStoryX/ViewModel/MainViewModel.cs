using MapleStoryX.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MapleStoryX.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<PageModel> _pageItems;
        public ObservableCollection<PageModel> PageItems
        {
            get => _pageItems;
            set => SetProperty(ref _pageItems, value);
        }

        public MainViewModel()
        {
            InitVariables();
            PageItems.Add(new PageModel() { Description = "스탯을 계산해보세요!", Title="스탯계산" });
        }

        private void InitVariables()
        {
            _pageItems = new ObservableCollection<PageModel>();
        }
    }
}
