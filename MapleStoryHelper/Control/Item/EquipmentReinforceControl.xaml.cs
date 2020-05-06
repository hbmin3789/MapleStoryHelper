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
        ObservableCollection<PotentialItem> PotentialItems = new ObservableCollection<PotentialItem>();
        ObservableCollection<PotentialItem> AdditionalItems = new ObservableCollection<PotentialItem>();

        private class PotentialItem
        {
            public string Display { get; set; }
            public PotentialItem(string s)
            {
                Display = s;
            }
        }

        public EquipmentReinforceControl()
        {
            this.InitializeComponent();
            InitPotentialListView();
        }

        private void InitPotentialListView()
        {
            lvPotential.ItemsSource = PotentialItems;
            lvAdditionalPotential.ItemsSource = AdditionalItems;
            InitBasePotential();
        }



        private void InitBasePotential()
        {
            PotentialItems.Add(new PotentialItem("STR%"));
            PotentialItems.Add(new PotentialItem("DEX%"));
            PotentialItems.Add(new PotentialItem("INT%"));
            PotentialItems.Add(new PotentialItem("LUK%"));
            PotentialItems.Add(new PotentialItem("HP%"));
            PotentialItems.Add(new PotentialItem("MP%"));
            PotentialItems.Add(new PotentialItem("STR"));
            PotentialItems.Add(new PotentialItem("DEX"));
            PotentialItems.Add(new PotentialItem("INT"));
            PotentialItems.Add(new PotentialItem("LUK"));
            PotentialItems.Add(new PotentialItem("HP"));
            PotentialItems.Add(new PotentialItem("MP"));

            AdditionalItems.Add(new PotentialItem("STR%"));
            AdditionalItems.Add(new PotentialItem("DEX%"));
            AdditionalItems.Add(new PotentialItem("INT%"));
            AdditionalItems.Add(new PotentialItem("LUK%"));
            AdditionalItems.Add(new PotentialItem("HP%"));
            AdditionalItems.Add(new PotentialItem("MP%"));
            AdditionalItems.Add(new PotentialItem("STR"));
            AdditionalItems.Add(new PotentialItem("DEX"));
            AdditionalItems.Add(new PotentialItem("INT"));
            AdditionalItems.Add(new PotentialItem("LUK"));
            AdditionalItems.Add(new PotentialItem("HP"));
            AdditionalItems.Add(new PotentialItem("MP"));
        }
    }
}
