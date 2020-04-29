using MapleStoryHelper.Standard.Item.Equipment.Converter;
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

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234238에 나와 있습니다.

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
            SetEquipButtonClickEvents();
        }

        private void SetEquipButtonClickEvents()
        {
            var elements = gdEquipButtons.Children.ToList();
            EquipCategoryStringToEEquipmentCategoryConverter converter = new EquipCategoryStringToEEquipmentCategoryConverter();

            for (int i = 0; i < elements.Count; i++)
            {
                if(elements[i] is Button)
                {
                    var btn = elements[i] as Button;
                    btn.Click += SetEquipment_Click;
                    btn.CommandParameter = converter.Convert(btn.Content, null, null, null);
                }
            }
        }

        

        public void Navigate_EquipmentSettingPage(object parameter)
        {
            ContentFrame.Navigate(typeof(EquipmentSettingPage), parameter, new DrillInNavigationTransitionInfo());
        }



        private void SetEquipment_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            Navigate_EquipmentSettingPage(btn.CommandParameter);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
