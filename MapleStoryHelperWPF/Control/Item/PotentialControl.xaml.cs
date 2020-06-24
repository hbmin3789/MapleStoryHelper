using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Common;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

// 사용자 정의 컨트롤 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234236에 나와 있습니다.

namespace MapleStoryHelperWPF.Control
{
    public partial class PotentialControl : UserControl, INotifyPropertyChanged
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
            InitGrid();
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

        private void InitGrid()
        {
            for(int i = 0; i < 6; i++)
            {
                RowDefinition row = new RowDefinition();
                gdMain.RowDefinitions.Add(row);
            }

            for(int i = 0; i < 6; i++)
            {
                TextBox tb = new TextBox();
                ComboBox cb = new ComboBox();

                cb.ItemsSource = PotentialItems;
                Grid.SetRow(cb, i);

                Grid.SetRow(tb, i);
                Grid.SetColumn(tb, 1);

                gdMain.Children.Add(cb);
                gdMain.Children.Add(tb);
            }
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

            for(int i = 0; i < gdMain.Children.Count; i++)
            {
                if(gdMain.Children[i] is ComboBox)
                {
                    if (Convert.ToInt32((gdMain.Children[i+1] as TextBox).Text.Length) == 0)
                    {
                        continue;
                    }

                    var cb = gdMain.Children[i] as ComboBox;
                    var newItem = new Potential();

                    newItem.StatusKind = (EStatus)cb.SelectedIndex;
                    newItem.StatusValue = Convert.ToInt32((gdMain.Children[i+1] as TextBox).Text);

                    retval.Add(newItem);
                }
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
