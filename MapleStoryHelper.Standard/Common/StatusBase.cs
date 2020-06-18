using MapleStoryHelper.Standard.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text;

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
            };

            retval.IgnoreDef = new List<double>(a.IgnoreDef);

            for(int i = 0; i < b.IgnoreDef.Count; i++)
            {
                retval.IgnoreDef.Add(b.IgnoreDef[i]);
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
        [Column("dex")]
        public double Dex
        {
            get => _dex;
            set => SetProperty(ref _dex, value);
        }

        private double _int;
        [Column("int")]
        public double Int
        {
            get => _int;
            set => SetProperty(ref _int, value);
        }

        private double _luk;
        [Column("luk")]
        public double Luk
        {
            get => _luk;
            set => SetProperty(ref _luk, value);
        }

        private long _hp;
        [Column("hp")]
        public long HP
        {
            get => _hp;
            set => SetProperty(ref _hp, value);
        }

        private int _mp;
        [Column("mp")]
        public int MP
        {
            get => _mp;
            set => SetProperty(ref _mp, value);
        }

        private double _attackPower;
        [Column("attackpower")]
        public double AttackPower
        {
            get => _attackPower;
            set => SetProperty(ref _attackPower, value);
        }

        private double _magicAttack;
        [Column("magicattack")]
        public double MagicAttack
        {
            get => _magicAttack;
            set => SetProperty(ref _magicAttack, value);
        }

        #endregion

        #region UnPercentable Status

        private int _cAllStatus;
        [Column("callstatus")]
        public int CAllStatus
        {
            get => _cAllStatus;
            set => SetProperty(ref _cAllStatus, value);
        }

        private int _cStr;
        [Column("cstr")]
        public int CStr
        {
            get => _cStr;
            set => SetProperty(ref _cStr, value);
        }

        private int _cDex;
        [Column("cdex")]
        public int CDex
        {
            get => _cDex;
            set => SetProperty(ref _cDex, value);
        }

        private int _cInt;
        [Column("cint")]
        public int CInt
        {
            get => _cInt;
            set => SetProperty(ref _cInt, value);
        }

        private int _cLuk;
        [Column("cluk")]
        public int CLuk
        {
            get => _cLuk;
            set => SetProperty(ref _cLuk, value);
        }

        private int _cHP;
        [Column("chp")]
        public int CHP
        {
            get => _cHP;
            set => SetProperty(ref _cHP, value);
        }

        private int _cMP;
        [Column("cmp")]
        public int CMP
        {
            get => _cMP;
            set => SetProperty(ref _cMP, value);
        }

        private int _cAttackPower;
        [Column("cattackpower")]
        public int CAttackPower
        {
            get => _cAttackPower;
            set => SetProperty(ref _cAttackPower, value);
        }

        private int _cMagicAttack;
        [Column("cmagicattack")]
        public int CMagicAttack
        {
            get => _cMagicAttack;
            set => SetProperty(ref _cMagicAttack, value);
        }

        #endregion

        #region Status Percent

        private int _pAllStatus;
        [Column("pallstatus")]
        public int PAllStatus
        {
            get => _pAllStatus;
            set => SetProperty(ref _pAllStatus, value);
        }

        private int _pStr;
        [Column("pstr")]
        public int PStr
        {
            get => _pStr;
            set => SetProperty(ref _pStr, value);
        }

        private int _pDex;
        [Column("pdex")]
        public int PDex
        {
            get => _pDex;
            set => SetProperty(ref _pDex, value);
        }

        private int _pInt;
        [Column("pint")]
        public int PInt
        {
            get => _pInt;
            set => SetProperty(ref _pInt, value);
        }

        private int _pLuk;
        [Column("pluk")]
        public int PLuk
        {
            get => _pLuk;
            set => SetProperty(ref _pLuk, value);
        }

        private int _pHP;
        [Column("php")]
        public int PHP
        {
            get => _pHP;
            set => SetProperty(ref _pHP, value);
        }

        private int _pMP;
        [Column("pmp")]
        public int PMP
        {
            get => _pMP;
            set => SetProperty(ref _pMP, value);
        }

        private int _pAttackPower;
        [Column("pattackpower")]
        public int PAttackPower
        {
            get => _pAttackPower;
            set => SetProperty(ref _pAttackPower, value);
        }

        private int _pMagicAttack;
        [Column("pmagicattack")]
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
        [Column("damage")]
        public double Damage
        {
            get => _damage;
            set => SetProperty(ref _damage, value);
        }

        private double _lastDamage;
        [Column("last_damage")]
        public double LastDamage
        {
            get => _lastDamage;
            set => SetProperty(ref _lastDamage, value);
        }

        private double _bossDamage;
        [Column("boss_damage")]
        public double BossDamage
        {
            get => _bossDamage;
            set => SetProperty(ref _bossDamage, value);
        }

        private int _critical;
        [Column("critical")]
        public int Critical
        {
            get => _critical;
            set => SetProperty(ref _critical, value);
        }

        private double _criticalDamage;
        [Column("critical_damage")]
        public double CriticalDamage
        {
            get => _criticalDamage;
            set => SetProperty(ref _criticalDamage, value);
        }

        private List<double> _ignoreDef = new List<double>();
        [NotMapped]
        public List<double> IgnoreDef
        {
            get => _ignoreDef;
            set
            {
                SetProperty(ref _ignoreDef, value);
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IgnoreDefBinding)));
            }
        }
        public double IgnoreDefBinding
        {
            get => GetIgnoreDef();
            set { }
        }

        #endregion

        #endregion

        #region Methods

        #region GetStatus Method

        public int GetSTR()
        {
            return (int)((Str + AllStatus) * (1 + ((double)(PStr + PAllStatus) / 100))) + CStr + CAllStatus;
        }

        public int GetDEX()
        {
            return (int)((_dex + AllStatus) * (1 + ((double)(PDex + PAllStatus) / 100))) + CDex + CAllStatus;
        }

        public int GetINT()
        {
            return (int)(_int + AllStatus * (1 + ((double)(PInt + PAllStatus) / 100))) + CInt + CAllStatus;
        }

        public int GetLUK()
        {
            return (int)(_luk + AllStatus * (1 + ((double)(PLuk + PAllStatus) / 100))) + CLuk + CAllStatus;
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

        private double GetIgnoreDef()
        {
            //1 - (1 - %) - (1 - %) ...
            double retval = 1.0;

            if(IgnoreDef.Count == 0)
            {
                return 0;
            }

            double temp = 1;

            for(int i = 0; i < IgnoreDef.Count; i++)
            {
                temp *= ((100.0 - IgnoreDef[i]) / 100.0);
            }

            temp *= 100;
            retval *= 100;

            retval -= temp;

            return retval;
        }

        #endregion

    }
}
