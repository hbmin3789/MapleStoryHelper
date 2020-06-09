using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MapleStoryHelper.Standard.Converter;
using MapleStoryHelper.Standard.Character;

namespace MapleStoryHelper.Control
{
    public sealed partial class CharacterControl : UserControl
    {
        public EventHandler<CharacterBase> OnCharacterEdit;

        public CharacterControl()
        {
            this.InitializeComponent();
            this.DataContext = App.mapleStoryHelperViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var character = (sender as Button).DataContext as Character;
            OnCharacterEdit?.Invoke(this, character);
        }
    }
}
