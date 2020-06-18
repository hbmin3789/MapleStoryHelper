using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MapleStoryHelperWPF.ViewModel
{
    public class MapleStoryHelperViewModel : BindableBase
    {
        private MapleWz mapleWz;

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
            mapleWz = new MapleWz();

            _characterList = new ObservableCollection<Character>();
            _newCharacter = new Character();
        }

        #region WzMethods

        public void LoadWz(string Path)
        {
            mapleWz.LoadFile(Path);
        }

        /// <summary>
        /// 장비아이템 이름으로 검색을 시도합니다.
        /// ex) 앱솔랩스 - 앱솔랩스 케이프, 앱솔랩스 슈즈...
        /// </summary>
        /// <param name="KeyWord">검색할 이름</param>
        public List<EquipmentItem> FindItemByName(EEquipmentCategory category, string keyWord)
        {
            return mapleWz.GetEquipmentItems(category, keyWord);
        }

        #endregion
    }
}
