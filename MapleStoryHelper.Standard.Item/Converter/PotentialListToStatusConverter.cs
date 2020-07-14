﻿using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Item.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Converter
{
    public class PotentialConverter
    {
        public static StatusBase Convert(List<Potential> value)
        {
            bool first = true;

            StatusBase retval = new StatusBase();
            
            for (int i = 0; i < value.Count; i++)
            {
                int PoValue = value[i].StatusValue;
                switch ((int)value[i].StatusKind)
                {
                    case 0:
                        retval.Str += PoValue;
                        break;
                    case 1:
                        retval.Dex += PoValue;
                        break;
                    case 2:
                        retval.Int += PoValue;
                        break;
                    case 3:
                        retval.Luk += PoValue;
                        break;
                    case 4:
                        retval.AllStatus += PoValue;
                        break;
                    case 5:
                        retval.HP += PoValue;
                        break;
                    case 6:
                        retval.MP += PoValue;
                        break;
                    case 7:
                        retval.PStr += PoValue;
                        break;
                    case 8:
                        retval.PDex += PoValue;
                        break;
                    case 9:
                        retval.PInt += PoValue;
                        break;
                    case 10:
                        retval.PLuk += PoValue;
                        break;
                    case 11:
                        retval.PAllStatus += PoValue;
                        break;
                    case 12:
                        retval.PHP += PoValue;
                        break;
                    case 13:
                        retval.PMP += PoValue;
                        break;
                    case 14:
                        retval.AttackPower += PoValue;
                        break;
                    case 15:
                        retval.MagicAttack += PoValue;
                        break;
                    case 16:
                        retval.PAttackPower += PoValue;
                        break;
                    case 17:
                        retval.PMagicAttack += PoValue;
                        break;
                    case 18:
                        retval.Damage += PoValue;
                        break;
                    case 19:
                        retval.BossDamage += PoValue;
                        break;
                    case 20:
                        if (first == true)
                        {
                            retval.IgnoreDef = ((1 - (1 - (double)PoValue / 100)) * 100);
                            first = false;
                        }
                        else
                        {
                            retval.IgnoreDef = (1 - ((1 - retval.IgnoreDef / 100) * (1 - (double)PoValue / 100))) * 100;
                        }
                        break;
                    case 21:
                        retval.CriticalDamage += PoValue;
                        break;
                }
            }

            return retval;
        }
    }
}
