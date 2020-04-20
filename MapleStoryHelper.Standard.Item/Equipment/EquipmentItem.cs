using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    [Table("mh_equipment")]
    public class EquipmentItem : ItemBase
    {
        private int _requiredLevel = 10;
        [Column("required_level")]
        public int RequiredLevel
        {
            get => _requiredLevel;
            set => SetProperty(ref _requiredLevel, value);
        }

        private StatusBase _status = new StatusBase();
        [Column("status")]
        public StatusBase Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

    }
}
