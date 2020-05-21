using MapleStoryHelper.Standard.Character.Status;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            get => _characterStatus;
            set => SetProperty(ref _characterStatus, value);
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
