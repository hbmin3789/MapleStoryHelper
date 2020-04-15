using MapleStoryHelper.Standard.Character.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Character
{
    public class Character : CharacterBase
    {
        private CharacterStatus _characterStatus;
        public CharacterStatus CharacterStatus
        {
            get => _characterStatus;
            set => SetProperty(ref _characterStatus, value);
        }


    }
}
