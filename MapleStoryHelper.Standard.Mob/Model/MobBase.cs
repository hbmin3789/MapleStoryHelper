using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Mob.Model
{
    public class MobBase : StatusBase
    {
        private string _mobName;
        public string MobName
        {
            get => _mobName;
            set => SetProperty(ref _mobName, value);
        }


    }
}
