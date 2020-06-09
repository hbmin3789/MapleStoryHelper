using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapleStoryHelper.Standard.Character
{
    public class CharacterEquipment : BindableBase
    {
        private Dictionary<ECharacterEquipmentCategory, EquipmentItem> _equipList;
        public Dictionary<ECharacterEquipmentCategory, EquipmentItem> EquipList
        {
            get => _equipList;
            set => SetProperty(ref _equipList, value);
        }

        public CharacterEquipment()
        {
            InitVariables();
            InitEquipList();
        }

        private void InitVariables()
        {
            _equipList = new Dictionary<ECharacterEquipmentCategory, EquipmentItem>();
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
                retval = retval + (EquipList.ElementAt(i).Value as EquipmentItem).Status.GetStatus<StatusBase>();
            }

            return retval;
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
