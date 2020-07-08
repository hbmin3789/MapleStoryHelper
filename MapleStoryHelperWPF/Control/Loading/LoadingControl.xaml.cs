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

namespace MapleStoryHelperWPF.Control.Loading
{
    /// <summary>
    /// LoadingControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadingControl : UserControl
    {
        public static readonly DependencyProperty ProgressEnabledProperty = DependencyProperty.Register("ProgressEnabled", typeof(bool), typeof(LoadingControl),
            new PropertyMetadata(true, new PropertyChangedCallback(OnProgressEnabledChanged)));

        private static void OnProgressEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (LoadingControl)d;
            if(control == null)
            {
                return;
            }
            if ((bool)e.NewValue == true)
            {
                control.Visibility = Visibility.Visible;
            }
            else
            {
                control.Visibility = Visibility.Collapsed;
            }
        }

        public void SetDesc(string text)
        {
            tbDescription.Text = text;
        }

        public bool ProgressEnabled
        {
            get => (bool)GetValue(ProgressEnabledProperty);
            set => SetValue(ProgressEnabledProperty, value);
        }

        public LoadingControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public void SetText(string text)
        {
            App.Current.Dispatcher.Invoke(() => 
            {
                this.tbDescription.Text = text;
            });
        }
    }
}
