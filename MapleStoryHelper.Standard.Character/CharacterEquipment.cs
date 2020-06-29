using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Character
{
    public class CharacterEquipment : BindableBase
    {
        //만약 아케인셰이드 5셋, 파프니르 3셋이라면
        //SetItemDict[아케인셰이드] == 5
        //SetItemDict[파프니르] == 3
        private Dictionary<SetItem, int> _setItemDict;
        public Dictionary<SetItem,int> SetItemDict
        {
            get => _setItemDict;
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
            InitEquipList();
        }

        private void InitVariables()
        {
            _equipList = new Dictionary<ECharacterEquipmentCategory, EquipmentItem>();
            _setItemList = new List<SetItem>();
            _setItemDict = new Dictionary<SetItem, int>();
        }

        private void InitEquipList()
        {
            var CategoryItems = Enum.GetValues(typeof(ECharacterEquipmentCategory));
            for(int i = 0; i < CategoryItems.Length; i++)
            {
                var category = (ECharacterEquipmentCategory)i;
                var newItem = new EquipmentItem();
                newItem.CharacterEquipmentCategory = category;
                _equipList.Add(category, newItem);
            }
        }

        public StatusBase GetEquipStatus()
        {
            StatusBase retval = new StatusBase();

            for (int i = 0; i < EquipList.Count; i++)
            {
                retval = retval + (EquipList.ElementAt(i).Value as EquipmentItem).GetStatus<StatusBase>();
            }

            StatusBase SetItemStatus = new StatusBase();
            SetItemStatus = GetSetItemStatus();

            return retval;
        }

        private StatusBase GetSetItemStatus()
        {
            foreach(var item in SetItemDict)
            {
                SetItemDict[item.Key] = 0;
            }

            for(int i = 0; i < EquipList.Count; i++)
            {
                try
                {
                    int code = GetSetItemCode(EquipList[(ECharacterEquipmentCategory)i]);
                    if (code == 0)
                    {
                        continue;
                    }

                    SetItem setitem = GetSetItem(code);
                    if (setitem != null)
                    {
                        try
                        {
                            SetItemDict[setitem]++;
                        }
                        catch
                        {
                            SetItemDict.Add(setitem, 1);
                        }
                    }
                }
                catch
                {

                }
            }

            for(int i=0;i< EquipList.Count; i++)
            {
                if(EquipList[(ECharacterEquipmentCategory)i].IsJoker == true)
                {
                    SetJoker();
                    break;
                }
            }

            return null;
        }

        private void SetJoker()
        {
            for(int i = 0; i < SetItemDict.Count; i++)
            {
                var key = SetItemDict.ElementAt(i).Key;
                SetItemDict[key]++;
            }
        }

        private SetItem GetSetItem(int code)
        {
            for(int i = 0; i < SetItemList.Count; i++)
            {
                try
                {
                    SetItemList[i].ItemIDs[code] = true;
                    return SetItemList[i];
                }
                catch
                {

                }
            }

            return null;
        }

        private int GetSetItemCode(EquipmentItem equip)
        {
            if(equip == null)
            {
                return 0;
            }

            return Convert.ToInt32(equip.ItemCode);
        }

        public void AddEquipmentItem(EquipmentItem equip)
        {
            EquipList[equip.CharacterEquipmentCategory] = equip;
        }

        public EquipmentItem GetEquipmentItem(ECharacterEquipmentCategory category)
        {
            return EquipList[category] as EquipmentItem;
        }
    }
}
