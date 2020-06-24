using System;
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
            ctrlCharacterJob.OnCharacterChanged += OnCharacterChanged;
        }

        private void OnCharacterChanged(object sender, MapleStoryHelper.Standard.Character.Model.Character e)
        {
            SetDataContext(e);
        }

        public void SetDataContext(object dataContext)
        {
            this.DataContext = dataContext;
            ctrlCharacterItem.SetDataContext(dataContext);
            ctrlCharacterJob.SetDataContext(dataContext);
            ctrlCharacterStatusSetting.SetDataContext(dataContext);
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
            //ctrlSkillSetting.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnBaseStatusSetting_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ctrlCharacterStatusSetting.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
