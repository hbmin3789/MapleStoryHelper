using MapleStoryHelper.Standard.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MapleStoryHelper.Standard.Database
{
    public partial class MHDBManager
    {
        public static MHResource GetResource(Character.Character character)
        {
            MHResource retval = new MHResource();
            MemoryStream memoryStream = new MemoryStream();

            

            retval.ImageData = File.ReadAllBytes(character.ImageSrc);
            retval.Code = character.PrimaryKey;

            return retval;
        }
    }
}
