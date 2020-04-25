using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Character.Status
{
    //장비템에는 레벨 스테이터스가 없으나, 캐릭터에게는 레벨에따른 스테이터스가 있으므로 만들 필요가 있음.
    public class CharacterStatus : StatusBase
    {
        public Character Character = new Character();

        #region Property

        private double _levelStr;
        [Column("level_str")]
        public double LevelStr
        {
            get => _levelStr;
            set => SetProperty(ref _levelStr, value);
        }

        private double _levelDex;
        [Column("level_dex")]
        public double LevelDex
        {
            get => _levelDex;
            set => SetProperty(ref _levelDex, value);
        }

        private double _levelInt;
        [Column("level_int")]
        public double LevelInt
        {
            get => _levelInt;
            set => SetProperty(ref _levelInt, value);
        }

        private double _levelLuk;
        [Column("level_luk")]
        public double LevelLuk
        {
            get => _levelLuk;
            set => SetProperty(ref _levelLuk, value);
        }

        private double _levelHP;
        [Column("level_hp")]
        public double LevelHP
        {
            get => _levelHP;
            set => SetProperty(ref _levelHP, value);
        }

        private double _levelMP;
        [Column("level_mp")]
        public double LevelMP
        {
            get => _levelMP;
            set => SetProperty(ref _levelMP, value);
        }
        #endregion


    }
}
