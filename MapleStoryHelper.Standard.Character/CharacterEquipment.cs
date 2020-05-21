using MapleStoryHelper.Standard.Item;
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

        public EquipmentItem Ring1
        {
            get => EquipList[ECharacterEquipmentCategory.Ring1];
            set
            {
                var equip = _equipList[ECharacterEquipmentCategory.Ring1];
                SetProperty(ref equip, value);
            }
        }


        public CharacterEquipment()
        {
            InitVariables();
            InitEquipList();
        }

        private void InitVariables()
        {
            EquipList = new Dictionary<ECharacterEquipmentCategory, EquipmentItem>();
        }

        private void InitEquipList()
        {
            var CategoryItems = Enum.GetValues(typeof(ECharacterEquipmentCategory));
            for(int i = 0; i < CategoryItems.Length; i++)
            {
                EquipList.Add((ECharacterEquipmentCategory)CategoryItems.GetValue(i), new EquipmentItem());
            }
        }

        public void AddEquipmentItem(EquipmentItem equip)
        {
            EquipList[equip.CharacterEquipmentCategory] = equip;
        }

        public EquipmentItem GetEquipmentItem(ECharacterEquipmentCategory category)
        {
            return EquipList[category];
        }
    }
}
