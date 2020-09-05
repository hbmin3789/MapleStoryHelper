using MapleStoryHelper.Standard.MNetwork;
using MapleStorySearchApp.Services;
using MapleStorySearchApp.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStorySearchApp.ViewModels
{
    public class ItemSearchViewModel : BindableBase
    {
        private MNetwork networkManager;

        public ItemSearchViewModel()
        {
            networkManager = new MNetwork(NetworkInfo.IP);
        }
    }
}
