using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Resources;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace MapleStoryHelper.Standard.Character.Model
{
    public class CharacterBase : BindableBase
    {

        public string PrimaryKey;

        #region Property

        public EStatus MainStatus { get; set; }
        public EStatus SubStatus { get; set; }

        private string _imageSrc;
        public string ImageSrc
        {
            get=>_imageSrc;
            set => SetProperty(ref _imageSrc, value);
        }

        private object _imgBitmapSource;
        public object ImgBitmapSource
        {
            get => _imgBitmapSource;
            set => SetProperty(ref _imgBitmapSource, value);
        }

        private string _characterName;
        public string CharacterName
        {
            get => _characterName;
            set => SetProperty(ref _characterName, value);
        }

        //숙련도
        private int _ripenPoint;
        public int RipenPoint
        {
            get => _ripenPoint;
            set => SetProperty(ref _ripenPoint, value);
        }

        private int _level;
        public int Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        private ECharacterJob _characterJob;
        public ECharacterJob CharacterJob
        {
            get => _characterJob;
            set 
            { 
                SetProperty(ref _characterJob, value);
                SetIsUseAttackPower();
            }
        }

        private EJobCategory _jobCategory;
        public EJobCategory JobCategory
        {
            get => _jobCategory;
            set => SetProperty(ref _jobCategory, value);
        }

        private StatusBase _characterStatus;
        public StatusBase CharacterStatus
        {
            get
            {
                _characterStatus = GetCharacterStatus();
                return _characterStatus;
            }
            set
            {
                SetProperty(ref _characterStatus, value);
            }
        }

        private bool _isUseAttackPower = true;
        public bool IsUseAttackPower
        {
            get => _isUseAttackPower;
            set => SetProperty(ref _isUseAttackPower, value);
        }

        public double WeaponConst
        {
            get => CharacterEquipment.EquipList[ECharacterEquipmentCategory.Weapon].WeaponConst;
        }

        public double JobConst
        {
            get => GetJobConst();
        }

        private EJobLevel _jobLevel;
        public EJobLevel JobLevel
        {
            get => _jobLevel;
            set => SetProperty(ref _jobLevel, value);
        }

        private CharacterEquipment _characterEquipment;
        public CharacterEquipment CharacterEquipment
        {
            get
            {
                CharacterEquipment_OnEquipChanged();
                return _characterEquipment;
            }
            set => SetProperty(ref _characterEquipment, value);
        }

        protected int _minStatusAttack;
        public int MinStatusAttack
        {
            get
            {
                _minStatusAttack = GetMinStatusAttack();
                return _minStatusAttack;
            }
            set => SetProperty(ref _minStatusAttack, value);
        }

        protected int _maxStatusAttack;
        public int MaxStatusAttack
        {
            get
            {
                _maxStatusAttack = GetMaxStatusAttack();
                MinStatusAttack = GetMinStatusAttack();
                return _maxStatusAttack;
            }
            set => SetProperty(ref _maxStatusAttack, value);
        }

        #endregion

        public CharacterBase()
        {
            InitVariables();
            SetPrimaryKey();
        }

        private void SetPrimaryKey()
        {
            PrimaryKey = Guid.NewGuid().ToString();
        }

        private void SetIsUseAttackPower()
        {
            switch (CharacterJob)
            {
                case ECharacterJob.ArchMage_FirePoison:
                case ECharacterJob.ArchMage_IceLightning:
                case ECharacterJob.BattleMage:
                case ECharacterJob.Luminous:
                case ECharacterJob.Evan:
                case ECharacterJob.BlazeWizard:
                case ECharacterJob.Bishop:
                case ECharacterJob.Kinesis:
                case ECharacterJob.Illium:
                    IsUseAttackPower = false;
                    break;

                default:
                    IsUseAttackPower = true;
                    break;
            }
        }

        private void InitVariables()
        {
            _characterEquipment = new CharacterEquipment();
            _characterStatus = new StatusBase();
            _jobLevel = EJobLevel.First;
            _level = 1;
            _characterJob = ECharacterJob.Hero;
            _characterName = string.Empty;
            MainStatus = EStatus.STR;
            SubStatus = EStatus.STR;
        }

        private void CharacterEquipment_OnEquipChanged()
        {
            MaxStatusAttack = 0;
        }

        public void SetCharacterJob(ECharacterJob characterJob)
        {
            CharacterJob = characterJob;
        }

        private double GetJobConst()
        {
            switch (CharacterJob)
            {
                case ECharacterJob.ArchMage_FirePoison:
                case ECharacterJob.ArchMage_IceLightning:
                case ECharacterJob.Bishop:
                case ECharacterJob.BlazeWizard:
                    return 1.2;
                case ECharacterJob.Xenon:
                    return 0.875;
                default:
                    return 1;
            }
        }

        #region StatusCalcMethod

        /*
        앞스공	숙련도% × 뒷스공

                물리 공격력 : (주스탯 × 4 + 부스탯) × 총공격력 × 무기상수 × 직업상수 × (1 + 공격력%) × (1 + 데미지%) × (1 + 최종데미지%) × 0.01
        뒷스공
                마법 공격력 : (주스탯 × 4 + 부스탯) × 총  마력 × 무기상수 × 직업상수 × (1 + 마력%) × (1 + 데미지%) × (1 + 최종데미지%) × 0.01
        데벤져                HP(AP투자) 14당 주스탯 환산값 1, 아이템HP 17.5당 주스탯 환산값 1, 힘이 부스탯
        */

        protected virtual int GetMinStatusAttack()
        {
            return GetMinStatusAttack(MainStatus, SubStatus);
        }

        protected virtual int GetMaxStatusAttack()
        {
            return GetMaxStatusAttack(MainStatus, SubStatus);
        }

        public int GetMaxStatusAttack(EStatus main, EStatus sub)
        {
            int retval = 0;
            int MainStatus = 0;
            int SubStatus = 0;
            double Constant = GetCharacterConstant();
            double Percent = GetCharacterPercent(CharacterStatus);

            GetCharacterMainStatus(ref MainStatus, main);
            GetCharacterMainStatus(ref SubStatus, sub);

            retval = (int)(((MainStatus * 4) + SubStatus) * Constant * Percent);

            return retval;
        }

        private void GetCharacterMainStatus(ref int MainStatus, EStatus main)
        {
            switch (main)
            {
                case EStatus.STR:
                    MainStatus = CharacterStatus.GetSTR();
                    break;
                case EStatus.DEX:
                    MainStatus = CharacterStatus.GetDEX();
                    break;
                case EStatus.INT:
                    MainStatus = CharacterStatus.GetINT();
                    break;
                case EStatus.LUK:
                    MainStatus = CharacterStatus.GetLUK();
                    break;
                case EStatus.HP:
                    MainStatus = CharacterStatus.GetHP();
                    break;
                case EStatus.MP:
                    MainStatus = CharacterStatus.GetMP();
                    break;
            }
        }

        public int GetMinStatusAttack(EStatus main, EStatus sub)
        {
            int retval = 0;
            int MaxStatus = GetMaxStatusAttack(main, sub);
            double temp = MaxStatus * ((double)RipenPoint / 100);
            retval = (int)temp;

            return retval;
        }


        protected double GetCharacterPercent(StatusBase status)
        {
            double retval = 0;

            if(IsUseAttackPower == true)
            {
                retval += status.GetAttackPower();
                retval *= (1 + (status.PAttackPower) / 100);
            }
            else
            {
                retval += status.GetMagicAttack();
                retval *= (1 + (status.PMagicAttack) / 100);
            }

            retval *= (1 + (status.Damage / 100));
            retval *= (1 + (status.LastDamage / 100));

            return retval;
        }

        protected double GetCharacterConstant()
        {
            double retval = 0;

            retval += WeaponConst;
            retval *= JobConst;
            retval *= 0.01;

            return retval;
        }

        public StatusBase GetCharacterStatus()
        {
            StatusBase retval = new StatusBase();
            StatusBase equipStatus = _characterEquipment.GetEquipStatus();

            retval = retval + equipStatus;

            return retval;
        }

        #endregion
    }
}
