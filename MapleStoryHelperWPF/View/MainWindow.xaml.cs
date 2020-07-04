using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Microsoft.Win32;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using WzComparerR2.WzLib;

namespace MapleStoryHelperWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadWz();
            App.LoadCharacterDatas();
        }

        private void LoadWz()
        {
            try
            {
                App.viewModel.LoadWz(Properties.Settings.MapleStoryPath);
            }
            catch (Exception e)
            {
                MessageBox.Show("메이플스토리 폴더를 지정해주세요.");
                System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();
                if (folder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Properties.Settings.MapleStoryPath = folder.SelectedPath;
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
