using MapleStoryHelper.Standard.Character;
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

namespace MapleStoryHelperWPF.Control.Character.CharacterAdd
{
    /// <summary>
    /// CharacterJobControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CharacterJobControl : UserControl
    {
        List<string> CharacterList { get; set; }

        public CharacterJobControl()
        {
            InitializeComponent();
            InitCharacterList();
        }

        private void InitCharacterList()
        {
            CharacterList = new List<string>();
            var characterValue = Enum.GetValues(typeof(ECharacterJob));

            for (int i = 0; i < characterValue.Length; i++)
            {
                string str = ECharacterJobToStringConverter.Convert((ECharacterJob)characterValue.GetValue(i));
                if (str.Length == 0)
                {
                    continue;
                }
                CharacterList.Add(str);
            }

            lvCharacterJob.ItemsSource = CharacterList;
        }

        private void lvCharacterJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvCharacterJob.SelectedIndex == -1)
            {
                return;
            }

            string job = ECharacterJobToStringConverter.Convert((ECharacterJob)lvCharacterJob.SelectedIndex);

            var result = MessageBox.Show("\"" + job + "\"선택됨. 결정하시겠습니까?", "", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                this.Visibility = Visibility.Collapsed;
                if((ECharacterJob)lvCharacterJob.SelectedIndex == ECharacterJob.Xenon)
                {
                    App.viewModel.NewCharacter = new MapleStoryHelper.Standard.Character.Model.Xenon();
                }
            }
            else
            {
                lvCharacterJob.SelectedIndex = -1;
            }
        }
    }
}
