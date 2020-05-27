using MapleStoryHelper.Control.Item;
using MapleStoryHelper.Converter.Equipment;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace MapleStoryHelper.View
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class ItemSettingPage : Page
    {

        public ItemSettingPage()
        {
            this.InitializeComponent();
        }

        private async void ItemSetting_Button_Click(object sender, RoutedEventArgs e)
        {
            
            var btn = sender as Button;
            var converter = new StringToEEquipmentCategoryConverter();
            var result = converter.Convert(btn.Content, null, null, null);

            var control = new EquipmentInfoControl();
            ECharacterEquipmentCategory category = GetCategory(btn.CommandParameter.ToString());

            await control.InitEquipComboBox(category, this.DataContext as Character);
            control.Category = category;

            ContentDialog noWifiDialog = new ContentDialog
            {
                Content = control,
                CloseButtonText = "취소",
                IsSecondaryButtonEnabled = true,
                SecondaryButtonText = "저장",
                SecondaryButtonCommand = new DelegateCommand<EquipmentInfoControl>(OnItemSave),
                SecondaryButtonCommandParameter = control
            };

            ContentDialogResult res = await noWifiDialog.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var datacontext = (Character)e.Parameter;
            this.DataContext = datacontext;
            ctrlStatusDisplay.DataContext = datacontext.CharacterStatus;
        }

        private void OnItemSave(EquipmentInfoControl control)
        {
            control.OnSaved?.Invoke(this, null);
            var character = (Character)this.DataContext;

            character.CharacterEquipment.EquipList[control.Category] = control.EquipmentItem;

            if (control.Category == ECharacterEquipmentCategory.Weapon)
            {
                var temp = character.CharacterEquipment.EquipList[control.Category];
                character.WeaponConst = (temp as Weapon).WeaponConst;
            }

            UpdateView();
            ctrlStatusDisplay.DataContext = null;
            ctrlStatusDisplay.DataContext = character;
            ctrlStatusDisplay.UpdateLayout();
            
        }

        private void UpdateView()
        {
            var character = (Character)this.DataContext;
            imgRing1.Source = character.CharacterEquipment.EquipList[ECharacterEquipmentCategory.Ring1].ImgBitmapSource as BitmapImage;
            imgRing2.Source = character.CharacterEquipment.EquipList[ECharacterEquipmentCategory.Ring2].ImgBitmapSource as BitmapImage;
            imgRing3.Source = character.CharacterEquipment.EquipList[ECharacterEquipmentCategory.Ring3].ImgBitmapSource as BitmapImage;
            imgRing4.Source = character.CharacterEquipment.EquipList[ECharacterEquipmentCategory.Ring4].ImgBitmapSource as BitmapImage;
            imgPocket.Source = character.CharacterEquipment.EquipList[ECharacterEquipmentCategory.Pocket].ImgBitmapSource as BitmapImage;
            imgWeapon.Source = character.CharacterEquipment.EquipList[ECharacterEquipmentCategory.Weapon].ImgBitmapSource as BitmapImage;
        }

        private ECharacterEquipmentCategory GetCategory(string CommandParameter)
        {
            var values = Enum.GetValues(typeof(ECharacterEquipmentCategory));

            for (int i = 0; i < values.Length; i++)
            {
                if (values.GetValue(i).ToString().Equals(CommandParameter))
                {
                    return (ECharacterEquipmentCategory)values.GetValue(i);
                }
            }

            return ECharacterEquipmentCategory.Ring1;
        }
    }
}
