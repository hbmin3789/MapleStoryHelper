using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Utils.ExMethods;
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
            InitEquipList();
        }

        private void InitVariables()
        {
            _equipList = new Dictionary<ECharacterEquipmentCategory, EquipmentItem>();
            _setItemList = new List<SetItem>();
            _curSetItems = new List<SetItem>();
        }

        private void InitCurSetItem()
        {
            _curSetItems = new List<SetItem>();
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
            InitCurSetItem();

            for (int i = 0; i < EquipList.Count; i++)
            {
                try
                {
                    int code = GetItemCode(EquipList[(ECharacterEquipmentCategory)i]);
                    if (code == 0)
                    {
                        continue;
                    }

                    SetItem setitem = GetSetItem(code);
                    if (setitem != null)
                    {
                        var temp = CurSetItems.Where(x => x.SetItemID == setitem.SetItemID).FirstOrDefault();
                        if(temp == null)
                        {
                            var newItem = setitem.Clone() as SetItem;
                            newItem.ItemIDs[code] = true;
                            CurSetItems.Add(newItem);
                        }
                        else
                        {
                            int idx = CurSetItems.IndexOf(temp);
                            CurSetItems[idx].ItemIDs[code] = true;
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
            
        }

        private SetItem GetSetItem(int code)
        {
            for(int i = 0; i < SetItemList.Count; i++)
            {
                try
                {
                    foreach(var kv in SetItemList[i].ItemIDs.Parts)
                    {
                        if (kv.Value.ItemIDs.ContainsKey(code) == true)
                        {
                            return SetItemList[i];
                        }
                    }
                }
                catch
                {

                }
            }

            return null;
        }

        private int GetItemCode(EquipmentItem equip)
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
