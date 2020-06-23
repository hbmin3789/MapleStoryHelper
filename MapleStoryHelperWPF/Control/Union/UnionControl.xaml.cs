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

namespace MapleStoryHelperWPF.Control.Union
{
    /// <summary>
    /// UnionControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UnionControl : UserControl
    {
        public UnionControl()
        {
            InitializeComponent();
            Loaded += UnionControl_Loaded;
        }

        private void UnionControl_Loaded(object sender, RoutedEventArgs e)
        {
            spStatus1.DataContext = App.viewModel.UnionCharacterStatus;
            spStatus2.DataContext = App.viewModel.UnionMapStatus;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
