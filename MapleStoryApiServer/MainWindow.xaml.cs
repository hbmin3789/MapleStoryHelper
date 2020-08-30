using MapleStoryApiServer.Interfaces.Services;
using MapleStoryApiServer.Model.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapleStoryApiServer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
#warning 왜인지 모르겠는데 RESTAPI가 안먹고 URL parameter만 먹음;; 구글링 필요
        ServiceHost host;
        public MainWindow()
        {
            InitializeComponent();

            App.wzManager.LoadFile("");

            string baseAddress = "http://" + Environment.MachineName + ":8000/";
            host = new ServiceHost(typeof(ItemSearchService), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IItemSearchService), new WebHttpBinding(), "").Behaviors.
                                                                                         Add(new WebHttpBehavior());
            
            host.UnknownMessageReceived += Host_UnknownMessageReceived;
            host.Open();
            tbOpenedPath.Text = baseAddress + " 주소 열림";
        }

        private void Host_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            host.Close();
        }
    }
}
