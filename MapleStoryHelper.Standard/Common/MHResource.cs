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
        [Column("name")]
        public string Name { get; set; }

        [Key]
        [Column("code")]
        public int Code { get; set; }

        [Column("image_data")]
        public byte[] ImageData { get; set; }
    }
}
