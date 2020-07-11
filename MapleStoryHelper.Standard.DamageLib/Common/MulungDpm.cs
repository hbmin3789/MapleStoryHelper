using MapleStoryHelper.Standard.SkillLib.Model;
using System;
using System.IO;
using System.Reflection;

namespace MapleStoryHelper.Standard.DamageLib.Common
{
    public class MulungDpm : MapleDpm
    {
        private TimeSpan time;
        private SkillBase skill;

        public MulungDpm(StatusBase characterStatus, int MaxStatusAttack, int MinStatusAttack) : base(characterStatus, MaxStatusAttack, MinStatusAttack)
        {

        }

        public int GetMulungFloor(SkillBase mainSkill)
        {
            int retval = 0;

            skill = mainSkill;

            return retval;
        }

        private int[] GetMulungBossHP()
        {
            int[] retval = new int[100];


            return retval;
        }
    }
}
