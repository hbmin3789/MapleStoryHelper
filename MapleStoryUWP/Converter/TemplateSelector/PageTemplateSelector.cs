using MapleStoryUWPPriceCalc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MapleStoryUWPPriceCalc.Converter
{
    public class PageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Main { get; set; }
        public DataTemplate ItemPrice { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            switch (item.GetType().Name)
            {
                case "ItemPriceViewModel":
                    return ItemPrice;
                default:
                    return Main;
            }
        }
    }
}
