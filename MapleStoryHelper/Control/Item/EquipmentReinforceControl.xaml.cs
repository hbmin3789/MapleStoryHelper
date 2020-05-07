using MapleStoryHelper.Model;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<PotentialPower> PotentialItems;
        ObservableCollection<PotentialPower> AdditionalItems;
        ObservableCollection<string> PotentialRankList;
        ObservableCollection<Scroll> ScrollItems;

        public EquipmentReinforceControl()
        {
            this.InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            InitVariables();
            InitPotentialListView();
            InitScrollListBox();
        }

        private void InitVariables()
        {
            PotentialItems = new ObservableCollection<PotentialPower>();
            AdditionalItems = new ObservableCollection<PotentialPower>();
            ScrollItems = new ObservableCollection<Scroll>();
            PotentialRankList = new ObservableCollection<string>();
        }

        private void InitPotentialListView()
        {
            lvPotential.ItemsSource = PotentialItems;
            lvAdditionalPotential.ItemsSource = AdditionalItems;
            cbAdditionalPotentialRank.ItemsSource = PotentialRankList;
            cbPotentialRank.ItemsSource = PotentialRankList;

            AddBasePotential();
            AddPotentialRank();
        }

        private void AddPotentialRank()
        {
            PotentialRankList.Add("레어");
            PotentialRankList.Add("에픽");
            PotentialRankList.Add("유니크");
            PotentialRankList.Add("레전더리");
        }

        private void InitScrollListBox()
        {
            lbScroll.ItemsSource = ScrollItems;
            AddBaseScroll();
        }

        private void AddBasePotential()
        {
            PotentialItems.Add(new PotentialPower("STR%"));
            PotentialItems.Add(new PotentialPower("DEX%"));
            PotentialItems.Add(new PotentialPower("INT%"));
            PotentialItems.Add(new PotentialPower("LUK%"));
            PotentialItems.Add(new PotentialPower("HP%"));
            PotentialItems.Add(new PotentialPower("MP%"));
            PotentialItems.Add(new PotentialPower("STR"));
            PotentialItems.Add(new PotentialPower("DEX"));
            PotentialItems.Add(new PotentialPower("INT"));
            PotentialItems.Add(new PotentialPower("LUK"));
            PotentialItems.Add(new PotentialPower("HP"));
            PotentialItems.Add(new PotentialPower("MP"));

            AdditionalItems.Add(new PotentialPower("STR%"));
            AdditionalItems.Add(new PotentialPower("DEX%"));
            AdditionalItems.Add(new PotentialPower("INT%"));
            AdditionalItems.Add(new PotentialPower("LUK%"));
            AdditionalItems.Add(new PotentialPower("HP%"));
            AdditionalItems.Add(new PotentialPower("MP%"));
            AdditionalItems.Add(new PotentialPower("STR"));
            AdditionalItems.Add(new PotentialPower("DEX"));
            AdditionalItems.Add(new PotentialPower("INT"));
            AdditionalItems.Add(new PotentialPower("LUK"));
            AdditionalItems.Add(new PotentialPower("HP"));
            AdditionalItems.Add(new PotentialPower("MP"));
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
