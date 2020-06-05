using MapleStoryDpmCalc.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleStoryDpmCalc.ViewModel
{
    public class DpmCalcViewModel : BindableBase
    {
        //모든 스킬 아이템, 데미지가 있는 스킬,(제논 퍼지롭, 파이널어택 등) 데미지를 올려주는스킬(레투다, 엔버링크 등)이 모두 들어감
        private ObservableCollection<Skill> _skillItems;
        public ObservableCollection<Skill> SkillItems
        {
            get => _skillItems;
            set => SetProperty(ref _skillItems, value);
        }

        //SkillItems에서 선택된 스킬 아이템
        private ObservableCollection<Skill> _selectedSKillItems;
        public ObservableCollection<Skill> SelectedSkillItems
        {
            get => _selectedSKillItems;
            set => SetProperty(ref _selectedSKillItems, value);
        }

        private ObservableCollection<Skill> _selectedPassiveSkillItems;
        public ObservableCollection<Skill> SelectedPassiveSkillItems
        {
            get => _selectedPassiveSkillItems;
            set => SetProperty(ref _selectedPassiveSkillItems, value);
        }

        public DpmCalcViewModel()
        {
            InitVariables();
            InitSkillItems();
        }

        private void InitVariables()
        {
            _skillItems = new ObservableCollection<Skill>();
            _selectedPassiveSkillItems = new ObservableCollection<Skill>();
            _selectedSKillItems = new ObservableCollection<Skill>();
        }

        private void InitSkillItems()
        {
            
        }
    }
}
