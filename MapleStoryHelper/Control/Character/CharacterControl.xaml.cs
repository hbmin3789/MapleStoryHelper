using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MapleStoryHelper.Standard.Character.Model;

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
