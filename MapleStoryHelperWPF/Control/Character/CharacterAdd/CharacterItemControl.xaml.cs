using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelperWPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private MapleStoryHelper.Standard.Character.Character Backup;

        public CharacterItemControl()
        {
            this.InitializeComponent();
        }

        private void ItemSetting_Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            ECharacterEquipmentCategory category = GetCategory(btn.CommandParameter.ToString());

            AddItemWindow window = new AddItemWindow();
            window.ShowDialog();

            var character = this.DataContext as MapleStoryHelper.Standard.Character.Character;
            character.CharacterEquipment.EquipList[category] = window.DataContext as EquipmentItem;
        }

        private void UpdateView()
        {
            MapleStoryHelper.Standard.Character.Character character = this.DataContext as MapleStoryHelper.Standard.Character.Character;
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
            //UpdateStatusView();
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
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
