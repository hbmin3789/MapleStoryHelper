using MapleStoryHelper.Standard.Character;
using MapleStoryHelperWPF.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelperWPF.ViewModel
{
    public class MapleStoryHelperViewModel : BindableBase
    {
        private Character _newCharacter;
        public Character NewCharacter
        {
            get => _newCharacter;
            set => SetProperty(ref _newCharacter, value);
        }

        private ObservableCollection<Character> _characterList;
        public ObservableCollection<Character> CharacterList
        {
            get => _characterList;
            set => SetProperty(ref _characterList, value);
        }

        public MapleStoryHelperViewModel()
        {
            InitVariables();
            AddCharacter();
        }

        private void AddCharacter()
        {

        }

        private void InitVariables()
        {
            _characterList = new ObservableCollection<Character>();
            _newCharacter = new Character();
        }
    }
}
