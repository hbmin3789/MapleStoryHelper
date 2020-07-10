﻿using MapleStoryHelper.Standard.SkillLib.Model;
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
        Window window = new Window();

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
                gdSkillInfo.DataContext = skill;
            }
            listview.SelectedIndex = -1;
        }

        public void SetCharacter(object character)
        {
            this.DataContext = character;
            ctrlStatus.SetCharacterStatusDataContext(character);
        }

        private void tbSkill_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if(tb == null)
            {
                return;
            }

            int percent = 0;

            try
            {
                percent = Convert.ToInt32(tb.Text);
            }
            catch
            {
                MessageBox.Show("숫자만 입력해주세요.");
                tb.Text = "0";
            }
            if (tb.Name.Contains("Main"))
            {

            }
            else
            {

            }


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
