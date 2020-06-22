﻿using MapleStoryHelper.Standard.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MapleStoryHelper.Standard.Character.Model
{
    public class Xenon : Character
    {
        //뒷스공(제논) (STR + DEX + LUK) × 4 × 0.01 × 총 공격력 × 무기상수(1.5) × 직업상수(0.875) × (1 + 공격력%) × 1 + 데미지%) × (1 + 최종데미지%)
        protected override int GetMaxStatusAttack()
        {
            int retval = 0;
            double Constant = GetCharacterConstant();
            double Percent = GetCharacterPercent(CharacterStatus);

            var temp = ((CharacterStatus.GetSTR() + CharacterStatus.GetDEX() + CharacterStatus.GetLUK()) * 4) * Constant * Percent;
            retval = (int)temp;

            return retval;
        }

        protected override int GetMinStatusAttack()
        {
            int retval = 0;
            //숙련도
            double temp = _maxStatusAttack * 0.9;
            retval = (int)temp;

            return retval;
        }
    }
}