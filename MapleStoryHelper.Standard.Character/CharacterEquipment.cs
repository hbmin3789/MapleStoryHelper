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
                var category = (ECharacterEquipmentCategory)CategoryItems.GetValue(i);
                if(category == ECharacterEquipmentCategory.Weapon)
                {
                    _equipList.Add(category, new Weapon());
                }
                else
                {
                    _equipList.Add(category, new EquipmentItem());
                }
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
