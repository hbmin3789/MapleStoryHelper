﻿using MapleStoryHelper.Standard.Character;
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

        private int _maxScroll;
        [Column("max_scroll")]
        public int MaxScroll
        {
            get => _maxScroll;
            set => SetProperty(ref _maxScroll, value);
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

        private EquipmentStatus _status = new EquipmentStatus();
        [Column("status")]
        public EquipmentStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
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

        protected override void SetPriaryKey(string value)
        {
            base.SetPriaryKey(value);
            Status.PrimaryKey = value;
        }
    }
}
