using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelper.Model
{
    public class PotentialPower : BindableBase
    {
        private string _display;
        public string Display
        {
            get => _display;
            set => SetProperty(ref _display, value);
        }


        public PotentialPower(string str)
        {
            Display = str;
        }
    }
}
