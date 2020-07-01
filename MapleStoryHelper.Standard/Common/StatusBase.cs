using Prism.Mvvm;

namespace MapleStoryHelper.Standard
{

    public class StatusBase : BindableBase
    {
        public static StatusBase operator +(StatusBase a, StatusBase b)
        {
            StatusBase retval = new StatusBase()
            {
                AllStatus = a.AllStatus + b.AllStatus,
                CAllStatus = a.CAllStatus + b.CAllStatus,
                PAllStatus = a.PAllStatus + b.PAllStatus,
                AttackPower = a.AttackPower + b.AttackPower,
                PAttackPower = a.PAttackPower + b.PAttackPower,
                CAttackPower = a.CAttackPower + b.CAttackPower,
                MagicAttack = a.MagicAttack + b.MagicAttack,
                CMagicAttack = a.CMagicAttack + b.CMagicAttack,
                PMagicAttack = a.PMagicAttack + b.PMagicAttack,
                Str = a.Str + b.Str,
                Dex = a.Dex + b.Dex,
                Int = a.Int + b.Int,
                Luk = a.Luk + b.Luk,
                CStr = a.CStr + b.CStr,
                CDex = a.CDex + b.CDex,
                CInt = a.CInt + b.CInt,
                CLuk = a.CLuk + b.CLuk,
                PStr = a.PStr + b.PStr,
                PDex = a.PDex + b.PDex,
                PInt = a.PInt + b.PInt,
                PLuk = a.PLuk + b.PLuk,
                HP = a.HP + b.HP,
                CHP = a.CHP + b.CHP,
                PHP = a.PHP + b.PHP,
                MP = a.MP + b.MP,
                CMP = a.CMP + b.CMP,
                PMP = a.PMP + b.PMP,
                BossDamage = a.BossDamage + b.BossDamage,
                Critical = a.Critical + b.Critical,
                Damage = a.Damage + b.Damage,
                CriticalDamage = a.CriticalDamage + b.CriticalDamage,
                LastDamage = a.LastDamage + b.LastDamage,
                AdPAllStatus = a.AdPAllStatus + b.AdPAllStatus
            };

            if (a.IgnoreDef != 0 || b.IgnoreDef != 0)
            {
                retval.IgnoreDef = (1 - ((1 - a.IgnoreDef / 100) * (1 - b.IgnoreDef / 100))) * 100;
            }

            return retval;
        }

        private string _primaryKey;
        public string PrimaryKey
        {
            get => _primaryKey;
            set => SetProperty(ref _primaryKey, value);
        }


        #region Properties

        #region Binding

        public int AttackBinding
        {
            get => GetAttackPower();
            set { }
        }

        public int PAttackBinding
        {
            get => GetAttackPower();
            set { }
        }

        public int MagicBinding
        {
            get => GetMagicAttack();
            set { }
        }

        public int PMagicBinding
        {
            get => GetMagicAttack();
            set { }
        }

        public int StrBinding
        {
            get => GetSTR();
            set { }
        }

        public int DexBinding
        {
            get => GetDEX();
            set { }
        }

        public int IntBinding
        {
            get => GetINT();
            set { }
        }

        public int LukBinding
        {
            get => GetLUK();
            set { }
        }

        public int HPBinding
        {
            get => GetHP();
            set { }
        }

        public int MPBinding
        {
            get => GetMP();
            set { }
        }

        public int PStrBinding
        {
            get => GetPSTR();
            set { }
        }

        public int PDexBinding
        {
            get => GetPDEX();
            set { }
        }

        public int PIntBinding
        {
            get => GetPINT();
            set { }
        }

        public int PLukBinding
        {
            get => GetPLUK();
            set { }
        }

        public int PHPBinding
        {
            get => GetPHP();
            set { }
        }

        public int PMPBinding
        {
            get => GetPMP();
            set { }
        }

        public int CriticalBinding
        {
            get => Critical;
            set { }
        }

        public double CriticalDamageBinding
        {
            get => CriticalDamage;
            set { }
        }

        public double DamageBinding
        {
            get => Damage;
            set { }
        }

        public double BossDamageBinding
        {
            get => BossDamage;
            set { }
        }

        #endregion

        #region Percentable Status

        private int _allStatus;
        public int AllStatus
        {
            get => _allStatus;
            set
            {
                SetProperty(ref _allStatus, value);
            }
        }

        private double _str;
        public double Str
        {
            get => _str;
            set 
            {
                SetProperty(ref _str, value);
            }
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

        private long _hp;
        public long HP
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

        private int _critical;
        public int Critical
        {
            get => _critical;
            set => SetProperty(ref _critical, value);
        }

        private double _criticalDamage;
        public double CriticalDamage
        {
            get => _criticalDamage;
            set => SetProperty(ref _criticalDamage, value);
        }

        private double _ignoreDef = 0;
        public double IgnoreDef
        {
            get => _ignoreDef;
            set => SetProperty(ref _ignoreDef, value);
        }

        private int _adPAllStatus;
        public int AdPAllStatus
        {
            get => _adPAllStatus;
            set => SetProperty(ref _adPAllStatus, value);
        }

        #endregion

        #endregion

        #region Methods

        #region GetStatus Method

        public int GetSTR()
        {
            return (int)((Str + AllStatus) * (1 + ((double)PStr / 100)) * (1 + (double)AdPAllStatus / 100)) + CStr + CAllStatus;
        }

        public int GetDEX()
        {
            return (int)((_dex + AllStatus) * (1 + ((double)PDex / 100)) * (1 + (double)AdPAllStatus / 100)) + CDex + CAllStatus;
        }

        public int GetINT()
        {
            return (int)(_int + AllStatus * (1 + ((double)PInt / 100)) * (1 + (double)AdPAllStatus / 100)) + CInt + CAllStatus;
        }

        public int GetLUK()
        {
            return (int)(_luk + AllStatus * (1 + ((double)PLuk / 100)) * (1 + (double)AdPAllStatus / 100)) + CLuk + CAllStatus;
        }

        public int GetHP()
        {
            return (int)(_hp * (1 + ((double)PHP / 100))) + CHP;
        }

        public int GetMP()
        {
            return (int)(_mp * (1 + ((double)PMP / 100))) + CMP;
        }

        public int GetAttackPower()
        {
            return (int)(AttackPower + CAttackPower);
        }

        public int GetMagicAttack()
        {
            return (int)(MagicAttack + CMagicAttack);
        }


        public int GetPSTR()
        {
            return PStr + PAllStatus;
        }

        public int GetPDEX()
        {
            return PDex + PAllStatus;
        }

        public int GetPINT()
        {
            return PInt + PAllStatus;
        }

        public int GetPLUK()
        {
            return PLuk + PAllStatus;
        }

        public int GetPHP()
        {
            return PHP;
        }

        public int GetPMP()
        {
            return PMP;
        }

        public int GetPAttackPower()
        {
            return PAttackPower;
        }

        public int GetPMagicAttack()
        {
            return PMagicAttack;
        }


        #endregion


        #endregion

    }
}
