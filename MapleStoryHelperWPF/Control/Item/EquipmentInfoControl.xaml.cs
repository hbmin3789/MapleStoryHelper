using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Character.Model;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Common;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MapleStoryHelperWPF.Control
{
    public partial class EquipmentInfoControl : UserControl
    {
        public EventHandler OnComboBoxSelectionChanged;

        #region Property

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
        
        public EquipmentItem EquipmentItem 
        {
            get => this.DataContext as EquipmentItem;
            set
            {
                this.DataContext = value;
            }
        }

        #endregion

        public EquipmentInfoControl()
        {
            InitializeComponent();
        }

        #region Initialize

        public async Task InitEquipComboBox(ECharacterEquipmentCategory category, CharacterBase character)
        {
            List<EquipmentItem> items = new List<EquipmentItem>();

            var list = new List<EquipmentItem>();

            if (category == ECharacterEquipmentCategory.Weapon)
            {
                list = MHResourceManager.GetEquipmentList(category, character.CharacterJob);
            }
            else
            {
                list = MHResourceManager.GetEquipmentList(category, character.JobCategory);
            }
            

            for (int i = 0; i < list.Count; i++)
            {
                list[i].ImgBitmapSource = list[i].ImgByte.LoadImage();

                items.Add(list[i]);
            }

            cbItems.ItemsSource = items;

            SetSelectedIndex(category, character);
        }

        #endregion

        private void SetSelectedIndex(ECharacterEquipmentCategory category, CharacterBase character)
        {
            if (cbItems.Items.Count != 0)
            {
                var item = character.CharacterEquipment.EquipList[category];

                if (item != null)
                {
                    var items = cbItems.ItemsSource as List<EquipmentItem>;

                    int idx = items.IndexOf(items.Where(x => x.ItemCode == (item as EquipmentItem).ItemCode).FirstOrDefault());
                    cbItems.SelectedIndex = idx;

                    EquipmentItem = item;
                }
                else
                {
                    cbItems.SelectedIndex = 0;
                }
            }
            else
            {

            }
        }

        public void SetEquipmentList(List<EquipmentItem> items)
        {
            cbItems.ItemsSource = items;
        }

        public List<Potential> GetPotentialStatus()
        {
            return ctrlPotential.GetStatus();
        }

        #region Event

        public void OnSavedItem()
        {
            EquipmentItem.Potential = GetPotentialStatus();
            EquipmentItem.CharacterEquipmentCategory = Category;
        }

        private void cbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EquipmentItem = cbItems.SelectedItem as EquipmentItem;
            OnComboBoxSelectionChanged?.Invoke(sender, null);
        }

        #endregion
    }
}
