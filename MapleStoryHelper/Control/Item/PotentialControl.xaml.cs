using MapleStoryHelper.Model;
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
    public sealed partial class PotentialControl : UserControl, INotifyPropertyChanged
    {
        #region Proeprty

        private ObservableCollection<PotentialPower> _potentialItems;
        public ObservableCollection<PotentialPower> PotentialItems
        {
            get => _potentialItems;
            set
            {
                _potentialItems = value;
                NotifyPropertyChanged(nameof(PotentialItems));
            }
        }

        private ObservableCollection<PotentialPower> _additionalPotentialItems;
        public ObservableCollection<PotentialPower> AdditionalItems
        {
            get => _additionalPotentialItems;
            set
            {
                _additionalPotentialItems = value;
                NotifyPropertyChanged(nameof(AdditionalItems));
            }
        }
        public ObservableCollection<string> PotentialRankList { get; set; }

        #endregion

        public PotentialControl()
        {
            this.InitializeComponent();
            InitView();
        }


        private void InitView()
        {
            InitVariables();
            InitPotentialListView();
            this.DataContext = this;
        }

        #region Initialize

        private void InitVariables()
        {
            PotentialItems = new ObservableCollection<PotentialPower>();
            AdditionalItems = new ObservableCollection<PotentialPower>();
            PotentialRankList = new ObservableCollection<string>();
        }

        private void InitPotentialListView()
        {
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

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
