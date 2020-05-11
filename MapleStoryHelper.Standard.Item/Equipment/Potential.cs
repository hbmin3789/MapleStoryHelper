using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Item.Equipment
{
    public class Potential : BindableBase
    {
        private EPotentialKind _potentialKind;
        public EPotentialKind PotentialKind
        {
            get => _potentialKind;
            set => SetProperty(ref _potentialKind, value);
        }

        private EPotentialRank _potentialRank;
        public EPotentialRank PotentialRank
        {
            get => _potentialRank;
            set => SetProperty(ref _potentialRank, value);
        }
    }
}
