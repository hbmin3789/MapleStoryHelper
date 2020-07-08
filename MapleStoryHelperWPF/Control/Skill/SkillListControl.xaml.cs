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

namespace MapleStoryHelperWPF.Control
{
    /// <summary>
    /// SkillListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SkillListControl : UserControl
    {
        public SkillListControl()
        {
            InitializeComponent();
            Loaded += SkillListControl_Loaded;
        }

        private void SkillListControl_Loaded(object sender, RoutedEventArgs e)
        {
            App.Skills = App.mapleWz.GetSkills();
            lvSkill.ItemsSource = App.Skills;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var skills = App.Skills.Where(x=>x.SkillName.Contains(tbKeyWord.Text));
            lvSkill.ItemsSource = skills;
        }
    }
}
