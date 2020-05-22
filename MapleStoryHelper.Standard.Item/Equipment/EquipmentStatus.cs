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
            get => _adHP;
            set => SetProperty(ref _adHP, value);
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

        private List<int> _poIgnoreDef;
        public List<int> PoIgnoreDef
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

        private List<int> _adPoIgnoreDef;
        public List<int> AdPoIgnoreDef
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
            InitVariables();
        }

        private void InitVariables()
        {
            PoIgnoreDef = new List<int>();
            AdPoIgnoreDef = new List<int>();
        }

        public StatusBase GetStatus<T>() where T : StatusBase , new()
        {
            StatusBase retval = new T()
            {
                AllStatus = this.AllStatus + this.PoAllStatus + this.AdPoAllStatus,
                CAllStatus = this.CAllStatus + this.PoAllStatus + this.AdPoAllStatus,
                PAllStatus = this.PAllStatus + this.PoPAllStatus + this.AdPoPAllStatus,
                AttackPower = this.AttackPower + this.PoAttack + this.AdPoAttack,
                PAttackPower = this.PAttackPower + this.PoPAttack + this.AdPoPAttack,
                CAttackPower = this.CAttackPower,
                MagicAttack = this.MagicAttack + this.PoMagic + this.AdPoMagic,
                CMagicAttack = this.CMagicAttack,
                PMagicAttack = this.PMagicAttack + this.PoPMagic + this.AdPoPMagic,
                Str = this.Str + this.PoStr + this.AdPoStr,
                Dex = this.Dex + this.PoDex + this.AdPoDex,
                Int = this.Int + this.PoInt + this.AdPoInt,
                Luk = this.Luk + this.PoLuk + this.AdPoLuk,
                CStr = this.CStr,
                CDex = this.CDex,
                CInt = this.CInt,
                CLuk = this.CLuk,
                PStr = this.PStr + this.PoPStr + this.AdPoStr,
                PDex = this.PDex + this.PoPDex + this.AdPoDex,
                PInt = this.PInt + this.PoPInt + this.AdPoInt,
                PLuk = this.PLuk + this.PoPLuk + this.AdPoLuk,
                HP = this.HP + this.PoPHP + this.AdPoHP,
                CHP = this.CHP,
                PHP = this.PHP + this.PoPHP + this.AdPoPHP,
                MP = this.MP + this.PoMP + this.AdPoMP,
                CMP = this.CMP,
                PMP = this.PMP + this.PoPMP + this.AdPoPMP,
                BossDamage = this.BossDamage + this.PoBossDamage + this.AdPoBossDamage,
                Critical = this.Critical + this.PoCritical + this.AdPoCritical,
                Damage = this.Damage + this.PoDamage + this.AdPoDamage,
                CriticalDamage = this.CriticalDamage + this.PoCritDamage + this.AdPoCritDamage,
                LastDamage = this.LastDamage,
            };

            retval.IgnoreDef = new List<double>(this.IgnoreDef);

            for(int i = 0; i < this.PoIgnoreDef.Count; i++)
            {
                retval.IgnoreDef.Add(PoIgnoreDef[i]);
            }
            for (int i = 0; i < this.AdPoIgnoreDef.Count; i++)
            {
                retval.IgnoreDef.Add(AdPoIgnoreDef[i]);
            }


            return retval;
        }
    }
}
