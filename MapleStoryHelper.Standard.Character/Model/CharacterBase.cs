using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Character.Model
{
    public class CharacterBase : BindableBase
    {
        public string PrimaryKey;

        #region Property
        #warning 카데나, 섀도어, 듀블은 제논처럼 따로 만들기
        public EStatus MainStatus { get; set; }
        public EStatus SubStatus { get; set; }

        public List<SetItem> SetItemList 
        {
            get => _characterEquipment.SetItemList;
            set => _characterEquipment.SetItemList = value;
        }

        protected string _imageSrc;
        public string ImageSrc
        {
            get=>_imageSrc;
            set => SetProperty(ref _imageSrc, value);
        }

        protected object _imgBitmapSource;
        public object ImgBitmapSource
        {
            get => _imgBitmapSource;
            set => SetProperty(ref _imgBitmapSource, value);
        }

        protected string _characterName;
        public string CharacterName
        {
            get => _characterName;
            set => SetProperty(ref _characterName, value);
        }

        //숙련도
        protected int _ripenPoint = 90;
        public int RipenPoint
        {
            get => _ripenPoint;
            set => SetProperty(ref _ripenPoint, value);
        }

        protected int _level;
        public int Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        protected EAdvancement _characterJob;
        public EAdvancement CharacterJob
        {
            get => _characterJob;
            set 
            { 
                SetProperty(ref _characterJob, value);
                SetIsUseAttackPower();
                SetMainStatus();
                SetSubStatus();
            }
        }

        protected ECharacterClass _jobCategory;
        public ECharacterClass JobCategory
        {
            get => _jobCategory;
            set => SetProperty(ref _jobCategory, value);
        }

        protected StatusBase _characterStatus;
        public StatusBase CharacterStatus
        {
            get => _characterStatus;
            set=> SetProperty(ref _characterStatus, value);
        }

        protected int _arcaneForce;
        public int ArcaneForce
        {
            get => _arcaneForce;
            set => SetProperty(ref _arcaneForce, value);
        }

        protected StatusBase _arcaneForceStatus;
        public StatusBase ArcaneForceStatus
        {
            get => _arcaneForceStatus;
            set => SetProperty(ref _arcaneForceStatus, value);
        }

        protected StatusBase _skillStatus;
        public StatusBase SkillStatus
        {
            get => _skillStatus;
            set => SetProperty(ref _skillStatus, value);
        }

        protected StatusBase _baseStatus;
        public StatusBase BaseStatus
        {
            get => _baseStatus;
            set => SetProperty(ref _baseStatus, value);
        }

        protected bool _isUseAttackPower = true;
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

        protected EJobLevel _jobLevel;
        public EJobLevel JobLevel
        {
            get => _jobLevel;
            set => SetProperty(ref _jobLevel, value);
        }

        protected CharacterEquipment _characterEquipment;
        public CharacterEquipment CharacterEquipment
        {
            get => _characterEquipment;
            set => SetProperty(ref _characterEquipment, value);
        }

        #endregion

        public CharacterBase()
        {
            InitVariables();
            SetPrimaryKey();
        }

        #region Initialize

        private void InitVariables()
        {
            _characterEquipment = new CharacterEquipment();
            _characterStatus = new StatusBase();
            _baseStatus = new StatusBase();
            _skillStatus = new StatusBase();
            _arcaneForceStatus = new StatusBase();
            _jobLevel = EJobLevel.First;
            _level = 1;
            _characterJob = EAdvancement.Hero;
            _characterName = string.Empty;
            MainStatus = EStatus.STR;
            SubStatus = EStatus.DEX;
        }

        #endregion

        private void SetPrimaryKey()
        {
            PrimaryKey = Guid.NewGuid().ToString();
        }

        #region Status

        private void SetIsUseAttackPower()
        {
            switch (CharacterJob)
            {
                case EAdvancement.ArchMage_FirePoison:
                case EAdvancement.ArchMage_IceLightning:
                case EAdvancement.BattleMage:
                case EAdvancement.Luminous:
                case EAdvancement.Evan:
                case EAdvancement.BlazeWizard:
                case EAdvancement.Bishop:
                case EAdvancement.Kinesis:
                case EAdvancement.Illium:
                    IsUseAttackPower = false;
                    break;

                default:
                    IsUseAttackPower = true;
                    break;
            }
        }

        private void SetMainStatus()
        {
            switch (CharacterJob)
            {
                case EAdvancement.Hero:
                case EAdvancement.DarkKnight:
                case EAdvancement.Paladin:
                case EAdvancement.Adele:
                case EAdvancement.Cannoneer:
                case EAdvancement.DawnWarrior:
                case EAdvancement.Ark:
                case EAdvancement.Kaiser:
                case EAdvancement.Aran:
                case EAdvancement.Shade:
                case EAdvancement.Blaster:
                case EAdvancement.Zero:
                case EAdvancement.ThunderBreaker:
                case EAdvancement.Buccaneer:
                case EAdvancement.Mikhail:
                    MainStatus = EStatus.STR;
                    break;
                case EAdvancement.DemonAvenger:
                    MainStatus = EStatus.HP;
                    break;
                case EAdvancement.BattleMage:
                case EAdvancement.Illium:
                case EAdvancement.Bishop:
                case EAdvancement.ArchMage_IceLightning:
                case EAdvancement.BlazeWizard:
                case EAdvancement.Kinesis:
                case EAdvancement.Luminous:
                case EAdvancement.Evan:
                case EAdvancement.ArchMage_FirePoison:
                    MainStatus = EStatus.INT;
                    break;
                case EAdvancement.WindArcher:
                case EAdvancement.Corsair:
                case EAdvancement.Mercedes:
                case EAdvancement.Pathfinder:
                case EAdvancement.BowMaster:
                case EAdvancement.Marksman:
                case EAdvancement.WildHunter:
                case EAdvancement.AngelicBuster:
                case EAdvancement.Mechanic:
                    MainStatus = EStatus.DEX;
                    break;
                default:
                    MainStatus = EStatus.LUK;
                    break;
            }
        }

        private void SetSubStatus()
        {
            switch (CharacterJob)
            {
                case EAdvancement.Hero:
                case EAdvancement.DarkKnight:
                case EAdvancement.Paladin:
                case EAdvancement.Adele:
                case EAdvancement.Cannoneer:
                case EAdvancement.DawnWarrior:
                case EAdvancement.Ark:
                case EAdvancement.Kaiser:
                case EAdvancement.Aran:
                case EAdvancement.Shade:
                case EAdvancement.Blaster:
                case EAdvancement.Zero:
                case EAdvancement.ThunderBreaker:
                case EAdvancement.Buccaneer:
                case EAdvancement.Mikhail:
                    SubStatus = EStatus.DEX;
                    break;
                
                case EAdvancement.BattleMage:
                case EAdvancement.Illium:
                case EAdvancement.Bishop:
                case EAdvancement.ArchMage_IceLightning:
                case EAdvancement.BlazeWizard:
                case EAdvancement.Kinesis:
                case EAdvancement.Luminous:
                case EAdvancement.Evan:
                case EAdvancement.ArchMage_FirePoison:
                    SubStatus = EStatus.LUK;
                    break;

                case EAdvancement.DemonAvenger:
                case EAdvancement.WindArcher:
                case EAdvancement.Corsair:
                case EAdvancement.Mercedes:
                case EAdvancement.Pathfinder:
                case EAdvancement.BowMaster:
                case EAdvancement.Marksman:
                case EAdvancement.WildHunter:
                case EAdvancement.AngelicBuster:
                case EAdvancement.Mechanic:
                    SubStatus = EStatus.STR;
                    break;

                default:
                    SubStatus = EStatus.DEX;
                    break;
            }
        }

        #endregion

        public void SetEquipment(ECharacterEquipmentCategory category, EquipmentItem equipmentItem)
        {
            CharacterEquipment.EquipList[category] = equipmentItem;
        }

        public void SetCharacterJob(EAdvancement characterJob)
        {
            CharacterJob = characterJob;
        }

        private double GetJobConst()
        {
            switch (CharacterJob)
            {
                case EAdvancement.ArchMage_FirePoison:
                case EAdvancement.ArchMage_IceLightning:
                case EAdvancement.Bishop:
                case EAdvancement.BlazeWizard:
                    return 1.2;
                case EAdvancement.Xenon:
                    return 0.875;
                default:
                    return 1;
            }
        }
    }
}
