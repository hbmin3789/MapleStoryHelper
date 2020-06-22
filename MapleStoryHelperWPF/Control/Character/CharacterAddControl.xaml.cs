using System.Windows.Controls;

namespace MapleStoryHelperWPF.Control
{
    /// <summary>
    /// CharacterAddControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CharacterAddControl : UserControl
    {
        public CharacterAddControl()
        {
            InitializeComponent();
        }

        private void btnEditJob_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ctrlCharacterJob.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnItemSetting_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ctrlCharacterItem.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnSkillSetting_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ctrlSkillSetting.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
