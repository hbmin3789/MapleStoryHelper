using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item.Equipment
{
    public class EquipmentStatus : StatusBase
    {
        public static EquipmentStatus operator +(EquipmentStatus a, EquipmentStatus b)
        {
            EquipmentStatus retval = new EquipmentStatus()
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
                AdStr = a.AdStr + b.AdStr,
                AdDex = a.AdDex + b.AdDex,
                AdInt = a.AdInt + b.AdInt,
                AdLuk = a.AdLuk + b.AdLuk,
                AdHP = a.AdHP + b.AdHP,
                AdMP = a.AdMP + b.AdMP,
                AdPAllStatus = a.AdPAllStatus + b.AdPAllStatus,
                AdAttack = a.AdAttack + b.AdAttack,
                AdMagic = a.AdMagic + b.AdMagic,
                AdBossDamage = a.AdBossDamage + b.AdBossDamage,
                PoStr = a.PoStr + b.PoStr,
                PoDex = a.PoDex + b.PoDex,
                PoInt = a.PoInt + b.PoInt,
                PoLuk = a.PoLuk + b.PoLuk,
                PoHP = a.PoHP + b.PoHP,
                PoMP = a.PoMP + b.PoMP,
                PoAttack = a.PoAttack + b.PoAttack,
                PoMagic = a.PoMagic + b.PoMagic,
                PoPStr = a.PoPStr + b.PoPStr,
                PoPDex = a.PoPDex + b.PoPDex,
                PoPInt = a.PoPInt + b.PoPInt,
                PoPLuk = a.PoPLuk + b.PoPLuk,
                PoPHP = a.PoPHP + b.PoPHP,
                PoPMP = a.PoPMP + b.PoPMP,
                PoPAttack = a.PoPAttack + b.PoPAttack,
                PoPMagic = a.PoPMagic + b.PoPMagic,
                PoAllStatus = a.PoAllStatus + b.PoAllStatus,
                PoBossDamage = a.PoBossDamage + b.PoBossDamage,
                PoCritDamage = a.PoCritDamage + b.PoCritDamage,
                PoCritical = a.PoCritical + b.PoCritical,
                PoDamage = a.PoDamage + b.PoDamage,
                PoPAllStatus = a.PoPAllStatus + b.PoPAllStatus,
                AdPoStr = a.AdPoStr + b.AdPoStr,
                AdPoDex = a.AdPoDex + b.AdPoDex,
                AdPoInt = a.AdPoInt + b.AdPoInt,
                AdPoLuk = a.AdPoLuk + b.AdPoLuk,
                AdPoAttack = a.AdPoAttack + b.AdPoAttack,
                AdPoMagic = a.AdPoMagic + b.AdPoMagic,
                AdPoPStr = a.AdPoPStr + b.AdPoPStr,
                AdPoPDex = a.AdPoPDex + b.AdPoPDex,
                AdPoPInt = a.AdPoPInt + b.AdPoPInt,
                AdPoPLuk = a.AdPoPLuk + b.AdPoPLuk,
                AdPoPHP = a.PoPHP + b.PoPHP,
                AdPoPMP = a.PoPMP + b.PoPMP,
                AdPoPAttack = a.PoPAttack + b.PoPAttack,
                AdPoPMagic = a.PoPMagic + b.PoPMagic,
                AdPoAllStatus = a.AdPoAllStatus + b.AdPoAllStatus,
                AdPoBossDamage = a.AdPoBossDamage + b.AdPoBossDamage,
                AdPoCritDamage = a.AdPoCritDamage + b.AdPoCritDamage,
                AdPoCritical = a.AdPoCritical + b.AdPoCritical,
                AdPoDamage = a.AdPoDamage + b.AdPoDamage,
                AdPoHP = a.AdPoHP + b.AdPoHP,
                AdPoMP = a.AdPoMP + b.AdPoMP,
                AdPoPAllStatus = a.AdPoPAllStatus + b.AdPoPAllStatus,
                ScAllStatus = a.ScAllStatus + b.ScAllStatus,
                ScAttack = a.ScAttack + b.ScAttack,
                ScDex = a.ScDex + b.ScDex,
                ScHP = a.ScHP + b.ScHP,
                ScInt = a.ScInt + b.ScInt,
                ScLuk = a.ScLuk + b.ScLuk,
                ScMagic = a.ScMagic + b.ScMagic,
                ScMP = a.ScMP + b.ScMP,
                ScStr = a.ScStr + b.ScStr,
            };

            retval.IgnoreDef = 1 - ((1 - a.IgnoreDef / 100) * (1 - b.IgnoreDef / 100));
            retval.PoIgnoreDef = a.PoIgnoreDef;
            retval.AdPoIgnoreDef = a.AdPoIgnoreDef;

            retval.PoIgnoreDef = 1 - ((1 - a.PoIgnoreDef / 100) * (1 - b.PoIgnoreDef / 100));

            retval.AdPoIgnoreDef = 1 - ((1 - a.AdPoIgnoreDef / 100) * (1 - b.AdPoIgnoreDef / 100));

            return retval;
        }

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
            get => _adHP;
            set => SetProperty(ref _adHP, value);
        }

        private int _adMP;
        public int AdMP
        {
            get => _adMP;
            set => SetProperty(ref _adMP, value);
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
            get => _scHP;
            set => SetProperty(ref _scHP, value);
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

        private int _poPStr;
        public int PoPStr
        {
            get => _poPStr;
            set => SetProperty(ref _poPStr, value);
        }

        private int _poPDex;
        public int PoPDex
        {
            get => _poPDex;
            set => SetProperty(ref _poPDex, value);
        }

        private int _poPInt;
        public int PoPInt
        {
            get => _poPInt;
            set => SetProperty(ref _poPInt, value);
        }

        private int _poPLuk;
        public int PoPLuk
        {
            get => _poPLuk;
            set => SetProperty(ref _poPLuk, value);
        }

        private int _poHP;
        public int PoHP
        {
            get => _poHP;
            set => SetProperty(ref _poHP, value);
        }

        private int _poMP;
        public int PoMP
        {
            get => _poMP;
            set => SetProperty(ref _poMP, value);
        }

        private int _poPHP;
        public int PoPHP
        {
            get => _poPHP;
            set => SetProperty(ref _poPHP, value);
        }

        private int _poPMP;
        public int PoPMP
        {
            get => _poPMP;
            set => SetProperty(ref _poPMP, value);
        }

        private int _poAllStatus;
        public int PoAllStatus
        {
            get => _poAllStatus;
            set => SetProperty(ref _poAllStatus, value);
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

        private int _poPAttack;
        public int PoPAttack
        {
            get => _poPAttack;
            set => SetProperty(ref _poPAttack, value);
        }

        private int _poPMagic;
        public int PoPMagic
        {
            get => _poPMagic;
            set => SetProperty(ref _poPMagic, value);
        }

        private int _poBossDamage;
        public int PoBossDamage
        {
            get => _poBossDamage;
            set => SetProperty(ref _poBossDamage, value);
        }

        private int _poDamage;
        public int PoDamage
        {
            get => _poDamage;
            set => SetProperty(ref _poDamage, value);
        }

        private double _poIgnoreDef;
        public double PoIgnoreDef
        {
            get => _poIgnoreDef;
            set => SetProperty(ref _poIgnoreDef, value);
        }

        private int _poCritical;
        public int PoCritical
        {
            get => _poCritical;
            set => SetProperty(ref _poCritical, value);
        }

        private int _poCritDamage;
        public int PoCritDamage
        {
            get => _poCritDamage;
            set => SetProperty(ref _poCritDamage, value);
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

        private int _adPoPStr;
        public int AdPoPStr
        {
            get => _adPoPStr;
            set => SetProperty(ref _adPoPStr, value);
        }

        private int _adPoPDex;
        public int AdPoPDex
        {
            get => _adPoPDex;
            set => SetProperty(ref _adPoPDex, value);
        }

        private int _adPoPInt;
        public int AdPoPInt
        {
            get => _adPoPInt;
            set => SetProperty(ref _adPoPInt, value);
        }

        private int _adPoPLuk;
        public int AdPoPLuk
        {
            get => _adPoPLuk;
            set => SetProperty(ref _adPoPLuk, value);
        }

        private int _adPoHP;
        public int AdPoHP
        {
            get => _adPoHP;
            set => SetProperty(ref _adPoHP, value);
        }

        private int _adPoMP;
        public int AdPoMP
        {
            get => _adPoMP;
            set => SetProperty(ref _adPoMP, value);
        }

        private int _adPoPHP;
        public int AdPoPHP
        {
            get => _adPoPHP;
            set => SetProperty(ref _adPoPHP, value);
        }

        private int _adPoPMP;
        public int AdPoPMP
        {
            get => _adPoPMP;
            set => SetProperty(ref _adPoPMP, value);
        }

        private int _adPoAllStatus;
        public int AdPoAllStatus
        {
            get => _adPoAllStatus;
            set => SetProperty(ref _adPoAllStatus, value);
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

        private int _adPoPAttack;
        public int AdPoPAttack
        {
            get => _adPoPAttack;
            set => SetProperty(ref _adPoPAttack, value);
        }

        private int _adPoPMagic;
        public int AdPoPMagic
        {
            get => _adPoPMagic;
            set => SetProperty(ref _adPoPMagic, value);
        }

        private int _adPoBossDamage;
        public int AdPoBossDamage
        {
            get => _adPoBossDamage;
            set => SetProperty(ref _adPoBossDamage, value);
        }

        private int _adPoDamage;
        public int AdPoDamage
        {
            get => _adPoDamage;
            set => SetProperty(ref _adPoDamage, value);
        }

        private double _adPoIgnoreDef;
        public double AdPoIgnoreDef
        {
            get => _adPoIgnoreDef;
            set => SetProperty(ref _adPoIgnoreDef, value);
        }


        private int _adPoCritical;
        public int AdPoCritical
        {
            get => _adPoCritical;
            set => SetProperty(ref _adPoCritical, value);
        }

        

        private int _adPoCritDamage;
        public int AdPoCritDamage
        {
            get => _adPoCritDamage;
            set => SetProperty(ref _adPoCritDamage, value);
        }

        #endregion

        #endregion

        public EquipmentStatus() : base()
        {

        }

        public StatusBase GetStatus<T>() where T : StatusBase , new()
        {
            StatusBase retval = new T()
            {
                AllStatus = this.AllStatus + this.PoAllStatus + this.AdPoAllStatus,
                CAllStatus = this.CAllStatus,
                PAllStatus = this.PAllStatus + this.PoPAllStatus + this.AdPoPAllStatus,
                AttackPower = this.AttackPower + this.PoAttack + this.AdPoAttack + this.ScAttack,
                PAttackPower = this.PAttackPower + this.PoPAttack + this.AdPoPAttack,
                CAttackPower = this.CAttackPower,
                MagicAttack = this.MagicAttack + this.PoMagic + this.AdPoMagic + this.ScMagic,
                CMagicAttack = this.CMagicAttack,
                PMagicAttack = this.PMagicAttack + this.PoPMagic + this.AdPoPMagic,
                Str = this.Str + this.PoStr + this.AdPoStr + this.ScStr,
                Dex = this.Dex + this.PoDex + this.AdPoDex + this.ScDex,
                Int = this.Int + this.PoInt + this.AdPoInt + this.ScInt,
                Luk = this.Luk + this.PoLuk + this.AdPoLuk + this.ScLuk,
                CStr = this.CStr,
                CDex = this.CDex,
                CInt = this.CInt,
                CLuk = this.CLuk,
                PStr = this.PStr + this.PoPStr + this.AdPoStr,
                PDex = this.PDex + this.PoPDex + this.AdPoDex,
                PInt = this.PInt + this.PoPInt + this.AdPoInt,
                PLuk = this.PLuk + this.PoPLuk + this.AdPoLuk,
                HP = this.HP + this.PoHP + this.AdPoHP + this.ScHP,
                CHP = this.CHP,
                PHP = this.PHP + this.PoPHP + this.AdPoPHP,
                MP = this.MP + this.PoMP + this.AdPoMP + this.ScMP,
                CMP = this.CMP,
                PMP = this.PMP + this.PoPMP + this.AdPoPMP,
                BossDamage = this.BossDamage + this.PoBossDamage + this.AdPoBossDamage,
                Critical = this.Critical + this.PoCritical + this.AdPoCritical,
                Damage = this.Damage + this.PoDamage + this.AdPoDamage,
                CriticalDamage = this.CriticalDamage + this.PoCritDamage + this.AdPoCritDamage,
                LastDamage = this.LastDamage,
                IgnoreDef = this.IgnoreDef,
                AdPAllStatus = this.AdPAllStatus
            };

            retval.IgnoreDef *= (1 - PoIgnoreDef / 100);

            retval.IgnoreDef *= (1 - AdPoIgnoreDef / 100);


            return retval;
        }
    }
}
