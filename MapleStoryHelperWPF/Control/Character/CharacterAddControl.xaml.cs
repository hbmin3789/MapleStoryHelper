using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelperWPF.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MapleStoryHelperWPF.Control
{
    /// <summary>
    /// CharacterAddControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CharacterAddControl : UserControl
    {
        MapleStoryHelper.Standard.Character.Model.Character Backup;

        public CharacterAddControl()
        {
            InitializeComponent();
            ctrlCharacterJob.OnCharacterChanged += OnCharacterChanged;
            App.UpdateBindingEvent += UpdateBinding;
        }

        private void OnCharacterChanged(object sender, MapleStoryHelper.Standard.Character.Model.Character e)
        {
            SetDataContext(e);
        }

        public void SetDataContext(object dataContext)
        {
            Backup = dataContext.DeepCopy<MapleStoryHelper.Standard.Character.Model.Character>();
            this.DataContext = dataContext;
            ctrlCharacterItem.SetDataContext(dataContext);
            ctrlCharacterJob.SetDataContext(dataContext);
            ctrlCharacterStatusSetting.SetDataContext(dataContext);
        }

        private void btnEditJob_Click(object sender, RoutedEventArgs e)
        {
            ctrlCharacterJob.Visibility = Visibility.Visible;
        }

        private void btnItemSetting_Click(object sender, RoutedEventArgs e)
        {
            ctrlCharacterItem.Visibility = Visibility.Visible;
            ctrlCharacterItem.UpdateView();
        }

        private void btnSkillSetting_Click(object sender, RoutedEventArgs e)
        {
            //ctrlSkillSetting.Visibility = Visibility.Visible;
        }

        private void btnBaseStatusSetting_Click(object sender, RoutedEventArgs e)
        {
            ctrlCharacterStatusSetting.Visibility = Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var character = this.DataContext as MapleStoryHelper.Standard.Character.Model.Character;
            var characterData = App.viewModel.CharacterList.Where(x => x.PrimaryKey.Equals(character.PrimaryKey)).FirstOrDefault();
            if (characterData == null)
            {
                string json = JsonConvert.SerializeObject(character, Formatting.None);
                App.viewModel.CharacterList.Add(character);
            }
            else
            {
                int idx = App.viewModel.CharacterList.IndexOf(characterData);
                App.viewModel.CharacterList[idx] = character;
            }
            this.Visibility = Visibility.Collapsed;
        }

        private void UpdateBinding(object sender, EventArgs e)
        {
            var temp = this.DataContext;
            this.DataContext = null;
            this.DataContext = temp;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("캐릭터가 저장되지 않습니다. 정말 종료할까요?", "", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                var temp = App.viewModel.CharacterList.Where(x => x.PrimaryKey.Equals(Backup.PrimaryKey)).FirstOrDefault();
                if (temp != null)
                {
                    int idx = App.viewModel.CharacterList.IndexOf(temp);
                    App.viewModel.CharacterList[idx] = Backup;
                }
                else
                {
                    App.viewModel.NewCharacter = Backup;
                }

                this.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSymbolSetting_Click(object sender, RoutedEventArgs e)
        {
            SymbolSettingWindow window = new SymbolSettingWindow();
            window.SetDataContext(this.DataContext);
            window.ShowDialog();
            App.UpdateBinding();
        }
    }
}
