using MapleStoryHelper.Converter;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Database;
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
            InitControl();
            InitComboBox();
        }

        private void InitControl()
        {
            //캐릭터 수정때 DataContext를 설정해주기 위해 함수로 뺐음.
            SetCharacter(App.mapleStoryHelperViewModel.NewCharacterItem);
        }

        private void InitComboBox()
        {
            var items = Enum.GetValues(typeof(ECharacterJob));
            ECharacterJobToStringConverter converter = new ECharacterJobToStringConverter();

            for (int i = 0; i < items.Length; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();

                newItem.Content = converter.Convert(items.GetValue(i), null, null, null).ToString();

                cbCharacterJob.Items.Add(newItem);
            }
        }

        public void SetCharacter(Character character)
        {
            this.DataContext = character;
            ctrlStatusDisplay.DataContext = character;
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
                App.mapleStoryHelperViewModel.AddCharacter(result);
                this.Visibility = Visibility.Collapsed;
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
                var character = App.mapleStoryHelperViewModel.NewCharacterItem;

                character.ImageSrc = file.Path;
                character.CharacterImage = MHDBManager.GetResource(character);

                var imageData = await LoadImage(character.CharacterImage.ImageData);
                imgCharacter.Source = imageData;
            }
            else
            {

            }

            btnSetImagePath.IsEnabled = true;
        }

        private async Task<BitmapImage> LoadImage(byte[] imageData)
        {
            InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();

            DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0));

            writer.WriteBytes(imageData);
            await writer.StoreAsync();

            var image = new BitmapImage();
            await image.SetSourceAsync(stream);
            return image;
        }

        private void btnItemSetting_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(ItemSettingPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}
