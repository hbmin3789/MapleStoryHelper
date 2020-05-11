using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item.Equipment
{
    public class AdditionalOption : BindableBase
    {
        private int _optionRank;
        public int OptionRank
        {
            get => _optionRank;
            set => SetProperty(ref _optionRank, value);
        }

    }
}
