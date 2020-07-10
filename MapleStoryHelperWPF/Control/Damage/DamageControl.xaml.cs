using MapleStoryHelper.Standard.SkillLib.Model;
using MapleStoryHelperWPF.Properties;
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
                ctrlLoading.SetDesc(Settings.Default.LoadingDesc + "(시간이 오래걸릴 수 있습니다.)");
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

        private void btnMulung_Click(object sender, RoutedEventArgs e)
        {
            ctrlMulung.SetCharacter(lvCharacter.SelectedItem);
            ctrlMulung.Visibility = Visibility.Visible;
        }

        private void lvCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvCharacter.SelectedItem == null)
            {
                spButtons.IsEnabled = false;
            }
            else
            {
                spButtons.IsEnabled = true;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
