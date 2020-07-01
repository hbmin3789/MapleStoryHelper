using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Character.Model;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WzComparerR2.CharaSim;

namespace MapleStoryHelperWPF.ViewModel
{
    public class MapleStoryHelperViewModel : BindableBase
    {
        public List<SetItem> SetItemList { get; private set; }

        private MapleWz _mapleWz;
        public MapleWz MapleWz
        {
            get => _mapleWz;
        }

        private Character _newCharacter;
        public Character NewCharacter
        {
            get => _newCharacter;
            set
            {
                SetProperty(ref _newCharacter, value);
                _newCharacter.UnionCharacterStatus = UnionCharacterStatus;
                _newCharacter.UnionMapStatus = UnionMapStatus;
                _newCharacter.CharacterEquipment.SetItemList = SetItemList;
            }
        }

        private ObservableCollection<Character> _characterList;
        public ObservableCollection<Character> CharacterList
        {
            get => _characterList;
            set => SetProperty(ref _characterList, value);
        }

        private StatusBase _unionCharacterStatus;
        public StatusBase UnionCharacterStatus
        {
            get => _unionCharacterStatus;
            set => SetProperty(ref _unionCharacterStatus, value);
        }

        private StatusBase _unionMapStatus;
        public StatusBase UnionMapStatus
        {
            get => _unionMapStatus;
            set => SetProperty(ref _unionMapStatus, value);
        }

        public StatusBase UnionStatus
        {
            get => _unionMapStatus + _unionCharacterStatus;
        }

        public MapleStoryHelperViewModel()
        {
            InitVariables();
            SetCharacter();
        }

        private void SetCharacter()
        {
            
        }

        private void InitVariables()
        {
            _mapleWz = new MapleWz();
            _unionMapStatus = new StatusBase();
            _unionCharacterStatus = new StatusBase();
            _characterList = new ObservableCollection<Character>();
            _newCharacter = new Character();
        }

        #region WzMethods

        public void LoadWz(string Path)
        {
            _mapleWz.LoadFile(Path);
            InitSetItem();
        }

        private void InitSetItem()
        {
            _mapleWz.SetItemList();
            SetItemList = _mapleWz.GetSetItemList();
        }

        /// <summary>
        /// 장비아이템 이름으로 검색을 시도합니다.
        /// ex) 앱솔랩스 - 앱솔랩스 케이프, 앱솔랩스 슈즈...
        /// </summary>
        /// <param name="KeyWord">검색할 이름</param>
        public List<EquipmentItem> FindItemByName(Character character,EEquipmentCategory category, string keyWord)
        {
            return _mapleWz.GetEquipmentItems(character, category, keyWord);
        }

        #endregion


        public void LoadCharacterJson(List<string> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                var character = JsonConvert.DeserializeObject<Character>(list[i]);
                CharacterList.Add(character);
            }
        }
    }
}
