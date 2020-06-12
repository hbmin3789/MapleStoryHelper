using MapleStoryHelper.Standard.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item.Common
{
    public class Potential : BindableBase
    {
        private EStatus _statusKind;
        public EStatus StatusKind
        {
            get => _statusKind;
            set => SetProperty(ref _statusKind, value);
        }

        private int _statusValue;
        public int StatusValue
        {
            get => _statusValue;
            set => SetProperty(ref _statusValue, value);
        }

    }
}
