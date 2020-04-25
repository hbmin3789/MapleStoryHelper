using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Database;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelper.ViewModel
{
    public class MapleStoryHelperViewModel : BindableBase
    {
        private MHDBManager dbmanager;

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


        public DelegateCommand<bool?> AddCharacterCommand { get; set; }


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
            dbmanager = new MHDBManager();
        }

        private void InitCommands()
        {
            AddCharacterCommand = new DelegateCommand<bool?>(AddCharacter);
        }

        #endregion

        #region Command

        private void AddCharacter(bool? result)
        {
            if(result == true)
            {
                SaveCharacter();
                LoadCharacter();
            }
        }

        #endregion

        private void SaveCharacter()
        {
            dbmanager.SaveCharacter(NewCharacterItem);
        }

        private void LoadCharacter()
        {
            CharacterItems = new ObservableCollection<Character>(dbmanager.GetCharacterItems());
        }
    }
}
