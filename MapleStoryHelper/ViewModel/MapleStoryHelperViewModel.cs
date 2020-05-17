using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Database;
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
            
        }

        #endregion
    }
}
