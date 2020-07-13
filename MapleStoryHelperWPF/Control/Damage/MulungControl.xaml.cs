using MapleStoryHelper.Standard.DamageLib.Common;
using MapleStoryHelper.Standard.SkillLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapleStoryHelperWPF.Control.Damage
{
    /// <summary>
    /// MulungControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MulungControl : UserControl
    {
        private Window window = new Window();
        private MulungDpm dpm { get; set; }

        private SkillBase MainSkill;

        private int MainPercent = 40;
        private int UltSkillDelay = 180;
        private int CoreReinforce = 120;

        public MulungControl()
        {
            InitializeComponent();
            InitWindow();
            this.DataContext = App.viewModel;
        }

        private void InitWindow()
        {
            window = new Window();
            var control = new SkillListControl();
            window.Content = control;
            control.lvSkill.SelectionChanged += LvSkill_SelectionChanged;
        }

        private void btnMainSkill_Click(object sender, RoutedEventArgs e)
        {
            InitWindow();
            window.ShowDialog();
        }

        private void LvSkill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listview = (sender as ListView);
            if (listview.SelectedIndex == -1)
            {
                return;
            }
            var skill = e.AddedItems[0] as SkillBase;
            if(MessageBox.Show("\"" + skill.SkillName + "\"선택됨", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                window.Close();
            }
            listview.SelectedIndex = -1;

            MainSkill = skill;
            gdSkillInfo.DataContext = MainSkill;
        }

        public void SetCharacter(object character)
        {
            var ch = character as MapleStoryHelper.Standard.Character.Model.Character;
            this.DataContext = null;
            this.DataContext = character;
            ctrlStatus.SetCharacterStatusDataContext(character);
            dpm = new MulungDpm(ch);
        }

        private void tbSkill_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if(tb == null)
            {
                return;
            }

            try
            {
                MainPercent = Convert.ToInt32(tb.Text);
            }
            catch
            {
                MessageBox.Show("숫자만 입력해주세요.");
                tb.Text = "40";
            }
        }

        private void tbCoreReinforce_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
            {
                return;
            }

            try
            {
                CoreReinforce = Convert.ToInt32(tb.Text);
            }
            catch
            {
                MessageBox.Show("숫자만 입력해주세요.");
                tb.Text = "120";
            }
        }

        private void tbDelay_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
            {
                return;
            }

            try
            {
                UltSkillDelay = Convert.ToInt32(tb.Text);
            }
            catch
            {
                MessageBox.Show("숫자만 입력해주세요.");
                tb.Text = "180";
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnCalcMulung_Click(object sender, RoutedEventArgs e)
        {
            int floor = dpm.GetMulungFloor(MainSkill, App.mapleWz.StringWzStruct.WzNode, UltSkillDelay, MainPercent, CoreReinforce);
            MessageBox.Show(floor.ToString());
        }
    }
}
