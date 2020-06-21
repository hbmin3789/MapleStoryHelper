using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Character.Model;
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
        private Character character;
        EEquipmentCategory EquipCategory;

        public AddItemWindow()
        {
            InitializeComponent();
            ctrlEquipmentInfo.OnComboBoxSelectionChanged += ItemChanged;
        }

        private void ItemChanged(object sender, EventArgs e)
        {
            this.DataContext = ctrlEquipmentInfo.DataContext;
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

        public void SetCharacter(Character ch)
        {
            this.character = ch;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ctrlEquipmentInfo.SetEquipmentList(App.viewModel.FindItemByName(this.character, EquipCategory, tbKeyWord.Text));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("저장하시겠습니까?", "", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                this.DialogResult = true;
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("취소하시겠습니까?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                this.DialogResult = false;
                this.Hide();
            }
        }
    }
}
