using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    [Table("mh_equipment")]
    public class EquipmentItem : ItemBase
    {
        private int _requireLevel;
        [Column("required_level")]
        public int RequireLevel
        {
            get => _requireLevel;
            set => SetProperty(ref _requireLevel, value);
        }

    }
}
