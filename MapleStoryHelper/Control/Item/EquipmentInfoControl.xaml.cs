using MapleStoryHelper.Common;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 사용자 정의 컨트롤 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234236에 나와 있습니다.

namespace MapleStoryHelper.Control.Item
{
    public sealed partial class EquipmentInfoControl : UserControl
    {
        public EquipmentInfoControl()
        {
            this.InitializeComponent();
        }

        public async Task InitEquipComboBox(EEquipmentCategory category)
        {
            List<EquipmentItem> items = new List<EquipmentItem>();

            var list = MHResourceManager.GetEquipmentList(category);

            for (int i = 0; i < list.Count; i++)
            {
                EquipmentItem newItem = new EquipmentItem();

                newItem = list[i].Clone() as EquipmentItem;
                newItem.ImgBitmapSource = await newItem.ImgByte.LoadImage();

                items.Add(newItem);
            }

            cbItems.ItemsSource = items;
        }

        private void cbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbItems.SelectedItem as EquipmentItem;
            this.DataContext = item;
        }
    }
}
