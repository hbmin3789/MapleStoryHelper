using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 사용자 정의 컨트롤 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234236에 나와 있습니다.

namespace MapleStoryHelper.Control
{
    public sealed partial class AdditionalOptionControl : UserControl
    {
        public AdditionalOptionControl()
        {
            this.InitializeComponent();
        }

        private void cbAdditionalOptions_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;

            if (cbSTR.IsChecked == true) count++;
            if (cbDEX.IsChecked == true) count++;
            if (cbINT.IsChecked == true) count++;
            if (cbLUK.IsChecked == true) count++;

            if (count == 2)
            {
                cbSTR.IsEnabled = false;
                cbDEX.IsEnabled = false;
                cbINT.IsEnabled = false;
                cbLUK.IsEnabled = false;
            }
        }

        private void InitAdditionalOptionBtn_Click(object sender, RoutedEventArgs e)
        {
            cbSTR.IsChecked = false;
            cbDEX.IsChecked = false;
            cbINT.IsChecked = false;
            cbLUK.IsChecked = false;
            cbSTR.IsEnabled = true;
            cbDEX.IsEnabled = true;
            cbINT.IsEnabled = true;
            cbLUK.IsEnabled = true;
        }
    }
}
