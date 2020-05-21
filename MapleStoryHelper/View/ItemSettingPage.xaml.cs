﻿using MapleStoryHelper.Control.Item;
using MapleStoryHelper.Converter.Equipment;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            EEquipmentCategory category = GetCategory(btn.CommandParameter.ToString());

            await control.InitEquipComboBox(category);

            ContentDialog noWifiDialog = new ContentDialog
            {
                Content = control,
                CloseButtonText = "Ok"
            };

            ContentDialogResult res = await noWifiDialog.ShowAsync();

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var datacontext = (Character)e.Parameter;
            this.DataContext = datacontext;
        }

        private EEquipmentCategory GetCategory(string CommandParameter)
        {
            var values = Enum.GetValues(typeof(EEquipmentCategory));

            for (int i = 0; i < values.Length; i++)
            {
                if (values.GetValue(i).ToString().Equals(CommandParameter))
                {
                    return (EEquipmentCategory)values.GetValue(i);
                }
            }

            return EEquipmentCategory.Ring;
        }
    }
}
