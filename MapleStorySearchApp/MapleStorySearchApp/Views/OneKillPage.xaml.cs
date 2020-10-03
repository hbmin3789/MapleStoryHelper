using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapleStorySearchApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneKillPage : ContentPage
    {
        public OneKillPage()
        {
            InitializeComponent();
        }

        private async void btnAddMob_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MobSearchPage());
        }

        private async void btnSkillSet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SkillSearchPage());
        }
    }
}