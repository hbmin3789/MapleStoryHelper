using System;
using System.Collections.Generic;
using System.Text;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Boss.Common
{
    public class BossBase : Mob
    {
        private string _bossName;
        public string BossName
        {
            get => _bossName;
            set => SetProperty(ref _bossName, value);
        }

        private int _level;
        public new int Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }
    }
}
