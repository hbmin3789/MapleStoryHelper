using MapleStoryHelper.Standard.Item.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            this.DataContext = App.viewModel.UnionStatus;
            App.UpdateBindingEvent += UpdateBinding;
        }

        private void UpdateBinding(object sender, EventArgs e)
        {
            this.DataContext = null;
            this.DataContext = App.viewModel.UnionStatus;
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
