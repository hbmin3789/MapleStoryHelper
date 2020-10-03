using MapleStoryHelper.Standard.MNetwork;
using MapleStoryHelper.Standard.SkillLib.Model;
using MapleStorySearchApp.Services;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;

namespace MapleStorySearchApp.ViewModels
{
    public class SkillSearchViewModel : ViewModelBase
    {
        private SkillBase _selectedSkill;
        public SkillBase SelectedSkill
        {
            get => _selectedSkill;
            set => SetProperty(ref _selectedSkill, value);
        }

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
            var resp = await networkManager.GetResponse<List<SkillBase>>("/SkillSearch", Method.POST, job.ToString());
            if(resp.Data != null)
            {
                for(int i = 0; i < resp.Data.Count; i++)
                {
                    Stream stream = new MemoryStream(resp.Data[i].ImgByte);
                    resp.Data[i].ImgBitmapSource = ImageSource.FromStream(()=>stream);
                }
                SkillItems = new ObservableCollection<SkillBase>(resp.Data);
            }
        }
    }
}
