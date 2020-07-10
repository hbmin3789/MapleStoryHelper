using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.DamageLib.Common
{
    public class MapleDpm
    {
        private StatusBase Status;
        private int StatusAttack;

        public MapleDpm(StatusBase characterStatus, int MaxStatusAttack)
        {
            Status = characterStatus;
            StatusAttack = MaxStatusAttack;
        }
    }
}
