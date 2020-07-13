using MapleStoryHelper.Standard.Boss.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Boss.Mulung
{
    public class MulungBoss : BossBase
    {
        private int _revive = 0;
        public new int Revive
        {
            get => _revive;
            set => SetProperty(ref _revive, value);
        }

        private long _hp;
        public long HP
        {
            get => _hp;
            set => SetProperty(ref _hp, value);
        }

        public MulungBoss() : base()
        {
            Armor = 50;
        }



    }
}
