using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Common
{
    [Table("mh_resource")]
    public class MHResource : BindableBase
    {
        [Key]
        [Column("code")]
        public string Code { get; set; }

        [Column("image_data")]
        public byte[] ImageData { get; set; }
    }
}
