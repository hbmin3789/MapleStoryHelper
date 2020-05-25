using MapleStoryHelper.Standard.Character.Status;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Resources;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace MapleStoryHelper.Standard.Character
{
    [Table("character")]
    public class CharacterBase : BindableBase
    {
        private string _primaryKey;
        [Key]
        [Column("primarykey")]
        public string PrimaryKey
        {
            get => _primaryKey;
            set => SetProperty(ref _primaryKey, value);
        }

        #region Property

        public EStatus MainStatus { get; set; }
        public EStatus SubStatus { get; set; }

        private string _imageSrc;
        [Column("image_source")]
        public string ImageSrc
        {
            get=>_imageSrc;
            set => SetProperty(ref _imageSrc, value);
        }

        private string _characterName;
        [Column("character_name")]
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
        [Column("level")]
        public int Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        private ECharacterJob _characterJob;
        [Column("character_job")]
        public ECharacterJob CharacterJob
        {
            get => _characterJob;
            set => SetProperty(ref _characterJob, value);
        }

        private EJobCategory _jobCategory;
        [Column("job_category")]
        public EJobCategory JobCategory
        {
            get => _jobCategory;
            set => SetProperty(ref _jobCategory, value);
        }

        private CharacterStatus _characterStatus;
        [NotMapped]
        public CharacterStatus CharacterStatus
        {
            get
            {
                _characterStatus = GetCharacterStatus();
                return _characterStatus;
            }
            set => SetProperty(ref _characterStatus, value);
        }

        private bool _isUseAttackPower;
        [Column("is_use_attackpower")]
        public bool IsUseAttackPower
        {
            get => _isUseAttackPower;
            set => SetProperty(ref _isUseAttackPower, value);
        }

        private double _weaponConst;
        [Column("weapon_const")]
        public double WeaponConst
        {
            get => _weaponConst;
            set => SetProperty(ref _weaponConst, value);
        }

        private double _jobConst;
        [Column("job_const")]
        public double JobConst
        {
            get => _jobConst;
            set => SetProperty(ref _jobConst, value);
        }

        private EJobLevel _jobLevel;
        [Column("job_level")]
        public EJobLevel JobLevel
        {
            get => _jobLevel;
            set => SetProperty(ref _jobLevel, value);
        }

        private CharacterEquipment _characterEquipment;
        [NotMapped]
        public CharacterEquipment CharacterEquipment
        {
            get => _characterEquipment;
            set => SetProperty(ref _characterEquipment, value);
        }

        private MHResource _characterImage;
        [NotMapped]
        public MHResource CharacterImage
        {
            get => _characterImage;
            set => SetProperty(ref _characterImage, value);
        }

        public int MinStatusAttackBinding
        {
            get => GetMinStatusAttack(MainStatus, SubStatus);
        }

        public int MaxStatusAttackBinding
        {
            get => GetMaxStatusAttack(MainStatus, SubStatus);
        }

        #endregion

        public CharacterBase()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            CharacterEquipment = new CharacterEquipment();
            _characterImage = new MHResource();
            _jobLevel = EJobLevel.First;
            _level = 1;
        }

        public void SetCharacterJob(ECharacterJob characterJob)
        {
            CharacterJob = characterJob;
            SetJobConst(characterJob);
        }

        private void SetJobConst(ECharacterJob characterJob)
        {
            switch (characterJob)
            {
                case ECharacterJob.ArchMage_FirePoison:
                case ECharacterJob.ArchMage_IceLightning:
                case ECharacterJob.Bishop:
                case ECharacterJob.BlazeWizard:
                    JobConst = 1.2;
                    break;
                case ECharacterJob.Xenon:
                    JobConst = 0.875;
                    break;
                default:
                    JobConst = 1;
                    break;
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


        private double GetCharacterPercent(StatusBase status)
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

        private double GetCharacterConstant()
        {
            double retval = 0;

            retval += WeaponConst;
            retval *= JobConst;
            retval *= 0.01;

            return retval;
        }

        public CharacterStatus GetCharacterStatus()
        {
            CharacterStatus retval = new CharacterStatus();

            for (int i = 0; i < CharacterEquipment.EquipList.Count; i++)
            {
                retval = retval + (CharacterEquipment.EquipList.ElementAt(i).Value.Status.GetStatus<CharacterStatus>() as CharacterStatus);
            }

            return retval;
        }

        #endregion
    }
}
