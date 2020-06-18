using MapleStoryHelper.Standard.Character;
using MapleStoryHelperWPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            //var result = converter.Convert(btn.Content, null, null, null);

            var control = new EquipmentInfoControl();
            ECharacterEquipmentCategory category = GetCategory(btn.CommandParameter.ToString());
            var character = this.DataContext as MapleStoryHelper.Standard.Character.Character;
             character.CharacterEquipment.EquipList[category];
        }

        private async void UpdateView()
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
