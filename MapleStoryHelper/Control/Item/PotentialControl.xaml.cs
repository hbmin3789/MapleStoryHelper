using MapleStoryHelper.Model;
using MapleStoryHelper.Standard.Character.Status;
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
            PotentialItems = new ObservableCollection<PotentialPower>();
        }

        private void InitPotentialListView()
        {
            AddBasePotential();
        }

        private void AddBasePotential()
        {
            PotentialItems.Add(new PotentialPower("STR"));
            PotentialItems.Add(new PotentialPower("DEX"));
            PotentialItems.Add(new PotentialPower("INT"));
            PotentialItems.Add(new PotentialPower("LUK"));
            PotentialItems.Add(new PotentialPower("올스탯"));
            PotentialItems.Add(new PotentialPower("HP"));
            PotentialItems.Add(new PotentialPower("MP"));

            PotentialItems.Add(new PotentialPower("STR%"));
            PotentialItems.Add(new PotentialPower("DEX%"));
            PotentialItems.Add(new PotentialPower("INT%"));
            PotentialItems.Add(new PotentialPower("LUK%"));
            PotentialItems.Add(new PotentialPower("올스탯%"));
            PotentialItems.Add(new PotentialPower("HP%"));
            PotentialItems.Add(new PotentialPower("MP%"));

            PotentialItems.Add(new PotentialPower("공격력"));
            PotentialItems.Add(new PotentialPower("마력"));

            PotentialItems.Add(new PotentialPower("공격력%"));
            PotentialItems.Add(new PotentialPower("마력%"));

            PotentialItems.Add(new PotentialPower("데미지%"));
            PotentialItems.Add(new PotentialPower("보스 공격력%"));
            PotentialItems.Add(new PotentialPower("방어력 무시%"));
            PotentialItems.Add(new PotentialPower("크뎀%"));
        }

        #endregion

        public EquipmentStatus GetStatus()
        {
            EquipmentStatus retval = new EquipmentStatus();

            for(int i = 0; i < ufgPotential.Children.Count; i++)
            {
                var cb = ufgPotential.Children[i] as ComboBox;
                switch (cb.SelectedIndex)
                {
                    case 0:
                        retval.PoStr += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 1:
                        retval.PoDex += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 2:
                        retval.PoInt += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 3:
                        retval.PoLuk += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 4:
                        retval.PoAllStatus += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 5:
                        retval.PoHP += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 6:
                        retval.PoMP += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 7:
                        retval.PoPStr += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 8:
                        retval.PoPDex += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 9:
                        retval.PoPInt += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 10:
                        retval.PoPLuk += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 11:
                        retval.PoPAllStatus += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 12:
                        retval.PoPHP += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 13:
                        retval.PoPMP += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 14:
                        retval.PoAttack += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 15:
                        retval.PoMagic += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 16:
                        retval.PoPAttack += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 17:
                        retval.PoPMagic += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 18:
                        retval.PoDamage += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 19:
                        retval.PoBossDamage += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
                    case 20:
                        retval.PoIgnoreDef.Add(Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text));
                        break;
                    case 21:
                        retval.PoCritDamage += Convert.ToInt32((ufgPotentialTextBox.Children[i] as TextBox).Text);
                        break;
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
