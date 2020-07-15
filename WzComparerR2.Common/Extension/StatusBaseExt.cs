using MapleStoryHelper.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WzComparerR2.CharaSim;

namespace WzComparerR2.Common.Extension
{
    public static class StatusBaseExt
    {
        public static StatusBase ToStatusBase(this SortedDictionary<GearPropType, object> Props)
        {
            StatusBase retval = new StatusBase();

            for (int i = 0; i < Props.Count; i++)
            {
                var propType = Props.ElementAt(i).Key;
                if(propType == GearPropType.Option)
                {
                    var potens = Props[propType] as List<Potential>;
                    for (int j = 0; j < potens.Count; j++)
                    {
                        var props = potens[j].props;
                        for (int k = 0; k < props.Count; k++)
                        {
                            var key = props.ElementAt(k).Key;
                            var val = props.ElementAt(k).Value;

                            if (key == GearPropType.boss)
                            {
                                retval.BossDamage += props.ElementAt(k + 1).Value;
                                break;
                            }

                            SetStatusBase(ref retval, key, val);
                        }
                    }
                }
                try
                {
                    int val = Convert.ToInt32(Props.ElementAt(i).Value);
                    SetStatusBase(ref retval, propType, val);
                }
                catch
                {

                }
            }

            return retval;
        }

        private static void SetStatusBase(ref StatusBase retval, GearPropType type, int val)
        {
            switch (type)
            {
                case GearPropType.incSTR:
                    retval.Str += val;
                    break;
                case GearPropType.incSTRr:
                    retval.PStr += val;
                    break;
                case GearPropType.incDEX:
                    retval.Dex += val;
                    break;
                case GearPropType.incDEXr:
                    retval.PDex += val;
                    break;
                case GearPropType.incINT:
                    retval.Int += val;
                    break;
                case GearPropType.incINTr:
                    retval.PInt += val;
                    break;
                case GearPropType.incLUK:
                    retval.Luk += val;
                    break;
                case GearPropType.incLUKr:
                    retval.PLuk += val;
                    break;
                case GearPropType.incAllStat:
                    retval.AllStatus += val;
                    break;
                case GearPropType.statR:
                    retval.PAllStatus += val;
                    break;
                case GearPropType.incMHP:
                    retval.HP += val;
                    break;
                case GearPropType.incMHPr:
                    retval.PHP += val;
                    break;
                case GearPropType.incMMP:
                    retval.MP += val;
                    break;
                case GearPropType.incMMPr:
                    retval.PMP += val;
                    break;
                case GearPropType.incPAD:
                    retval.AttackPower += val;
                    break;
                case GearPropType.incPADr:
                    retval.PAttackPower += val;
                    break;
                case GearPropType.incMAD:
                    retval.MagicAttack += val;
                    break;
                case GearPropType.incMADr:
                    retval.PMagicAttack += val;
                    break;
                case GearPropType.damR:
                case GearPropType.incDAMr:
                    retval.Damage += val;
                    break;
                case GearPropType.incCr:
                    retval.Critical += val;
                    break;
                case GearPropType.incBDR:
                case GearPropType.bdR:
                    retval.BossDamage += val;
                    break;
                case GearPropType.incIMDR:
                case GearPropType.imdR:
                    if (retval.IgnoreDef == 0)
                    {
                        retval.IgnoreDef = val;
                    }
                    else
                    {
                        retval.IgnoreDef = (1 - (1 - ((double)retval.IgnoreDef / 100)) * (1 - ((double)val / 100))) * 100;
                    }
                    break;
            }
        }

        public static StatusBase ToStatusBase(this List<SetItemEffect> effects)
        {
            StatusBase retval = new StatusBase();

            for (int i = 0; i < effects.Count; i++)
            {
                retval += effects[i].Props.ToStatusBase();
            }

            return retval;
        }
    }
}
