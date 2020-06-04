using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryDpmCalc.Model
{
    public class Skill : BindableBase
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _imgPath;
        public string ImgPath
        {
            get => _imgPath;
            set => SetProperty(ref _imgPath, value);
        }

        private int _percent;
        public int Percent
        {
            get => _percent;
            set => SetProperty(ref _percent, value);
        }

        private int _delay;
        public int Delay
        {
            get => _delay;
            set => SetProperty(ref _delay, value);
        }

        private int _coolDown;
        public int CoolDown
        {
            get => _coolDown;
            set => SetProperty(ref _coolDown, value);
        }

        public Skill()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            
        }
    }
}
