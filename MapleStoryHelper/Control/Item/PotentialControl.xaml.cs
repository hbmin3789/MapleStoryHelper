using MapleStoryHelper.Model;
using MapleStoryHelper.Standard.Item.Common;
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
    public sealed partial class PotentialControl : UserControl, INotifyPropertyChanged
    {
        #region Proeprty

        private ObservableCollection<string> _potentialItems;
        public ObservableCollection<string> PotentialItems
        {
            get => _potentialItems;
            set
            {
                _potentialItems = value;
                NotifyPropertyChanged(nameof(PotentialItems));
            }
        }


        #endregion

        public PotentialControl()
        {
            this.InitializeComponent();
            InitView();
        }

        #region Initialize

        private void InitView()
        {
            InitVariables();
            InitPotentialListView();
            this.DataContext = this;
        }

        private void InitVariables()
        {
            PotentialItems = new ObservableCollection<string>();
        }

        private void InitPotentialListView()
        {
            AddBasePotential();
        }

        private void AddBasePotential()
        {
            PotentialItems.Add("STR");
            PotentialItems.Add("DEX");
            PotentialItems.Add("INT");
            PotentialItems.Add("LUK");
            PotentialItems.Add("올스탯");
            PotentialItems.Add("HP");
            PotentialItems.Add("MP");

            PotentialItems.Add("STR%");
            PotentialItems.Add("DEX%");
            PotentialItems.Add("INT%");
            PotentialItems.Add("LUK%");
            PotentialItems.Add("올스탯%");
            PotentialItems.Add("HP%");
            PotentialItems.Add("MP%");

            PotentialItems.Add("공격력");
            PotentialItems.Add("마력");

            PotentialItems.Add("공격력%");
            PotentialItems.Add("마력%");

            PotentialItems.Add("데미지%");
            PotentialItems.Add("보스 공격력%");
            PotentialItems.Add("방어력 무시%");
            PotentialItems.Add("크뎀%");
        }

        #endregion

        public List<Potential> GetStatus()
        {
            List<Potential> retval = new List<Potential>(6);

            for(int i = 0; i < ufgPotential.Children.Count; i++)
            {
                if(Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text.Length) == 0)
                {
                    continue;
                }

                var cb = ufgPotential.Children[i] as ComboBox;
                var newItem = new Potential();

                newItem.StatusKind = (Standard.Common.EStatus)cb.SelectedIndex;
                newItem.StatusValue = Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);

                retval.Add(newItem);
            }

            return retval;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
