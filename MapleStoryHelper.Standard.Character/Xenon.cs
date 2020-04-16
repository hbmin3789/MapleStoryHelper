using MapleStoryHelper.Standard.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Character
{
    #warning 제논은 따로 스텟 계산식이 필요함
    public class Xenon : Character
    {
        public Xenon()
        {
            this.JobConst = 0.875;
        }

        //뒷스공(제논) (STR + DEX + LUK) × 4 × 0.01 × 총 공격력 × 무기상수(1.5) × 직업상수(0.875) × (1 + 공격력%) × 1 + 데미지%) × (1 + 최종데미지%)
        public int GetMaxStatusAttack()
        {
            int retval = 0;
            int MainStatus = 0;
            int SubStatus = 0;
            double Constant = GetCharacterConstant();
            double Percent = GetCharacterPercent(Status);

            var temp = ((Status.GetSTR() + Status.GetDEX() + Status.GetLUK()) * 4) * Constant * Percent;
            retval = (int)temp;

            return retval;
        }

        public int GetMinStatusAttack()
        {
            int retval = 0;
            int MaxStatus = GetMaxStatusAttack();

            return retval;
        }

        #warning 공격력 %를 붙여줄지 붙이지 않을지에 대한 실험이 필요함
        private double GetCharacterPercent(StatusBase status)
        {
            double retval = 0;
            if (IsUseAttackPower == true)
            {
                retval += status.GetAttackPower();
            }
            else
            {
                retval += status.GetMagicAttack();
            }

            retval *= (1 + (status.Damage / 100));
            retval *= (1 + (status.LastDamage / 100));

            return retval;
        }

        private double GetCharacterConstant()
        {
            double retval = 0;

            retval += WeaponConst;
            retval *= JobConst;
            retval *= 0.01;

            return retval;
        }

    }
}
