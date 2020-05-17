using MapleStoryHelper.Control.Item;
using MapleStoryHelper.Converter.Equipment;
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

            //CoreApplicationView newView = CoreApplication.CreateNewView();
            //int newViewId = 0;

            //await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() => 
            //{
            //    Window.Current.Content = new EquipmentInfoControl();

            //    Window.Current.Activate();

            //    newViewId = ApplicationView.GetForCurrentView().Id;

            //});

            ContentDialog noWifiDialog = new ContentDialog
            {
                Content = new EquipmentInfoControl(),
                CloseButtonText = "Ok"
            };

            ContentDialogResult res = await noWifiDialog.ShowAsync();

            //ContentFrame.Navigate(typeof(EquipmentAddPage), result, new DrillInNavigationTransitionInfo());
        }
    }
}
