using MapleStoryHelper.Standard.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace MapleStoryHelper.Standard
{
    public class StatusBase : BindableBase
    {
        #region Properties

        #region Percentable Status

        private int _AllStatus;
        public int AllStatus
        {
            get => _AllStatus;
            set => SetProperty(ref _AllStatus, value);
        }

        private double _str;
        public double Str
        {
            get => _str;
            set => SetProperty(ref _str, value);
        }

        private double _dex;
        public double Dex
        {
            get => _dex;
            set => SetProperty(ref _dex, value);
        }

        private double _int;
        public double Int
        {
            get => _int;
            set => SetProperty(ref _int, value);
        }

        private double _luk;
        public double Luk
        {
            get => _luk;
            set => SetProperty(ref _luk, value);
        }

        private int _hp;
        public int HP
        {
            get => _hp;
            set => SetProperty(ref _hp, value);
        }

        private int _mp;
        public int MP
        {
            get => _mp;
            set => SetProperty(ref _mp, value);
        }

        private double _attackPower;
        public double AttackPower
        {
            get => _attackPower;
            set => SetProperty(ref _attackPower, value);
        }

        private double _magicAttack;
        public double MagicAttack
        {
            get => _magicAttack;
            set => SetProperty(ref _magicAttack, value);
        }

        #endregion

        #region UnPercentable Status

        private int _cAllStatus;
        public int CAllStatus
        {
            get => _cAllStatus;
            set => SetProperty(ref _cAllStatus, value);
        }

        private int _cStr;
        public int CStr
        {
            get => _cStr;
            set => SetProperty(ref _cStr, value);
        }

        private int _cDex;
        public int CDex
        {
            get => _cDex;
            set => SetProperty(ref _cDex, value);
        }

        private int _cInt;
        public int CInt
        {
            get => _cInt;
            set => SetProperty(ref _cInt, value);
        }

        private int _cLuk;
        public int CLuk
        {
            get => _cLuk;
            set => SetProperty(ref _cLuk, value);
        }

        private int _cHP;
        public int CHP
        {
            get => _cHP;
            set => SetProperty(ref _cHP, value);
        }

        private int _cMP;
        public int CMP
        {
            get => _cMP;
            set => SetProperty(ref _cMP, value);
        }

        private int _cAttackPower;
        public int CAttackPower
        {
            get => _cAttackPower;
            set => SetProperty(ref _cAttackPower, value);
        }

        private int _cMagicAttack;
        public int CMagicAttack
        {
            get => _cMagicAttack;
            set => SetProperty(ref _cMagicAttack, value);
        }

        #endregion

        #region Status Percent

        private int _pAllStatus;
        public int PAllStatus
        {
            get => _pAllStatus;
            set => SetProperty(ref _pAllStatus, value);
        }

        private int _pStr;
        public int PStr
        {
            get => _pStr;
            set => SetProperty(ref _pStr, value);
        }

        private int _pDex;
        public int PDex
        {
            get => _pDex;
            set => SetProperty(ref _pDex, value);
        }

        private int _pInt;
        public int PInt
        {
            get => _pInt;
            set => SetProperty(ref _pInt, value);
        }

        private int _pLuk;
        public int PLuk
        {
            get => _pLuk;
            set => SetProperty(ref _pLuk, value);
        }

        private int _pHP;
        public int PHP
        {
            get => _pHP;
            set => SetProperty(ref _pHP, value);
        }

        private int _pMP;
        public int PMP
        {
            get => _pMP;
            set => SetProperty(ref _pMP, value);
        }

        private int _pAttackPower;
        public int PAttackPower
        {
            get => _pAttackPower;
            set => SetProperty(ref _pAttackPower, value);
        }

        private int _pMagicAttack;
        public int PMagicAttack
        {
            get => _pMagicAttack;
            set => SetProperty(ref _pMagicAttack, value);
        }

        #endregion

        #region Major Status

        private double _statusAttack;
        public double StatusAttack
        {
            get => _statusAttack;
            set => SetProperty(ref _statusAttack, value);
        }

        private double _damage;
        public double Damage
        {
            get => _damage;
            set => SetProperty(ref _damage, value);
        }

        private double _lastDamage;
        public double LastDamage
        {
            get => _lastDamage;
            set => SetProperty(ref _lastDamage, value);
        }

        private double _bossDamage;
        public double BossDamage
        {
            get => _bossDamage;
            set => SetProperty(ref _bossDamage, value);
        }

        private double _ignoreDef;
        public double IgnoreDef
        {
            get => _ignoreDef;
            set => SetProperty(ref _ignoreDef, value);
        }

        #endregion

        #endregion

        #region Methods

        #region GetStatus Method

        public int GetSTR()
        {
            return (int)(Str * (1 + (PStr / 100))) + CStr;
        }

        public int GetDEX()
        {
            return (int)(Dex * (1 + (PDex / 100))) + CDex;
        }

        public int GetINT()
        {
            return (int)(Int * (1 + (PInt / 100))) + CInt;
        }

        public int GetLUK()
        {
            return (int)(Luk * (1 + (PLuk / 100))) + CLuk;
        }

        public int GetHP()
        {
            return (int)(HP * (1 + (PHP / 100))) + CHP;
        }

        public int GetMP()
        {
            return (int)(MP * (1 + (PMP / 100))) + CMP;
        }

        public int GetAttackPower()
        {
            return (int)(AttackPower * (1 + (PAttackPower / 100))) + CAttackPower;
        }

        public int GetMagicAttack()
        {
            return (int)(MagicAttack * (1 + (PMagicAttack / 100))) + CMagicAttack;
        }

        #endregion

        #region GetStatusAttack Method

        

        #endregion

        #endregion

    }
}
