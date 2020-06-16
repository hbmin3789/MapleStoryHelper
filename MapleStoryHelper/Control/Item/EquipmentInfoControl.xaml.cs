using MapleStoryHelper.Common;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Common;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MapleStoryHelper.Control.Item
{
    public sealed partial class EquipmentInfoControl : UserControl
    {
        public EventHandler OnSaved;

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
            this.InitializeComponent();
            OnSaved += OnSavedItem;            
        }

        #region Initialize

        public async Task InitEquipComboBox(ECharacterEquipmentCategory category,CharacterBase character)
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
                list[i].ImgBitmapSource = await list[i].ImgByte.LoadImage();

                items.Add(list[i]);
            }

            cbItems.ItemsSource = items;

            SetSelectedIndex(category, character);

            InitPotential();
        }

        private void InitPotential()
        {
            ctrlPotential.InitPotential(EquipmentItem);
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

                    this.DataContext = item;
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

        public List<Potential> GetPotentialStatus()
        {
            return ctrlPotential.GetStatus();
        }

        #region Event

        private void OnSavedItem(object sender, EventArgs e)
        {
            EquipmentItem.Potential = GetPotentialStatus();
            EquipmentItem.CharacterEquipmentCategory = Category;
        }

        private async void cbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = cbItems.SelectedItem.DeepCopy<EquipmentItem>();
            temp.ImgBitmapSource = await temp.ImgByte.LoadImage();
            this.DataContext = temp;
        }

        #endregion
    }
}
