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

namespace MapleStoryHelperWPF.Control.Status
{
    /// <summary>
    /// StatusControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class StatusControl : UserControl
    {
        public static readonly DependencyProperty ReadOnlyProperty = DependencyProperty.Register(
                                                    "ReadOnly", typeof(bool), typeof(StatusControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnReadOnlyPropertyChanged)));

        private static void OnReadOnlyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var control = d as StatusControl;

            for (int i = 0; i < control.spStatus1.Children.Count; i++)
            {
                var child = control.spStatus1.Children[i] as TextBox;
                child.IsReadOnly = (bool)e.NewValue;
            }

            for (int i = 0; i < control.spStatus2.Children.Count; i++)
            {
                var child = control.spStatus2.Children[i] as TextBox;
                child.IsReadOnly = (bool)e.NewValue;
            }

        }

        public bool ReadOnly
        {
            get => (bool)GetValue(ReadOnlyProperty);
            set => SetValue(ReadOnlyProperty, value);
        }

        public StatusControl()
        {
            InitializeComponent();
        }

        public void SetCharacterStatusDataContext(object dataContext)
        {
            this.DataContext = null;
            this.DataContext = (dataContext as MapleStoryHelper.Standard.Character.Model.Character).CharacterStatus;
            ctrlStatusAttack.SetDataContext(dataContext);
        }

        public void SetBaseStatusDataContext(object dataContext)
        {
            this.DataContext = null;
            this.DataContext = (dataContext as MapleStoryHelper.Standard.Character.Model.Character).BaseStatus;
            ctrlStatusAttack.SetDataContext(dataContext);
        }
    }
}
