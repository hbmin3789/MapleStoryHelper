using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item.Equipment
{
    public class Weapon : EquipmentItem
    {
        private double _weaponConst;
        public double WeaponConst
        {
            get => _weaponConst;
            set => SetProperty(ref _weaponConst, value);
        }
    }
}
