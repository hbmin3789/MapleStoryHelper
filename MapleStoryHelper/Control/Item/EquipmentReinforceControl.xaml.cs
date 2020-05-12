using MapleStoryHelper.Model;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

// 사용자 정의 컨트롤 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234236에 나와 있습니다.

namespace MapleStoryHelper.Control
{
    public sealed partial class EquipmentReinforceControl : UserControl
    {
        public ObservableCollection<Scroll> ScrollItems = new ObservableCollection<Scroll>();

        public EquipmentReinforceControl()
        {
            this.InitializeComponent();

            InitScrollListBox();
        }

        private void InitScrollListBox()
        {
            AddBaseScroll();
        }

        private void AddBaseScroll()
        {
            ScrollItems.Add(new Scroll() { Name = "주문의 흔적", ImageSource = "/Assets/Items/Scroll/Trace.png" });
            ScrollItems.Add(new Scroll() { Name = "혼돈의 주문서", ImageSource = "/Assets/Items/Scroll/Chaos.png" });
            ScrollItems.Add(new Scroll() { Name = "매지컬 주문서", ImageSource = "/Assets/Items/Scroll/Magical.png" });
            ScrollItems.Add(new Scroll() { Name = "프리미엄 스크롤", ImageSource = "/Assets/Items/Scroll/Premium.png" });
        }

        
    }
}
