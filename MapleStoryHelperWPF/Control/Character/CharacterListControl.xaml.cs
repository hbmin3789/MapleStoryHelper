using System;
using System.Windows;
using System.Windows.Controls;

namespace MapleStoryHelperWPF.Control
{
    /// <summary>
    /// CharacterListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CharacterListControl : UserControl
    {
        public CharacterListControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.viewModel;
        }

        private void lvCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvCharacter.SelectedIndex == -1)
            {
                return;
            }

            NavigateToCharacterSetting(lvCharacter.SelectedItem as MapleStoryHelper.Standard.Character.Model.Character);


            lvCharacter.SelectedIndex = -1;
        }

        private void NavigateToCharacterSetting(object dataContext)
        {
            ctrlCharacterAdd.Visibility = Visibility.Visible;
            ctrlCharacterAdd.SetDataContext(dataContext);
        }

        private void btnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            lvCharacter.SelectedIndex = -1;
            NavigateToCharacterSetting(App.viewModel.NewCharacter);
        }

        private void btnSetUnion_Click(object sender, RoutedEventArgs e)
        {
            ctrlUnion.Visibility = Visibility.Visible;
            App.UpdateBinding();
        }

        private void btnDamageCalc_Click(object sender, RoutedEventArgs e)
        {
            ctrlDamage.Visibility = Visibility.Visible;
        }
    }
}
