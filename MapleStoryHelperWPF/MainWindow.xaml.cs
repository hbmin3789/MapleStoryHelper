using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
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
        private const string PATH = @"C:\Nexon\Maple\Character.wz";
        public List<EquipmentItem> EquipmentItems { get; set; }
        Wz_File file = new Wz_File(PATH, new Wz_Structure());

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            MapleWz wz = new MapleWz();
            wz.LoadFile(PATH);
            wz.GetEquipmentItems(EEquipmentCategory.Ring, EJobCategory.All);
        }
    }
}
