using MapleStoryHelper.Standard.MobLib.Model;
using MapleStoryHelper.Standard.SkillLib.Model;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MapleStorySearchApp.ViewModels
{
    public class OneKillViewModel : ViewModelBase
    {
        #region Property

        private int _maxStatus;
        public int MaxStatus
        {
            get => _maxStatus;
            set => SetProperty(ref _maxStatus, value);
        }

        private int _minStatus;
        public int MinStatus
        {
            get => _minStatus;
            set => SetProperty(ref _minStatus, value);
        }

        private SkillBase _skill;
        public SkillBase Skill
        {
            get => _skill;
            set => SetProperty(ref _skill, value);
        }

        private ObservableCollection<MobBase> _mobList;
        public ObservableCollection<MobBase> MobList
        {
            get => _mobList;
            set => SetProperty(ref _mobList, value);
        }

        #endregion

        #region Commands

        

        #endregion

        public OneKillViewModel()
        {
            InitVariables();
        }

        private void InitVariables()
        {
            _minStatus = 0;
            _maxStatus = 0;
            _mobList = new ObservableCollection<MobBase>();
            _skill = new SkillBase();
        }
    }
}
