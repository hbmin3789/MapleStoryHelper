using MapleStoryHelper.Standard.Boss.Common;
using MapleStoryHelper.Standard.Resources;
using MapleStoryHelper.Standard.SkillLib.Model;
using MapleStoryHelper.Framework.ResourceManager;
using System;
using System.Collections.Generic;
using WzComparerR2.WzLib;
using System.Text;
using MapleStoryHelper.Standard.Boss.Mulung;

namespace MapleStoryHelper.Standard.DamageLib.Common
{
    public class MulungDpm : MapleDpm
    {
        private TimeSpan remaining = TimeSpan.FromMinutes(15);
        private SkillBase skill = new SkillBase();
        private TimeSpan UltCoolTime;
        private TimeSpan UltCoolTimeBackUp;

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

        public int GetMulungFloor(SkillBase mainSkill, Wz_Node StringWzNode, int ultSkillDelay, int MainPercent)
        {
            int retval = 0;

            List<MulungBoss> MulungBossList = GetMulungBossList(StringWzNode);

            remaining = TimeSpan.FromMinutes(15);
            UltCoolTime = TimeSpan.FromSeconds(-1);
            UltCoolTimeBackUp = TimeSpan.FromSeconds(ultSkillDelay);
            skill = mainSkill;

            for(int i = 0; i < MulungBossList.Count; i++)
            {
                if (IsClearBoss(MulungBossList[i], mainSkill, MainPercent, i) == true)
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

        private bool IsClearBoss(MulungBoss boss, SkillBase mainSkill, int MainPercent, int floor)
        {
            SubRemaining(4000);
            GetBossHP(ref boss);

            long Damage = GetOnceDamage(boss);

            if (floor > 40)
            {

            }
            else
            {

            }

            for(int i = -1; i < boss.Revive; i++)
            {
                int AttackCount = (int)(boss.HP / Damage);

                if (AttackCount > 10 && UltCoolTime.TotalMilliseconds < 0)
                {
                    UltCoolTime = TimeSpan.FromMilliseconds(UltCoolTimeBackUp.TotalMilliseconds);

                    int SubPercent = 100 - MainPercent;
                    long SubDamage = (long)(((double)SubPercent / 100) * (double)Damage) + Damage;
                    SubDamage = (long)(10000 / skill.SkillDelay) * SubDamage;
                    boss.HP -= SubDamage;
                    SubRemaining(10000);
                }

                AttackCount = (int)(boss.HP / Damage);

                if (AttackCount == 0)
                {
                    if(boss.Revive != 0)
                    {
                        if (SubRemaining(2500) == false)
                        {
                            return false;
                        }
                    }
                    continue;
                }

                

                //MilliSeconds
                int DealTime = (AttackCount * skill.SkillDelay);
                if(SubRemaining(DealTime) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool SubRemaining(int milliSec)
        {
            var subTime = TimeSpan.FromMilliseconds(milliSec);

            remaining = remaining.Subtract(subTime);
            UltCoolTime = UltCoolTime.Subtract(subTime);

            if (remaining.TotalMilliseconds <= 0)
            {
                return false;
            }

            return true;
        }

        private void GetBossHP(ref MulungBoss boss)
        {
            if (boss.FinalMaxHP.Contains("x"))
            {
                string[] temp = boss.FinalMaxHP.Split(new char[] { 'x' });
                boss.Revive = (Convert.ToInt32(temp[1]) - 1);
                boss.FinalMaxHP = temp[0];
            }

            if (boss.FinalMaxHP.Contains("*"))
            {
                boss.FinalMaxHP = boss.FinalMaxHP.Replace("*", "");
                boss.IsElementResistance = true;
            }

            if (boss.FinalMaxHP.Length > 3)
            {
                boss.HP = Convert.ToInt64(boss.FinalMaxHP);
            }
            else
            {
                boss.HP = Convert.ToInt64(boss.MaxHP);
            }
        }

        private long GetOnceDamage(MulungBoss boss)
        {
            long retval = (long)(((double)skill.PercentOnceDamage / 100) * StatusAttackAvg);

            retval /= (long)((1 + (Status.Damage / 100)) * 2);

            //스킬
            retval *= skill.HitCount;

            //무릉 데미지 감소
            retval /= 10;

            //몬스터 방어율
            var bossArmor = (1 - ((boss.Armor / 100) * (1 - ((100.0 - Status.IgnoreDef) / 100.0))));
            retval = (long)(retval * bossArmor);

            //속성내성
            if (boss.IsElementResistance == true)
            {
                retval /= 2;
            }

            //보공
            retval = (long)(retval * (double)Status.BossDamage / 100);

            if (retval >= 10000000000)
            {
                retval = 10000000000;
            }           

            return (long)retval;
        }

        private List<MulungBoss> GetMulungBossList(Wz_Node StringWzNode)
        {
            List<MulungBoss> retval = new List<MulungBoss>();

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

        private MulungBoss GetBossByString(string BossStr)
        {
            string[] temp = BossStr.Split(new char[] { ',' });

            int Level = Convert.ToInt32(temp[0]);
            string HPStr = temp[1];

            MulungBoss retval = new MulungBoss();

            retval.FinalMaxHP = HPStr;
            retval.Level = Level;

            return retval;
        }
    }
}
