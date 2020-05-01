using MapleStoryHelper.Common;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Resources;
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

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234238에 나와 있습니다.

namespace MapleStoryHelper.View
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class EquipmentAddPage : Page
    {
        public EquipmentAddPage()
        {
            this.InitializeComponent();
            InitComboBox();
        }

        private async void InitComboBox()
        {
            List<EquipmentItem> items = new List<EquipmentItem>();

            var list = MHResourceManager.GetRingList();
            for(int i = 0; i < list.Count; i++)
            {
                EquipmentItem newItem = new EquipmentItem();

                newItem.ImgBitmapSource = await list[i].ImageData.LoadImage();
                items.Add(newItem);
            }

            cbItems.ItemsSource = items;
        }
    }
}