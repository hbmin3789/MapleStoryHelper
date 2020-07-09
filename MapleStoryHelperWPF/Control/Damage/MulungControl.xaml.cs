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
        public MulungControl()
        {
            InitializeComponent();
        }

        private void btnMainSkill_Click(object sender, RoutedEventArgs e)
        {
            var control = new SkillListControl();
            Window window = new Window();
            window.Content = control;
            window.ShowDialog();
        }
    }
}
