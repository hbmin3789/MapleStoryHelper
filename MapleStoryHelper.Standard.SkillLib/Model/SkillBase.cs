using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.SkillLib.Model
{
    public class SkillBase : BindableBase
    {
        private string _skillName;
        public string SkillName
        {
            get => _skillName;
            set => SetProperty(ref _skillName, value);
        }

        private int _level;
        public int Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        private object _imgBitmapSource;
        [JsonIgnore]
        public object ImgBitmapSource
        {
            get => _imgBitmapSource;
            set => SetProperty(ref _imgBitmapSource, value);
        }

        private byte[] _imgByte;
        public byte[] ImgByte
        {
            get => _imgByte;
            set => SetProperty(ref _imgByte, value);
        }
    }
}
