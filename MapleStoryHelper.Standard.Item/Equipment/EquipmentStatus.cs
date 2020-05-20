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

        #region Potential

        private int _poStr;
        public int PoStr
        {
            get => _poStr;
            set => SetProperty(ref _poStr, value);
        }

        private int _poDex;
        public int PoDex
        {
            get => _poDex;
            set => SetProperty(ref _poDex, value);
        }

        private int _poInt;
        public int PoInt
        {
            get => _poInt;
            set => SetProperty(ref _poInt, value);
        }

        private int _poLuk;
        public int PoLuk
        {
            get => _poLuk;
            set => SetProperty(ref _poLuk, value);
        }

        private int _poHP;
        public int PoHP
        {
            get => _poInt;
            set => SetProperty(ref _poInt, value);
        }

        private int _poMP;
        public int PoMP
        {
            get => _poMP;
            set => SetProperty(ref _poMP, value);
        }

        private int _poPAllStatus;
        public int PoPAllStatus
        {
            get => _poPAllStatus;
            set => SetProperty(ref _poPAllStatus, value);
        }

        private int _poAttack;
        public int PoAttack
        {
            get => _poAttack;
            set => SetProperty(ref _poAttack, value);
        }

        private int _poMagic;
        public int PoMagic
        {
            get => _poMagic;
            set => SetProperty(ref _poMagic, value);
        }

        private int _poBossDamage;
        public int PoBossDamage
        {
            get => _poBossDamage;
            set => SetProperty(ref _poBossDamage, value);
        }

        #endregion

        #region AdditionalPotential

        private int _adPoStr;
        public int AdPoStr
        {
            get => _adPoStr;
            set => SetProperty(ref _adPoStr, value);
        }

        private int _adPoDex;
        public int AdPoDex
        {
            get => _adPoDex;
            set => SetProperty(ref _adPoDex, value);
        }

        private int _adPoInt;
        public int AdPoInt
        {
            get => _adPoInt;
            set => SetProperty(ref _adPoInt, value);
        }

        private int _adPoLuk;
        public int AdPoLuk
        {
            get => _adPoLuk;
            set => SetProperty(ref _adPoLuk, value);
        }

        private int _adPoHP;
        public int AdPoHP
        {
            get => _adPoInt;
            set => SetProperty(ref _adPoInt, value);
        }

        private int _adPoMP;
        public int AdPoMP
        {
            get => _adPoMP;
            set => SetProperty(ref _adPoMP, value);
        }

        private int _adPoPAllStatus;
        public int AdPoPAllStatus
        {
            get => _adPoPAllStatus;
            set => SetProperty(ref _adPoPAllStatus, value);
        }

        private int _adPoAttack;
        public int AdPoAttack
        {
            get => _adPoAttack;
            set => SetProperty(ref _adPoAttack, value);
        }

        private int _adPoMagic;
        public int AdPoMagic
        {
            get => _adPoMagic;
            set => SetProperty(ref _adPoMagic, value);
        }

        private int _adPoBossDamage;
        public int AdPoBossDamage
        {
            get => _adPoBossDamage;
            set => SetProperty(ref _adPoBossDamage, value);
        }

        #endregion

        #endregion
    }
}
