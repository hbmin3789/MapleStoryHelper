using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Database;
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


        public MapleStoryHelperViewModel()
        {
            InitVariables();
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논" ,Level= 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
            CharacterItems.Add(new Character() { CharacterName = "최애캐제논", Level = 12, CharacterJob = ECharacterJob.Xenon });
        }

        private void InitVariables()
        {
            _newCharacterItem = new Character();
            _characterItems = new ObservableCollection<Character>();
            //dbmanager = new MHDBManager();
        }
    }
}
