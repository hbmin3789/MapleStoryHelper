using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.DamageLib.Common
{
    public class MapleDpm
    {
        protected StatusBase Status;
        protected int StatusAttackAvg;

        public MapleDpm(StatusBase characterStatus, int MaxStatusAttack,int MinStatusAttack)
        {
            Status = characterStatus;
            StatusAttackAvg = (MaxStatusAttack + MinStatusAttack) / 2;
        }


    }
}
