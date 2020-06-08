using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    [Table("mh_equipment")]
    public class EquipmentItem : ItemBase
    {
        #region Property

        private int _requiredLevel = 10;
        [Column("required_level")]
        public int RequiredLevel
        {
            get => _requiredLevel;
            set => SetProperty(ref _requiredLevel, value);
        }

        private int _maxStarForce;
        [Column("max_starforce")]
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
        [Column("max_scroll")]
        public int MaxScroll
        {
            get => _maxScroll;
            set => SetProperty(ref _maxScroll, value);
        }

        private double _weaponConst;
        public double WeaponConst
        {
            get => _weaponConst;
            set => SetProperty(ref _weaponConst, value);
        }

        private EEquipmentCategory _equipmentCategory;
        [Column("equipment_category")]
        public EEquipmentCategory EquipmentCategory
        {
            get => _equipmentCategory;
            set => SetProperty(ref _equipmentCategory, value);
        }

        private EJobCategory _jobCategory;
        [Column("job_category")]
        public EJobCategory JobCategory
        {
            get => _jobCategory;
            set => SetProperty(ref _jobCategory, value);
        }

        private ECharacterJob _characterCategory;
        [Column("character_category")]
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
        [Column("status")]
        public EquipmentStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private Potential _potential;
        public Potential Potential
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
