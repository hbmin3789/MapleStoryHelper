using MapleStoryHelper.Standard;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Converter;
using MapleStoryHelper.Standard.Database;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Microsoft.Win32;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace MapleStoryResourceSavior
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private MHDBManager dbmanager;

        private ItemBase Item;

        public MainWindow()
        {
            InitializeComponent();
            InitVariables();
            InitCategoryCombobox();
            InitDataBase();
            this.DataContext = Item;
        }

        #region Initialize

        private void InitDataBase()
        {
            dbmanager = new MHDBManager();
        }

        private void InitVariables()
        {
            Item = new ItemBase();
        }

        private void InitCategoryCombobox()
        {
            EItemCategoryToStringConverter itemconverter = new EItemCategoryToStringConverter();
            var ItemCategory = Enum.GetValues(typeof(EItemCategory));
            for(int i = 0; i < ItemCategory.Length; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = itemconverter.Convert(ItemCategory.GetValue(i), null, null, null);
                cbItemCategory.Items.Add(newItem);
            }

            var EquipmentCategory = Enum.GetNames(typeof(EEquipmentCategory));
            for(int i = 0; i < EquipmentCategory.Length; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = EquipmentCategory[i];
                cbEquipmentCategory.Items.Add(newItem);
            }

            var JobCategory = Enum.GetNames(typeof(EJobCategory));
            for (int i = 0; i < JobCategory.Length; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = JobCategory[i];
                cbJobCategory.Items.Add(newItem);
            }

            ECharacterJobToStringConverter characterconverter = new ECharacterJobToStringConverter();
            var CharacterJob = Enum.GetValues(typeof(ECharacterJob));
            for (int i = 0; i < CharacterJob.Length; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = characterconverter.Convert(CharacterJob.GetValue(i), null, null, null);
                cbCharacterJob.Items.Add(newItem);
            }
        }

        private void ClearUI()
        {
            tbItemLevel.Text = "";
            tbStr.Text = "";
            tbDex.Text = "";
            tbInt.Text = "";
            tbLuk.Text = "";
            tbHP.Text = "";
            tbMP.Text = "";
            tbAttack.Text = "";
            tbMagic.Text = "";
            tbScroll.Text = "";
            tbStarForce.Text = "";
            Item = new ItemBase();
            this.DataContext = null;
            this.DataContext = Item;
            cbEquipmentCategory.SelectedIndex = -1;
            cbItemCategory.SelectedIndex = -1;
        }

        #endregion

        private void btnImageSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            string FullDir = dialog.FileName;
            string FileName = FullDir.Split(new char[] { '\\' }).Last();

            Item.ImgSrc = FullDir;
            Item.Name = FileName.Split(new char[] { '.' }).First();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MHResource res = GetResource();
            SetItemPrimaryKey();

            switch (cbItemCategory.SelectedIndex)
            {
                case 0:
                    EquipmentItem newItem = new EquipmentItem(Item);
                    try
                    {
                        GetEquipStatus(ref newItem);
                        GetItemCategory(ref newItem);
                        dbmanager.SaveResource(res);
                        dbmanager.SaveEquipmentItem(newItem);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("입력 상자를 다시 확인해 주세요.");
                        return;
                    }                    
                    break;
                default:
                    break;
            }            

            ClearUI();
        }

        private void GetItemCategory(ref EquipmentItem newItem)
        {
            if(cbEquipmentCategory.SelectedIndex == -1 ||
                cbItemCategory.SelectedIndex == -1 ||
                cbCharacterJob.SelectedIndex == -1 ||
                cbJobCategory.SelectedIndex == -1)
            {
                throw new Exception();
            }
            newItem.ItemCategory = (EItemCategory)cbItemCategory.SelectedIndex;
            newItem.EquipmentCategory = (EEquipmentCategory)cbEquipmentCategory.SelectedIndex;
            newItem.JobCategory = (EJobCategory)cbJobCategory.SelectedIndex;
            newItem.CharacterCategory = (ECharacterJob)cbCharacterJob.SelectedIndex;
        }

        #region Database Methods

        private void GetEquipStatus(ref EquipmentItem newItem)
        {
            newItem.RequiredLevel = Convert.ToInt32(tbItemLevel.Text);
            newItem.Status.Str = Convert.ToInt32(tbStr.Text);
            newItem.Status.Dex = Convert.ToInt32(tbDex.Text);
            newItem.Status.Int = Convert.ToInt32(tbInt.Text);
            newItem.Status.Luk = Convert.ToInt32(tbLuk.Text);
            newItem.Status.HP = Convert.ToInt32(tbHP.Text);
            newItem.Status.MP = Convert.ToInt32(tbMP.Text);
            newItem.Status.AttackPower = Convert.ToInt32(tbAttack.Text);
            newItem.Status.MagicAttack = Convert.ToInt32(tbMagic.Text);
            newItem.MaxScroll = Convert.ToInt32(tbScroll.Text);
            newItem.MaxStarForce = Convert.ToInt32(tbStarForce.Text);
        }

        private void SetItemPrimaryKey()
        {
            Item.PrimaryKey = Guid.NewGuid().ToString();
        }

        private MHResource GetResource()
        {
            MHResource retval = new MHResource();
            MemoryStream memoryStream = new MemoryStream();
            System.Drawing.Image img = System.Drawing.Image.FromFile(Item.ImgSrc);

            if (Item.ImgSrc.Split(new char[] { '.' }).Last().Equals("png"))
            {
                img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            retval.ImageData = memoryStream.ToArray();
            retval.Code = Item.ItemCode;

            return retval;
        }

        #endregion
    }
}
