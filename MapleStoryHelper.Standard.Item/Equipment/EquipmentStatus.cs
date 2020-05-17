using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item.Equipment
{
    public class EquipmentStatus : StatusBase
    {
        public EquipmentItem Equipment { get; set; }

        #region Property

        private int _adStr;
        public int AdStr
        {
            get => _adStr;
            set => SetProperty(ref _adStr, value);
        }

        private int _adDex;
        public int AdDex
        {
            get => _adDex;
            set => SetProperty(ref _adDex, value);
        }

        private int _adInt;
        public int AdInt
        {
            get => _adInt;
            set => SetProperty(ref _adInt, value);
        }

        private int _adLuk;
        public int AdLuk
        {
            get => _adLuk;
            set => SetProperty(ref _adLuk, value);
        }

        private int _adHP;
        public int AdHP
        {
            get => _adInt;
            set => SetProperty(ref _adInt, value);
        }

        private int _adMP;
        public int AdMP
        {
            get => _adMP;
            set => SetProperty(ref _adMP, value);
        }

        private int _adPAllStatus;
        public int AdPAllStatus
        {
            get => _adPAllStatus;
            set => SetProperty(ref _adPAllStatus, value);
        }

        private int _adAttack;
        public int AdAttack
        {
            get => _adAttack;
            set => SetProperty(ref _adAttack, value);
        }

        private int _adMagic;
        public int AdMagic
        {
            get => _adMagic;
            set => SetProperty(ref _adMagic, value);
        }

        private int _adBossDamage;
        public int AdBossDamage
        {
            get => _adBossDamage;
            set => SetProperty(ref _adBossDamage, value);
        }

        #endregion
    }
}
