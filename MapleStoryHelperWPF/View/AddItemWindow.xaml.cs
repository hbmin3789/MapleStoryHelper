using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item.Equipment;
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

namespace MapleStoryHelperWPF.View
{
    /// <summary>
    /// AddItemWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddItemWindow : Window
    {
        EEquipmentCategory EquipCategory;

        public AddItemWindow()
        {
            InitializeComponent();
        }

        public void SetItemCategory(ECharacterEquipmentCategory category)
        {
            string StringTemp = category.ToString().Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "");

            var values = Enum.GetValues(typeof(EEquipmentCategory));
            EEquipmentCategory categoryTemp = EEquipmentCategory.Ring;

            for (int i = 0; i < values.Length; i++)
            {
                if (values.GetValue(i).ToString() == StringTemp)
                {
                    categoryTemp = (EEquipmentCategory)values.GetValue(i);
                    break;
                }
            }

            EquipCategory = categoryTemp;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ctrlEquipmentInfo.SetEquipmentList(App.viewModel.FindItemByName(EquipCategory, tbKeyWord.Text));
        }
    }
}
