using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.SkillLib.Model
{
    public class ActiveSkill : SkillBase
    {
        private int _percentDamage;
        public int PercentDamage
        {
            get => _percentDamage;
            set => SetProperty(ref _percentDamage, value);
        }

    }
}
