using MapleStoryHelper.Converter;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
using System.Collections.Generic;
using WzComparerR2.CharaSim;

namespace MapleStoryHelper.Standard.Item
{
    public class EquipmentItem : ItemBase
    {
        #region Property

        //럭키 아이템인지
        private bool _isJoker;
        public bool IsJoker
        {
            get => _isJoker;
            set => SetProperty(ref _isJoker, value);
        }

        private int _setItemID;
        public int SetItemID 
        {
            get => _setItemID;
            set => SetProperty(ref _setItemID, value);
        }

        private int _requiredLevel = 10;
        public int RequiredLevel
        {
            get => _requiredLevel;
            set => SetProperty(ref _requiredLevel, value);
        }

        private int _maxStarForce;
        public int MaxStarForce
        {
            get => _maxStarForce;
            set => SetProperty(ref _maxStarForce, value);
        }

        private int _starForce;
        public int StarForce
        {
            get => _starForce;
            set => SetProperty(ref _starForce, value);
        }

        private int _maxScroll;
        public int MaxScroll
        {
            get => _maxScroll;
            set => SetProperty(ref _maxScroll, value);
        }

        private double _weaponConst = 0;
        public double WeaponConst
        {
            get => _weaponConst;
            set => SetProperty(ref _weaponConst, value);
        }

        private EEquipmentCategory _equipmentCategory;
        public EEquipmentCategory EquipmentCategory
        {
            get => _equipmentCategory;
            set => SetProperty(ref _equipmentCategory, value);
        }

        private GearType _weaponType;
        public GearType WeaponType
        {
            get => _weaponType;
            set => SetProperty(ref _weaponType, value);
        }

        private EJobCategory _jobCategory;
        public EJobCategory JobCategory
        {
            get => _jobCategory;
            set => SetProperty(ref _jobCategory, value);
        }

        private ECharacterJob _characterCategory;
        public ECharacterJob CharacterCategory
        {
            get => _characterCategory;
            set => SetProperty(ref _characterCategory, value);
        }

        private ECharacterEquipmentCategory _characterEquipmentCategory;
        public ECharacterEquipmentCategory CharacterEquipmentCategory
        {
            get => _characterEquipmentCategory;
            set => SetProperty(ref _characterEquipmentCategory, value);
        }

        private EquipmentStatus _status = new EquipmentStatus();
        public EquipmentStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private List<Common.Potential> _potential = new List<Common.Potential>();
        public List<Common.Potential> Potential
        {
            get => _potential;
            set => SetProperty(ref _potential, value);
        }

        #endregion

        #region Constructor

        public EquipmentItem()
        {

        }

        public EquipmentItem(ItemBase item) : base(item)
        {

        }

        #endregion

        public StatusBase GetStatus<T>() where T: StatusBase, new()
        {
            StatusBase retval = new T();

            var potentialStatus = PotentialConverter.Convert(Potential);
            retval = Status.GetStatus<StatusBase>() + potentialStatus;

            return retval;
        }

        /// <summary>
        /// Status 객체의 Clone()메서드 미구현
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            EquipmentItem retval = new EquipmentItem(base.Clone() as ItemBase);

            retval.CharacterCategory = this.CharacterCategory;
            retval.EquipmentCategory = this.EquipmentCategory;
            retval.ItemCategory = this.ItemCategory;
            retval.JobCategory = this.JobCategory;
            retval.MaxScroll = this.MaxScroll;
            retval.RequiredLevel = this.RequiredLevel;
            retval.MaxStarForce = this.MaxStarForce;
            retval.Status = this.Status;
            retval.Potential = this.Potential;

            return retval;
        }
    }
}
