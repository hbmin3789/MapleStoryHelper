using MapleStoryHelper.Common;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 사용자 정의 컨트롤 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=234236에 나와 있습니다.

namespace MapleStoryHelper.Control.Item
{
    public sealed partial class EquipmentInfoControl : UserControl
    {
        public EventHandler OnSaved;

        private ECharacterEquipmentCategory _category;
        public ECharacterEquipmentCategory Category 
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        private EquipmentItem _equipmentItem;
        public EquipmentItem EquipmentItem 
        {
            get => this.DataContext as EquipmentItem;
            set
            {
                this.DataContext = value;
            }
        }

        public EquipmentInfoControl()
        {
            this.InitializeComponent();
            OnSaved += OnSavedItem;
        }

        private void OnSavedItem(object sender, EventArgs e)
        {
            EquipmentItem.Status = EquipmentItem.Status + GetPotentialStatus();
        }

        public async Task InitEquipComboBox(ECharacterEquipmentCategory category,CharacterBase character)
        {
            List<EquipmentItem> items = new List<EquipmentItem>();

            var list = new List<EquipmentItem>();

            if (category == ECharacterEquipmentCategory.Weapon)
            {
                list = MHResourceManager.GetEquipmentList(category, character.CharacterJob);
                EquipmentItem = new Weapon();
            }
            else
            {
                list = MHResourceManager.GetEquipmentList(category);
            }
            

            for (int i = 0; i < list.Count; i++)
            {
                list[i].ImgBitmapSource = await list[i].ImgByte.LoadImage();

                items.Add(list[i]);
            }

            cbItems.ItemsSource = items;
            if(items.Count != 0)
            {
                cbItems.SelectedIndex = 0;
            }
        }

        public EquipmentStatus GetPotentialStatus()
        {
            return ctrlPotential.GetStatus();
        }

        private void cbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbItems.SelectedItem as EquipmentItem;

            if (Category == ECharacterEquipmentCategory.Weapon)
            {
                item = cbItems.SelectedItem as Weapon;
            }

            this.DataContext = item;
        }
    }
}
