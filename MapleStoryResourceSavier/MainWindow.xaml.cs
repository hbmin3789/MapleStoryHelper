using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Converter;
using MapleStoryHelper.Standard.Item;
using Microsoft.Win32;
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

namespace MapleStoryResourceSavier
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private ItemBase Item;
        private EquipmentItem EquipItem;
        public MainWindow()
        {
            InitializeComponent();
            InitVariables();
            InitItemCategoryCombobox();
            this.DataContext = Item;
        }

        private void InitVariables()
        {
            Item = new ItemBase();
            EquipItem = new EquipmentItem();
        }

        private void InitItemCategoryCombobox()
        {
            EItemCategoryToStringConverter converter = new EItemCategoryToStringConverter();
            var values = Enum.GetValues(typeof(EItemCategory));
            for(int i = 0; i < values.Length; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = converter.Convert(values.GetValue(i), null, null, null);
                cbItemCategory.Items.Add(newItem);
            }

            if(values.Length > 0)
            {
                cbItemCategory.SelectedIndex = 0;
            }
        }




        private void btnImageSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            string FullDir = dialog.FileName;
            string FileName = FullDir.Split(new char[] { '\\' }).Last();

            Item.ImgSrc = FullDir;
            Item.Name = FileName.Split(new char[] { '.' }).First();
        }
    }
}
