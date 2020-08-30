using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Utils.ExMethods;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WzComparerR2.CharaSim;
using WzComparerR2.Common.Extension;

namespace MapleStoryHelper.Standard.Character
{
    public class CharacterEquipment : BindableBase
    {
        private Dictionary<string, StatusBase> _curSetItemEffect;
        public Dictionary<string, StatusBase> CurSetItemEffect
        {
            get => _curSetItemEffect;
            set => SetProperty(ref _curSetItemEffect, value);
        }

        private ObservableCollection<SetItemEffect> _setItemEffects;
        public ObservableCollection<SetItemEffect> SetItemEffects
        {
            get => _setItemEffects;
            set => SetProperty(ref _setItemEffects, value);
        }

        private List<SetItem> _curSetItems;
        public List<SetItem> CurSetItems
        {
            get => _curSetItems;
            set => SetProperty(ref _curSetItems, value);
        }

        private Dictionary<ECharacterEquipmentCategory, EquipmentItem> _equipList;
        public Dictionary<ECharacterEquipmentCategory, EquipmentItem> EquipList
        {
            get => _equipList;
            set => SetProperty(ref _equipList, value);
        }

        private List<SetItem> _setItemList;
        public List<SetItem> SetItemList
        {
            get => _setItemList;
            set => SetProperty(ref _setItemList, value);
        }

        public CharacterEquipment()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            _equipList = new Dictionary<ECharacterEquipmentCategory, EquipmentItem>();
            _setItemEffects = new ObservableCollection<SetItemEffect>();
            _setItemList = new List<SetItem>();
            _curSetItems = new List<SetItem>();
            _curSetItemEffect = new Dictionary<string, StatusBase>();
        }

        private void InitCurSetItem()
        {
            _curSetItems = new List<SetItem>();
            _setItemEffects = new ObservableCollection<SetItemEffect>();
            _curSetItemEffect = new Dictionary<string, StatusBase>();
        }

        public void InitSetItem()
        {
            CurSetItemEffect = new Dictionary<string, StatusBase>();
            CurSetItems = new List<SetItem>();
        }
    }
}
