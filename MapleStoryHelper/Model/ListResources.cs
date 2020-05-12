using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryHelper.Model
{
    public class ListResources : BindableBase, ICustomTypeDescriptor
    {
        private ObservableCollection<PotentialPower> _potentialItems;
        public ObservableCollection<PotentialPower> PotentialItems 
        {
            get => _potentialItems;
            set => SetProperty(ref _potentialItems, value);
        }

        private ObservableCollection<PotentialPower> _additionalPotentialItems;
        public ObservableCollection<PotentialPower> AdditionalItems 
        {
            get => _additionalPotentialItems;
            set => SetProperty(ref _additionalPotentialItems, value);
        }
        public ObservableCollection<string> PotentialRankList;
        public ObservableCollection<Scroll> ScrollItems;

        public ListResources()
        {
            InitVariables();
            InitPotentialListView();
            InitScrollListBox();
        }

        #region Initialize

        private void InitVariables()
        {
            PotentialItems = new ObservableCollection<PotentialPower>();
            AdditionalItems = new ObservableCollection<PotentialPower>();
            ScrollItems = new ObservableCollection<Scroll>();
            PotentialRankList = new ObservableCollection<string>();
        }

        private void InitPotentialListView()
        {
            AddBasePotential();
            AddPotentialRank();
        }

        private void InitScrollListBox()
        {
            AddBaseScroll();
        }

        private void AddPotentialRank()
        {
            PotentialRankList.Add("레어");
            PotentialRankList.Add("에픽");
            PotentialRankList.Add("유니크");
            PotentialRankList.Add("레전더리");
        }

        private void AddBasePotential()
        {
            PotentialItems.Add(new PotentialPower("STR%"));
            PotentialItems.Add(new PotentialPower("DEX%"));
            PotentialItems.Add(new PotentialPower("INT%"));
            PotentialItems.Add(new PotentialPower("LUK%"));
            PotentialItems.Add(new PotentialPower("HP%"));
            PotentialItems.Add(new PotentialPower("MP%"));
            PotentialItems.Add(new PotentialPower("STR"));
            PotentialItems.Add(new PotentialPower("DEX"));
            PotentialItems.Add(new PotentialPower("INT"));
            PotentialItems.Add(new PotentialPower("LUK"));
            PotentialItems.Add(new PotentialPower("HP"));
            PotentialItems.Add(new PotentialPower("MP"));

            AdditionalItems.Add(new PotentialPower("STR%"));
            AdditionalItems.Add(new PotentialPower("DEX%"));
            AdditionalItems.Add(new PotentialPower("INT%"));
            AdditionalItems.Add(new PotentialPower("LUK%"));
            AdditionalItems.Add(new PotentialPower("HP%"));
            AdditionalItems.Add(new PotentialPower("MP%"));
            AdditionalItems.Add(new PotentialPower("STR"));
            AdditionalItems.Add(new PotentialPower("DEX"));
            AdditionalItems.Add(new PotentialPower("INT"));
            AdditionalItems.Add(new PotentialPower("LUK"));
            AdditionalItems.Add(new PotentialPower("HP"));
            AdditionalItems.Add(new PotentialPower("MP"));
        }

        private void AddBaseScroll()
        {
            ScrollItems.Add(new Scroll() { Name = "주문의 흔적", ImageSource = "/Assets/Items/Scroll/Trace.png" });
            ScrollItems.Add(new Scroll() { Name = "혼돈의 주문서", ImageSource = "/Assets/Items/Scroll/Chaos.png" });
            ScrollItems.Add(new Scroll() { Name = "매지컬 주문서", ImageSource = "/Assets/Items/Scroll/Magical.png" });
            ScrollItems.Add(new Scroll() { Name = "프리미엄 스크롤", ImageSource = "/Assets/Items/Scroll/Premium.png" });
        }

        #endregion

        #region InterfaceMethods

        public AttributeCollection GetAttributes()
        {
            throw new NotImplementedException();
        }

        public string GetClassName()
        {
            throw new NotImplementedException();
        }

        public string GetComponentName()
        {
            throw new NotImplementedException();
        }

        public TypeConverter GetConverter()
        {
            throw new NotImplementedException();
        }

        public EventDescriptor GetDefaultEvent()
        {
            throw new NotImplementedException();
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            throw new NotImplementedException();
        }

        public object GetEditor(Type editorBaseType)
        {
            throw new NotImplementedException();
        }

        public EventDescriptorCollection GetEvents()
        {
            throw new NotImplementedException();
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            throw new NotImplementedException();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            throw new NotImplementedException();
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            throw new NotImplementedException();
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
