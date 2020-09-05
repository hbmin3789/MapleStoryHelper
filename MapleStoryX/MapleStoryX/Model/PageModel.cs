using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryX.Model
{
    public class PageModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
    }
}
