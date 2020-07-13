using MapleStoryHelper.Standard.SkillLib.Model;

namespace MapleStoryHelper.Standard.DamageLib.ExMethods
{
    public static class DamageExt
    {
        public static long GetDamage(this Character.Model.Character character, SkillBase skill, int CoreReinforce, bool IsBoss, bool IsElement)
        {
            int avgStatusAttack = 0;
            if (IsBoss == true)
            {
                avgStatusAttack = (int)(character.GetMaxStatusAttackBoss() * 0.95);
            }
            else
            {
                avgStatusAttack = (int)(character.GetMaxStatusAttack() * 0.95);
            }

            long retval = (long)(((double)skill.PercentOnceDamage / 100) * avgStatusAttack);

            retval += (long)(retval * ((double)CoreReinforce / 100));

            if (IsElement == true)
            {
                retval /= 2;
            }

            if (retval >= 10000000000)
            {
                retval = 10000000000;
            }

            retval *= skill.HitCount;

            return retval;
        }
    }
}
