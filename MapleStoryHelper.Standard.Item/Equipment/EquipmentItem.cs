using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item
{
    public class EquipmentItem : ItemBase
    {
        private int _requireLevel;
        public int RequireLevel
        {
            get => _requireLevel;
            set => SetProperty(ref _requireLevel, value);
        }

    }
}
