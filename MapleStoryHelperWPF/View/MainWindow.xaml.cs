using MapleStoryHelper.Standard.Item.Common;
using MapleStoryHelperWPF.Properties;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace MapleStoryHelperWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            App.OnLoaded += ApplicationLoaded;
            InitializeComponent();
        }

        private void ApplicationLoaded(object sender, EventArgs e)
        {
            ProgressEnabled(false);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ProgressEnabled(true);
            App.Load();
        }

        public void SetLoadingText(string text)
        {
            ctrlLoading.SetText(text);
        }

        public void ProgressEnabled(bool isEnabled)
        {
            ctrlLoading.ProgressEnabled = isEnabled;
        }

        private void LoadWz()
        {
            try
            {
                App.viewModel.LoadWz(Settings.Default.MapleStoryPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("메이플스토리 폴더를 지정해주세요.");
                System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();
                if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Settings.Default.MapleStoryPath = folder.SelectedPath;
                    Settings.Default.Save();
                }
                else
                {
                    Application.Current.MainWindow.Close();
                    return;
                }

                LoadWz();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.UpdateCharacterDatas();
        }
    }
}
