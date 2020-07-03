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
            InitEquipList();
        }

        private void InitVariables()
        {
            _equipList = new Dictionary<ECharacterEquipmentCategory, EquipmentItem>();
            _setItemEffects = new ObservableCollection<SetItemEffect>();
            _setItemList = new List<SetItem>();
            _curSetItems = new List<SetItem>();
        }

        private void InitCurSetItem()
        {
            _curSetItems = new List<SetItem>();
            _setItemEffects = new ObservableCollection<SetItemEffect>();
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

            StatusBase status = SetItemStatus();

            retval += status;

            return retval;
        }

        private StatusBase SetItemStatus()
        {
            StatusBase retval = new StatusBase();
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
                    SetJoker(EquipList[(ECharacterEquipmentCategory)i].ItemCode);
                    break;
                }
            }

            retval += GetSetItemStatus();

            return retval;
        }

        private StatusBase GetSetItemStatus()
        {
            StatusBase retval = new StatusBase();

            for(int i = 0; i < CurSetItems.Count; i++)
            {
                int count = GetSetItemCount(i);
                SetItemEffect cur = null;
                List<SetItemEffect> effects = new List<SetItemEffect>();
                for(int j = 0; j < CurSetItems[i].Effects.Count; j++)
                {
                    if(CurSetItems[i].Effects.ElementAt(j).Key < count)
                    {
                        cur = CurSetItems[i].Effects.ElementAt(j).Value;
                        effects.Add(cur);
                    }
                }

                for(int j = 0; j < effects.Count; j++)
                {
                    SetItemEffects.Add(effects[j]);
                }

            }

            for(int i = 0; i < SetItemEffects.Count; i++)
            {
                retval += SetItemEffects[i].Props.ToStatusBase();
            }

            return retval;
        }

        private int GetSetItemCount(int idx)
        {
            int retval = 0;

            var parts = CurSetItems[idx].ItemIDs.Parts;
            for (int i = 0; i < parts.Count; i++)
            {
                for(int j = 0; j < parts[i].Value.ItemIDs.Count; j++)
                {
                    if(parts[i].Value.ItemIDs.ElementAt(j).Value == true)
                    {
                        retval++;
                        break;
                    }
                }
            }

            return retval;
        }

        private void SetJoker(string ItemCode)
        {
            for(int i = 0; i < CurSetItems.Count; i++)
            {
                if(CurSetItems[i].jokerPossible == true)
                {
                    var Parts = CurSetItems[i].ItemIDs.Parts;

                    int itemCode = Convert.ToInt32(ItemCode);
                    var itemPart = new SetItemIDPart();
                    itemPart.ItemIDs.Add(itemCode, true);

                    var newItem = new KeyValuePair<int, SetItemIDPart>(Parts.Count, itemPart);
                    Parts.Add(newItem);
                }
            }
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
