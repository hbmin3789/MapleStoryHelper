using MapleStoryHelper.Standard.Boss.Common;
using MapleStoryHelper.Standard.Resources;
using MapleStoryHelper.Standard.SkillLib.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Standard.DamageLib.Common
{
    public class MulungDpm : MapleDpm
    {
        private TimeSpan time;
        private SkillBase skill;

        public MulungDpm(StatusBase characterStatus, int MaxStatusAttack, int MinStatusAttack) : base(characterStatus, MaxStatusAttack, MinStatusAttack)
        {

        }

        public int GetMulungFloor(SkillBase mainSkill, Wz_Node StringWzNode)
        {
            int retval = 0;

            skill = mainSkill;
            List<BossBase> MulungBossList = GetMulungBossList();

            return retval;
        }

        private List<BossBase> GetMulungBossList()
        {
            List<BossBase> retval = new List<BossBase>();

            string BossStr = MHResourceManager.GetMulungBossText();
            string[] BossList = BossStr.Split(new char[] { '\n' });

            for(int i = 0; i < BossList.Length; i++)
            {
                retval.Add(GetBossByString(BossList[i]));
            }

            for(int i = 0; i < BossList.Length; i++)
            {
                retval[i].BossName = retval[i]
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
