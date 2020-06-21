using MapleStoryHelper.Standard.Item;
using System;
using System.Collections.Generic;
using System.Text;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Character.Common
{
    public static class CharacterExMethods
    {
        public static List<ECharacterJob> GetWeaponJob(this EquipmentItem weapon)
        {
            List<ECharacterJob> retval = new List<ECharacterJob>();

            switch (weapon.WeaponType)
            {
                case GearType.ohSword:
                case GearType.ohBlunt:
                case GearType.ohAxe:
                    break;

                case GearType.thSword:
                case GearType.thBlunt:
                case GearType.thAxe:
                    break;

                    
            }

            return retval;
        }

    }
}
