using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MapleStoryHelper.Standard.Resources
{
    [Table("mh_resource")]
    public class MHResource : BindableBase
    {
        //Item의 경우, 정수값이 들어오고 Character의 경우 GUID(string)로 들어옴
        [Key]
        [Column("code")]
        public string Code { get; set; }

        [Column("image_data")]
        public byte[] ImageData { get; set; }

    }
}
