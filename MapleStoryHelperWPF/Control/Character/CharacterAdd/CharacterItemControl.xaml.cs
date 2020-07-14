using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelperWPF.View;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MapleStoryHelperWPF.Control.Character.CharacterAdd
{
    /// <summary>
    /// CharacterItemControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CharacterItemControl : UserControl
    {
        private MapleStoryHelper.Standard.Character.Model.Character Backup;

        public CharacterItemControl()
        {
            this.InitializeComponent();
            InitEquipButtons();
        }

        private void InitEquipButtons()
        {
            int idx = 0;
            var children = wpItems.Children;
            for (int i = 0; i < wpItems.Children.Count; i++)
            {
                if (children[i] is Button)
                {
                    var grid = new Grid();
                    var textBlock = NewButtonTextBlock();
                    textBlock.Text = ((ECharacterEquipmentCategory)idx).ToString();
                    var img = new Image();

                    grid.Children.Add(textBlock);
                    grid.Children.Add(img);
                    (children[i] as Button).Content = grid;
                    idx++;
                }
            }
        }

        private TextBlock NewButtonTextBlock()
        {
            TextBlock retval = new TextBlock();

            retval.HorizontalAlignment = HorizontalAlignment.Left;
            retval.VerticalAlignment = VerticalAlignment.Top;
            retval.FontSize = 12;

            return retval;
        }

        private void ItemSetting_Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            ECharacterEquipmentCategory category = GetCategory(btn.CommandParameter.ToString());

            AddItemWindow window = new AddItemWindow();
            window.SetItemCategory(category);
            window.SetCharacter(this.DataContext as MapleStoryHelper.Standard.Character.Model.Character);
            window.ShowDialog();

            if(window.DialogResult == true)
            {
                var character = this.DataContext as MapleStoryHelper.Standard.Character.Model.Character;
                character.SetEquipment(category, window.DataContext as EquipmentItem);
                UpdateView();
            }
        }

        public void UpdateView()
        {
            MapleStoryHelper.Standard.Character.Model.Character character = this.DataContext as MapleStoryHelper.Standard.Character.Model.Character;
            var equipList = character.CharacterEquipment.EquipList;
            var children = wpItems.Children;
            int idx = 0;

            for (int i = 0; i < wpItems.Children.Count; i++)
            {
                if (children[i] is Button)
                {
                    var grid = (children[i] as Button).Content as Grid;
                    var list = ChildrenToList(grid.Children);
                    var img = list.Last() as Image;

                    if (img != null && equipList != null)
                    {
                        img.Source = equipList[(ECharacterEquipmentCategory)idx].ImgByte.LoadImage() as BitmapImage;
                        idx++;
                    }
                }
            }
            UpdateStatusView();
        }

        private void UpdateStatusView()
        {
            ctrlStatusDisplay.SetCharacterStatusDataContext(this.DataContext);
        }

        private List<UIElement> ChildrenToList(UIElementCollection children)
        {
            List<UIElement> retval = new List<UIElement>();

            foreach (UIElement item in children)
            {
                retval.Add(item);
            }

            return retval;
        }

        private ECharacterEquipmentCategory GetCategory(string CommandParameter)
        {
            var values = Enum.GetValues(typeof(ECharacterEquipmentCategory));

            for (int i = 0; i < values.Length; i++)
            {
                if (values.GetValue(i).ToString().Equals(CommandParameter))
                {
                    return (ECharacterEquipmentCategory)values.GetValue(i);
                }
            }

            return ECharacterEquipmentCategory.Ring1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            App.UpdateBinding();
        }

        public void SetDataContext(object dataContext)
        {
            this.DataContext = dataContext;
            ctrlStatusDisplay.SetCharacterStatusDataContext(dataContext);
        }

        private void btnSetItemDisplay_Click(object sender, RoutedEventArgs e)
        {
            SetItemDisplayWindow window = new SetItemDisplayWindow();
            var character = this.DataContext as MapleStoryHelper.Standard.Character.Model.Character;
            window.SetItemStatus(character);
            window.ShowDialog();
        }
    }
}
