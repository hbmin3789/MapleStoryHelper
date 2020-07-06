using System;
using System.Collections.Generic;
using System.Text;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.MobLib.Model
{
    public class MobBase : Mob
    {
        private string _mobName;
        public string MobName
        {
            get => _mobName;
            set => SetProperty(ref _mobName, value);
        }

        private int _defense;
        public int Defense
        {
            get => _defense;
            set => SetProperty(ref _defense, value);
        }
    }
}
