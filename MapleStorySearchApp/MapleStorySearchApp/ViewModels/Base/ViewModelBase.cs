using MapleStoryHelper.Standard.MNetwork;
using MapleStorySearchApp.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStorySearchApp.ViewModels
{
    public delegate void SendMessageHandler(string message);
    public class ViewModelBase : BindableBase
    {
        protected static MNetwork networkManager = new MNetwork(NetworkInfo.IP);
        public static SendMessageHandler SendMessage;
    }
}
