using MapleStoryHelper.Standard.SkillLib.Model;

namespace MapleStoryHelper.Standard.DamageLib.ExMethods
{
    public static class DamageExt
    {
        public static long GetDamage(this Character.Model.Character character, SkillBase skill, int CoreReinforce, int Armor, bool IsBoss, bool IsElement)
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

            var bossArmor = (1 - ((Armor / 100) * (1 - ((100.0 - character.CharacterStatus.IgnoreDef) / 100.0))));
            retval = (long)(retval * bossArmor);

            if (retval >= 10000000000)
            {
                retval = 10000000000;
            }

            retval *= skill.HitCount;

            return retval;
        }

        public static long GetMulungDamage(this Character.Model.Character character, SkillBase skill, int CoreReinforce, int Armor, bool IsBoss, bool IsElement, StatusBase status)
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

            var bossArmor = (1 - ((Armor / 100) * (1 - ((100.0 - character.CharacterStatus.IgnoreDef) / 100.0))));
            retval = (long)(retval * bossArmor);

            retval = retval / 10;

            double crit = status.Critical / 100;
            double critDmg = (status.CriticalDamage / 100) + 1.35;
            retval = (long)(retval * (crit * critDmg));

            if (retval >= 10000000000)
            {
                retval = 10000000000;
            }

            retval *= skill.HitCount;

            return retval;
        }
    }
}
