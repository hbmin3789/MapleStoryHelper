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

namespace MapleStoryHelperWPF.Control
{
    /// <summary>
    /// CharacterAddControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CharacterAddControl : UserControl
    {
        List<string> CharacterList { get; set; }
        public CharacterAddControl()
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
                if(str.Length == 0)
                {
                    continue;
                }
                CharacterList.Add(str);
            }

            lstCharacter.ItemsSource = CharacterList;
        }
    }
}
