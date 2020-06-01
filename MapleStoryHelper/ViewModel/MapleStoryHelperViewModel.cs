using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Common;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelper.ViewModel
{
    public class MapleStoryHelperViewModel : BindableBase
    {
        private string _wzFilePath;
        public string WzFilePath
        {
            get => _wzFilePath;
            set => SetProperty(ref _wzFilePath, value);
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
            _wzFilePath = @"C:\Nexon\Maple";
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
