using MapleStoryHelper.Common;
using MapleStoryHelper.Control.Item;
using MapleStoryHelper.Converter.Equipment;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Prism.Commands;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace MapleStoryHelper.View
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class ItemSettingPage : Page
    {
        private Character Backup;

        public ItemSettingPage()
        {
            this.InitializeComponent();
        }

        private async void ItemSetting_Button_Click(object sender, RoutedEventArgs e)
        {
            
            var btn = sender as Button;
            var converter = new StringToEEquipmentCategoryConverter();
            var result = converter.Convert(btn.Content, null, null, null);

            var control = new EquipmentInfoControl();
            ECharacterEquipmentCategory category = GetCategory(btn.CommandParameter.ToString());

            await control.InitEquipComboBox(category, this.DataContext as Character);
            control.Category = category;

            ContentDialog noWifiDialog = new ContentDialog
            {
                Content = control,
                CloseButtonText = "취소",
                IsSecondaryButtonEnabled = true,
                SecondaryButtonText = "저장",
                SecondaryButtonCommand = new DelegateCommand<EquipmentInfoControl>(OnItemSave),
                SecondaryButtonCommandParameter = control
            };

            ContentDialogResult res = await noWifiDialog.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = e.Parameter;
            if(e.Parameter is Xenon)
            {
                Backup = (e.Parameter as Xenon).DeepCopy<Xenon>();
            }
            else
            {
                Backup = (e.Parameter as Character).DeepCopy<Character>();
            }
            UpdateView();
        }

        private void OnItemSave(EquipmentInfoControl control)
        {
            control.OnSaved?.Invoke(this, null);

            var character = this.DataContext as Character;
            character.CharacterEquipment.EquipList[control.Category] = control.EquipmentItem;

            UpdateView();
            
        }

        private async void UpdateView()
        {
            Character character = this.DataContext as Character;
            var equipList = character.CharacterEquipment.EquipList;
            var children = ufgItems.Children.ToList();
            int idx = 0;

            for (int i = 0; i < ufgItems.Children.Count; i++)
            {
                if(children[i] is Button)
                {
                    var grid = (children[i] as Button).Content as Grid;
                    var img = grid.Children.Last() as Image;

                    if (img != null && equipList != null)
                    {
                        img.Source = await equipList[(ECharacterEquipmentCategory)idx].ImgByte.LoadImage() as BitmapImage;
                        idx++;
                    }
                }
            }
            UpdateStatusView();
        }

        private void UpdateStatusView()
        {
            ctrlStatusDisplay.DataContext = new Character();
            ctrlStatusDisplay.DataContext = this.DataContext as Character;
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
            var ContentFrame = Window.Current.Content as Frame;
            ContentFrame.Navigate(typeof(CharacterAddPage), this.DataContext, new DrillInNavigationTransitionInfo());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var character = this.DataContext as Character;
            var ContentFrame = Window.Current.Content as Frame;
            ContentFrame.Navigate(typeof(CharacterAddPage), Backup, new DrillInNavigationTransitionInfo());
        }
    }
}
