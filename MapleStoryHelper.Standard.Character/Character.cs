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
        public Character() : base()
        {

        }

        public void InitEquipment()
        {
            this.CharacterEquipment = new CharacterEquipment();
        }
    }
}
