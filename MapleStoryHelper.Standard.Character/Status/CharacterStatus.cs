using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Character.Status
{
    //장비템에는 레벨 스테이터스가 없으나, 캐릭터에게는 레벨에따른 스테이터스가 있으므로 만들 필요가 있음.
    public class CharacterStatus : StatusBase
    {
        #region Property

        private double _levelStr;
        public double LevelStr
        {
            get => _levelStr;
            set => SetProperty(ref _levelStr, value);
        }

        private double _levelDex;
        public double LevelDex
        {
            get => _levelDex;
            set => SetProperty(ref _levelDex, value);
        }

        private double _levelInt;
        public double LevelInt
        {
            get => _levelInt;
            set => SetProperty(ref _levelInt, value);
        }

        private double _levelLuk;
        public double LevelLuk
        {
            get => _levelLuk;
            set => SetProperty(ref _levelLuk, value);
        }

        #endregion
    }
}
