using MapleStoryHelper.Standard.SkillLib.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace MapleStoryHelperWPF.Control.Damage
{
    /// <summary>
    /// DamageControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DamageControl : UserControl
    {
        Thread thread;

        public DamageControl()
        {
            InitializeComponent();
            thread = new Thread(LoadData);
            App.OnWzLoaded += OnWzLoaded;
        }

        private void OnWzLoaded(object sender, EventArgs e)
        {
            thread.Start();
        }

        private void LoadData()
        {
            App.Current.Dispatcher.Invoke(() => 
            {
                ctrlLoading.ProgressEnabled = true;
            });

            var skills = App.mapleWz.GetSkills();

            App.Current.Dispatcher.Invoke(() => 
            {
                App.viewModel.Skills = new ObservableCollection<SkillBase>(skills);
                ctrlLoading.ProgressEnabled = false;
            });

            thread.Join();
        }

        private void btnOneKill_Click(object sender, RoutedEventArgs e)
        {
            ctrlOneKill.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ctrlMulung.Visibility = Visibility.Collapsed;
        }

        
    }
}
