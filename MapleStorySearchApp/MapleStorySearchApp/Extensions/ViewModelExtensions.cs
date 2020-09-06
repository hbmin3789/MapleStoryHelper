using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace MapleStorySearchApp.Extensions
{
    public static class ViewModelExtensions
    {
        public static void Binding<T>(this ContentPage page) where T : BindableBase, new()
        {
            page.BindingContext = new T();
        }
    }
}
