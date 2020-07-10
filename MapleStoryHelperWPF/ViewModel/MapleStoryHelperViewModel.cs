using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Character.Model;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Common;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.SkillLib.Model;
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

        protected ObservableCollection<SkillBase> _skills;
        public ObservableCollection<SkillBase> Skills 
        {
            get => _skills;
            set => SetProperty(ref _skills, value);
        }

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
                _newCharacter.CharacterEquipment.SetItemList = SetItemList;
            }
        }

        private ObservableCollection<Character> _characterList;
        public ObservableCollection<Character> CharacterList
        {
            get => _characterList;
            set => SetProperty(ref _characterList, value);
        }

        private EquipmentStatus _unionStatus;
        public EquipmentStatus UnionStatus
        {
            get => _unionStatus;
            set
            {
                SetProperty(ref _unionStatus, value);
                if(value != null)
                {
                    Setting.UnionStatus = value;
                }
            }
        }

        public MapleStoryHelperViewModel()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            _mapleWz = new MapleWz();
            _unionStatus = new EquipmentStatus();
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


        public void LoadCharacterFromJson(List<string> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                var character = JsonConvert.DeserializeObject<Character>(list[i]);
                if(character != null)
                {
                    var equipList = character.CharacterEquipment.EquipList;
                    for (int j = 0; j < equipList.Count; j++)
                    {
                        var category = (ECharacterEquipmentCategory)j;
                        if (equipList[category].ImgByte != null)
                        {
                            equipList[category].ImgBitmapSource = equipList[category].ImgByte.LoadImage();
                        }
                    }
                }
                character.CharacterEquipment.SetItemList = SetItemList;
                App.Current.Dispatcher.Invoke(() => 
                {
                    CharacterList.Add(character);
                });
            }
        }
    }
}
