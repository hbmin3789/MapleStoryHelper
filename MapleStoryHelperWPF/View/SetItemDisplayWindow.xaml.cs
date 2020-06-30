using MapleStoryHelper.Framework.ResourceManager.Common;
using MapleStoryHelper.Standard.Character.Model;
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
using System.Windows.Shapes;
using WzComparerR2.CharaSim;

namespace MapleStoryHelperWPF.View
{
    /// <summary>
    /// SetItemDisplayWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SetItemDisplayWindow : Window
    {
        public SetItemDisplayWindow()
        {
            InitializeComponent();
        }

        public void SetItemStatus(Character character)
        {
            List<SetItem> lstSetItem = character.CharacterEquipment.CurSetItems;
            List<string> setItemString = new List<string>();
            for (int i = 0; i < lstSetItem.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(lstSetItem[i].SetItemName);
                sb.Append("\n");
                sb.Append(lstSetItem[i].GetItemParts(App.Wz.StringWzStruct.WzNode));
                setItemString.Add(sb.ToString());
            }
            lvSetItem.ItemsSource = setItemString;
        }
    }
}
