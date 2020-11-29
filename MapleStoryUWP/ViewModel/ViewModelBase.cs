using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryUWPPriceCalc.ViewModel
{
    public class ViewModelBase : BindableBase
    {
        protected string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
