using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Resources;
using MapleStoryHelper.Standard.Resources.ResourceManager;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MapleStoryHelper.ViewModel
{
    public class MapleStoryHelperViewModel : BindableBase
    {
        public event EventHandler<string> OnMessage;
        public event EventHandler<bool> OnProgress;

        public List<EquipmentItem> EquipmentItems { get; set; }

        private string _wzFilePath;
        public string WzFilePath
        {
            get => _wzFilePath;
            set
            {
                //LoadFileAsync(value);
                SetProperty(ref _wzFilePath, value);
            }
        }

        private async void LoadFileAsync(string fileName)
        {
            OnProgress?.Invoke(this, true);
            if (fileName != null || fileName.Length > 0)
            {
                EquipmentItems = await WzReader.GetEquipmentItems(fileName);

                try
                {

                }
                catch
                {
                    OnMessage?.Invoke(this, "메이플스토리 설치 경로를 확인해주세요.");
                }
            }
            else
            {
                _wzFilePath = @"C:\Nexon\Maple\Character.wz";
            }

            OnProgress?.Invoke(this, false);
        }

        private Character _newCharacterItem;
        public Character NewCharacterItem
        {
            get => _newCharacterItem;
            set => SetProperty(ref _newCharacterItem, value);
        }

        private ObservableCollection<Character> _characterItems;
        public ObservableCollection<Character> CharacterItems
        {
            get => _characterItems;
            set => SetProperty(ref _characterItems, value);
        }

        public MapleStoryHelperViewModel()
        {
            InitVariables();
            InitCommands();
        }

        #region Initialize

        private void InitVariables()
        {
            _newCharacterItem = new Character();
            _characterItems = new ObservableCollection<Character>();
        }

        private void InitCommands()
        {

        }



        #endregion

        #region Command

        public void AddCharacter(bool result)
        {
            if(result == true)
            {
                CharacterItems.Add(NewCharacterItem);
            }

            NewCharacterItem = new Character();
        }

        #endregion
    }
}
