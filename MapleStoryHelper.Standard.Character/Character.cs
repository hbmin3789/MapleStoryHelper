using MapleStoryHelper.Standard.Character.Status;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MapleStoryHelper.Standard.Character
{
    [Table("character")]
    public class Character : CharacterBase
    {
        private MHResource _characterImage;
        [NotMapped]
        public MHResource CharacterImage
        {
            get => _characterImage;
            set => SetProperty(ref _characterImage, value);
        }

        private CharacterStatus _characterStatus;
        [NotMapped]
        public CharacterStatus CharacterStatus
        {
            get
            {
                _characterStatus = GetCharacterStatus();
                return _characterStatus;
            }
            set => SetProperty(ref _characterStatus, value);
        }

        public CharacterStatus GetCharacterStatus()
        {
            CharacterStatus retval = new CharacterStatus();

            for(int i=0;i< CharacterEquipment.EquipList.Count; i++)
            {
                var temp = retval + (CharacterEquipment.EquipList.ElementAt(i).Value.Status.GetStatus<CharacterStatus>() as CharacterStatus);
            }

            return retval;
        }


        public Character() : base()
        {
            InitCharacterVariables();
        }

        private void InitCharacterVariables()
        {
            _characterImage = new MHResource();
            _characterStatus = new CharacterStatus();
        }
    }
}
