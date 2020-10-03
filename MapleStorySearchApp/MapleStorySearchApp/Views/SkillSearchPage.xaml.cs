﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapleStorySearchApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillSearchPage : ContentPage
    {
        public SkillSearchPage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}