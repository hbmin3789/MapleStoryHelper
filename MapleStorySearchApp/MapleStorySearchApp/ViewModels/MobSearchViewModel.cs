using MapleStoryHelper.Standard.MobLib.Common;
using MapleStoryHelper.Standard.MobLib.Model;
using MapleStorySearchApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MapleStorySearchApp.ViewModels
{
    public class MobSearchViewModel : ViewModelBase
    {

        private MobSearchService service;

        #region Property

        private string _keyWord;
        public string KeyWord
        {
            get => _keyWord;
            set => SetProperty(ref _keyWord, value);
        }

        private EMobMapCategory _mapCategory;
        public EMobMapCategory MapCategory
        {
            get => _mapCategory;
            set => SetProperty(ref _mapCategory, value);
        }

        private ObservableCollection<MobBase> _mobItems;
        public ObservableCollection<MobBase> MobItems
        {
            get => _mobItems;
            set => SetProperty(ref _mobItems, value);
        }

        #endregion

        public DelegateCommand MobSearchCommand { get; set; }

        public MobSearchViewModel() 
        {
            InitVariables();
            InitCommands();
        }

        #region Initialize

        private void InitCommands()
        {
            MobSearchCommand = new DelegateCommand(MobSearch);
        }

        private void InitVariables()
        {
            service = new MobSearchService(networkManager);
            MapCategory = EMobMapCategory.RoadofVanishing;

            _mobItems = new ObservableCollection<MobBase>();
        }

        #endregion


        private async void MobSearch()
        {
            try 
            {
                var result = await service.GetMobs(KeyWord, MapCategory);
                MobItems = new ObservableCollection<MobBase>(result);
            }
            catch(Exception e)
            {
                SendMessage?.Invoke(e.Message);
            }
        }
    }
}
