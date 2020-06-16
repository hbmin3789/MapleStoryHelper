using MapleStoryHelper.Standard.Character;
using MapleStoryHelperWPF.Common;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace MapleStoryHelperWPF.Control
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public partial class ItemSettingPage : UserControl
    {
        private Character Backup;

        public ItemSettingPage()
        {
            this.InitializeComponent();
        }

        private void ItemSetting_Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            //var result = converter.Convert(btn.Content, null, null, null);

            var control = new EquipmentInfoControl();
            ECharacterEquipmentCategory category = GetCategory(btn.CommandParameter.ToString());
        }

        private async void UpdateView()
        {
            Character character = this.DataContext as Character;
            var equipList = character.CharacterEquipment.EquipList;
            var children = wpItems.Children;
            int idx = 0;

            for (int i = 0; i < wpItems.Children.Count; i++)
            {
                if(children[i] is Button)
                {
                    var grid = (children[i] as Button).Content as Grid;
                    var list = ChildrenToList(grid.Children);
                    var img = list.Last() as Image;

                    if (img != null && equipList != null)
                    {
                        img.Source = await equipList[(ECharacterEquipmentCategory)idx].ImgByte.LoadImage() as BitmapImage;
                        idx++;
                    }
                }
            }
            //UpdateStatusView();
        }

        private List<UIElement> ChildrenToList(UIElementCollection children)
        {
            List<UIElement> retval = new List<UIElement>();

            foreach(UIElement item in children)
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

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
