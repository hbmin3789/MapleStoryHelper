using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MapleStorySearchApp.Services;
using MapleStorySearchApp.Views;
using MapleStorySearchApp.ViewModels;

namespace MapleStorySearchApp
{
    public partial class App : Application
    {
        public static SkillSearchViewModel skillSearchViewModel = new SkillSearchViewModel();
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
