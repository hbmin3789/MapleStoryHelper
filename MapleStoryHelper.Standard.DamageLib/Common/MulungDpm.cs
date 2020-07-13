using MapleStoryHelper.Standard.Boss.Common;
using MapleStoryHelper.Standard.Resources;
using MapleStoryHelper.Standard.SkillLib.Model;
using MapleStoryHelper.Framework.ResourceManager;
using System;
using System.Collections.Generic;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Standard.DamageLib.Common
{
    public class MulungDpm : MapleDpm
    {
        private TimeSpan remaining = TimeSpan.FromMinutes(15);
        private SkillBase skill = new SkillBase();
        private TimeSpan UltCoolTime;

        private List<int> MagnificationList;

        public MulungDpm(StatusBase characterStatus, int MaxStatusAttack, int MinStatusAttack) : base(characterStatus, MaxStatusAttack, MinStatusAttack)
        {
            InitMagnificationList();
        }

        private void InitMagnificationList()
        {
            int inc = 50;
            MagnificationList = new List<int>();
            for(int i = 0; i < 40; i++)
            {
                MagnificationList.Add(0);
            }

            MagnificationList[0] = 4;
            MagnificationList[1] = 19;
            MagnificationList[2] = 30;
            MagnificationList[3] = 40;
            MagnificationList[4] = 50;

            for (int i = 5; i < MagnificationList.Count; i++)
            {
                MagnificationList[i] = inc;
                if(i == 8)
                {
                    continue;
                }

                if(i == 29)
                {
                    MagnificationList[i] = 1000;
                    continue;
                }

                if(i == 39)
                {
                    MagnificationList[i] = 9524;
                }

                inc += 50;
            }
        }

        public int GetMulungFloor(SkillBase mainSkill, Wz_Node StringWzNode, int ultSkillDelay)
        {
            int retval = 0;
            UltCoolTime = TimeSpan.FromSeconds(ultSkillDelay);

            skill = mainSkill;
            List<BossBase> MulungBossList = GetMulungBossList(StringWzNode);

            for(int i = 0; i < MulungBossList.Count; i++)
            {
                if (IsClearBoss(MulungBossList[i], mainSkill, i) == true)
                {
                    retval++;
                }
                else
                {
                    return retval;
                }
            }

            return retval;
        }

        private bool IsClearBoss(BossBase boss, SkillBase mainSkill, int idx)
        {
            if(idx > 40)
            {

            }

            long bossHP = GetBossHP(boss);
            long Damage = GetOnceDamage();

            int AttackCount = (int)(bossHP / Damage);
            if(AttackCount == 0)
            {
                return true;
            }


            //MilliSeconds
            int DealTime = (AttackCount * skill.SkillDelay);
            TimeSpan temp = remaining.Subtract(TimeSpan.FromMilliseconds(DealTime));

            if (temp.TotalMilliseconds < 0)
            {
                return false;
            }

            remaining = temp;

            return true;
        }

        private long GetBossHP(BossBase boss)
        {
            if (boss.FinalMaxHP.Length > 3)
            {
                return Convert.ToInt64(boss.FinalMaxHP);
            }
            else
            {
                return Convert.ToInt64(boss.MaxHP);
            }
        }

        private long GetOnceDamage()
        {
            long retval = skill.PercentOnceDamage * StatusAttackAvg / 10;

            if(retval >= 10000000000)
            {
                retval = 10000000000;
            }

            retval *= skill.HitCount;

            return retval;
        }

        private List<BossBase> GetMulungBossList(Wz_Node StringWzNode)
        {
            List<BossBase> retval = new List<BossBase>();

            string BossStr = MHResourceManager.GetMulungBossText();

            BossStr.Replace('\r', ' ');
            BossStr.Replace(" ", "");

            string[] BossList = BossStr.Split(new char[] { '\n' });

            for(int i = 0; i < BossList.Length; i++)
            {
                retval.Add(GetBossByString(BossList[i]));
            }

            for(int i = 0; i < BossList.Length; i++)
            {
                retval[i].BossName = retval[i].ID.GetNameByCode(StringWzNode,"Mob");
            }

            return retval;
        }

        private BossBase GetBossByString(string BossStr)
        {
            string[] temp = BossStr.Split(new char[] { ',' });

            int Level = Convert.ToInt32(temp[0]);
            string HPStr = temp[1];

            BossBase retval = new BossBase();

            retval.FinalMaxHP = HPStr;
            retval.Level = Level;

            return retval;
        }
    }
}
