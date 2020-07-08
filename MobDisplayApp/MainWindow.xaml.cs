using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Framework.ResourceManager.Common;
using MapleStoryHelper.Standard.MobLib.Model;
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
using WzComparerR2.CharaSim;
using WzComparerR2.PluginBase;

namespace MobDisplayApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<MobBase> Mobs { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            App.mapleWz.LoadFile(@"C:\Nexon\Maple");
            Mobs = GetMobs(App.mapleWz);
            this.DataContext = this;
        }

        private List<MobBase> GetMobs(MapleWz mapleWz)
        {
            List<MobBase> retval = new List<MobBase>();

            var nodes = mapleWz.MobWzStruct.WzNode.Nodes;
            for (int i=0; i < nodes.Count; i++)
            {
                try
                {
                    var image = nodes[i].GetImage();
                    var mob = MobBase.CreateFromNode(image.Node, PluginManager.FindWz);
                    if (mob != null)
                    {
                        int code = Convert.ToInt32(nodes[i].Text.Replace(".img", ""));
                        MobBase newItem = MobToMobBase(mob);
                        newItem.MobName = image.Node.Text;

                        newItem.ImgBitmapSource = newItem.Default.Bitmap.LoadImage();

                        retval.Add(newItem);
                    }
                }
                catch(Exception e)
                {

                }
            }

            return retval;
        }

        private MobBase MobToMobBase(Mob mob)
        {
            MobBase retval = new MobBase();

            retval.FinalMaxHP = mob.FinalMaxHP;
            retval.MaxHP = mob.MaxHP;
            retval.Boss = mob.Boss;
            retval.Default = mob.Default;
            retval.Defense = 10;

            return retval;
        }
    }
}
