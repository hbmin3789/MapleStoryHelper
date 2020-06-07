using MapleStoryHelper.Common;
using MapleStoryHelper.Converter;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Common;
using Microsoft.Xaml.Interactions.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234238에 나와 있습니다.

namespace MapleStoryHelper.View
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class CharacterAddPage : Page
    {
        public CharacterAddPage()
        {
            this.InitializeComponent();
            OnLoaded();
        }

        private void OnLoaded()
        {
            InitComboBox();
            
        }

        private void InitComboBox()
        {
            var items = Enum.GetValues(typeof(ECharacterJob));
            ECharacterJobToStringConverter converter = new ECharacterJobToStringConverter();

            for (int i = 0; i < items.Length; i++)
            {

                ComboBoxItem newItem = new ComboBoxItem();

                if((ECharacterJob)items.GetValue(i) == ECharacterJob.All)
                {
                    continue;
                }

                newItem.Content = converter.Convert(items.GetValue(i), null, null, null).ToString();

                cbCharacterJob.Items.Add(newItem);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null)
            {
                this.DataContext = e.Parameter;
            }
        }


        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool result = false;

            var messageDialog = new MessageDialog("이대로 저장할까요?");

            messageDialog.Commands.Add(new UICommand("저장", new UICommandInvokedHandler(c =>
            {
                result = true;
            })));
            messageDialog.Commands.Add(new UICommand("취소", new UICommandInvokedHandler(c =>
            {
                result = false;
            })));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();

            if (result == true)
            {
                App.mapleStoryHelperViewModel.AddCharacter();
                var ContentFrame = Window.Current.Content as Frame;
                ContentFrame.Navigate(typeof(MainPage), null, new DrillInNavigationTransitionInfo());
            }
        }

        private async void btnSetImagePath_Click(object sender, RoutedEventArgs e)
        {
            btnSetImagePath.IsEnabled = false;
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                var character = this.DataContext as Character;

                character.ImageSrc = file.Path;

                var imageData = await character.CharacterImage.ImageData.LoadImage();
                imgCharacter.Source = imageData;
            }
            else
            {

            }

            btnSetImagePath.IsEnabled = true;
        }

        

        private void btnItemSetting_Click(object sender, RoutedEventArgs e)
        {
            var ContentFrame = Window.Current.Content as Frame;
            ContentFrame.Navigate(typeof(ItemSettingPage), this.DataContext, new DrillInNavigationTransitionInfo());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbCharacterJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(cbCharacterJob.SelectedItem == null)
            {
                gdSpecSetting.Visibility = Visibility.Collapsed;
            }
            else
            {
                gdSpecSetting.Visibility = Visibility.Visible;
            }

            Character character = this.DataContext as Character;

            var job = (ECharacterJob)(cbCharacterJob.SelectedIndex);
            if (job == ECharacterJob.Xenon)
            {
                character = this.DataContext as Xenon;
            }

            character.CharacterJob = job;
        }
    }
}
