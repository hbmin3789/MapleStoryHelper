using MapleStoryHelper.Standard.MNetwork;
using MapleStoryHelper.Standard.SkillLib.Model;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MapleStorySearchApp.ViewModels
{
    public class SkillSearchViewModel : BindableBase
    {
        private const string IP = "https://localhost:44328";
        private MNetwork networkManager = new MNetwork(IP);

        private ObservableCollection<SkillBase> _skillItems;
        public ObservableCollection<SkillBase> SkillItems
        {
            get => _skillItems;
            set => SetProperty(ref _skillItems, value);
        }

        private string _keyWord;
        public string KeyWord
        {
            get => _keyWord;
            set => SetProperty(ref _keyWord, value);
        }

        public DelegateCommand ItemSearchCommand { get; set; }

        public SkillSearchViewModel()
        {
            InitVariables();
            InitCommands();
        }

        private void InitCommands()
        {
            ItemSearchCommand = new DelegateCommand(ItemSearch);
        }

        private void InitVariables()
        {
            _skillItems = new ObservableCollection<SkillBase>();
        }

        private async void ItemSearch()
        {
            JObject job = new JObject();
            job.Add("keyWord", KeyWord);
            var resp = await networkManager.GetResponse<List<SkillBase>>("/SkillSearch", Method.GET, job.ToString());
        }
    }
}
