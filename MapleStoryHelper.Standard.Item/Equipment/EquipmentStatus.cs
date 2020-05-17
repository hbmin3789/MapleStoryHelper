using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item.Equipment
{
    public class EquipmentStatus : StatusBase
    {
        public EquipmentItem Equipment { get; set; }

        #region Property

        #region Additional

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


        #region Scroll

        private int _scStr;
        public int ScStr
        {
            get => _scStr;
            set => SetProperty(ref _scStr, value);
        }

        private int _scDex;
        public int ScDex
        {
            get => _scDex;
            set => SetProperty(ref _scDex, value);
        }

        private int _scInt;
        public int ScInt
        {
            get => _scInt;
            set => SetProperty(ref _scInt, value);
        }

        private int _scLuk;
        public int ScLuk
        {
            get => _scLuk;
            set => SetProperty(ref _scLuk, value);
        }

        private int _scHP;
        public int ScHP
        {
            get => _scInt;
            set => SetProperty(ref _scInt, value);
        }

        private int _scMP;
        public int ScMP
        {
            get => _scMP;
            set => SetProperty(ref _scMP, value);
        }

        private int _scAllStatus;
        public int ScAllStatus
        {
            get => _scAllStatus;
            set => SetProperty(ref _scAllStatus, value);
        }

        private int _scAttack;
        public int ScAttack
        {
            get => _scAttack;
            set => SetProperty(ref _scAttack, value);
        }

        private int _scMagic;
        public int ScMagic
        {
            get => _scMagic;
            set => SetProperty(ref _scMagic, value);
        }

        #endregion


        #endregion
    }
}
