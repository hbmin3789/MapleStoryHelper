using MapleStoryHelper.Control;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.View;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MapleStoryHelper
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            App.mapleStoryHelperViewModel.OnProgress += ActiveProgressRing;
            ctrlCharacterList.OnCharacterEdit += OnCharacterEdit;
            this.DataContext = App.mapleStoryHelperViewModel;
        }

        private void btnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            var ContentFrame = Window.Current.Content as Frame;
            var character = new Character();
            ContentFrame.Navigate(typeof(CharacterAddPage), character, new DrillInNavigationTransitionInfo());
        }

        private void OnCharacterEdit(object sender, CharacterBase character)
        {
            var ContentFrame = Window.Current.Content as Frame;
            ContentFrame.Navigate(typeof(CharacterAddPage), character, new DrillInNavigationTransitionInfo());
        }

        public void ActiveProgressRing(object sender, bool isActive)
        {
            progress.IsActive = isActive;
        }
    }
}
