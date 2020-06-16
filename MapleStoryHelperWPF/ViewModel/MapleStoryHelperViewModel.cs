using MapleStoryHelper.Standard.Character;
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
        private ObservableCollection<Character> _characterList;
        public ObservableCollection<Character> CharacterList
        {
            get => _characterList;
            set => SetProperty(ref _characterList, value);
        }

        public MapleStoryHelperViewModel()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            _characterList = new ObservableCollection<Character>();
        }
    }
}
