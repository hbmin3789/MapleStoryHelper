using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character.Model;
using MapleStoryHelper.Standard.Item.Common;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.SkillLib.Model;
using MapleStoryHelperWPF.Properties;
using MapleStoryHelperWPF.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WzComparerR2.CharaSim;

namespace MapleStoryHelperWPF
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private static Thread LoadThread = new Thread(LoadData);

        public static EventHandler UpdateBindingEvent;
        public static EventHandler OnWzLoaded;
        public static string BASE_PATH = AppDomain.CurrentDomain.BaseDirectory + "Data.dat";
        public static string BASE_PATH_UNION = AppDomain.CurrentDomain.BaseDirectory + "Union.dat";
        public static MapleStoryHelperViewModel viewModel = new MapleStoryHelperViewModel();

        public static MapleWz mapleWz 
        { 
            get => viewModel.MapleWz;
        }

        public static ObservableCollection<SkillBase> Skills
        {
            get => viewModel.Skills;
            private set => viewModel.Skills = value;
        }

        #region Binding

        public static void AddBindingUpdateEvent(EventHandler e)
        {
            UpdateBindingEvent += e;
        }

        public static void UpdateBinding()
        {
            UpdateBindingEvent?.Invoke(null, null);
        }

        #endregion

        #region CharacterDatas

        public static void LoadCharacterDatas()
        {
            if (File.Exists(BASE_PATH))
            {
                string jarr = File.ReadAllText(BASE_PATH);
                var list = JsonConvert.DeserializeObject<List<string>>(jarr);
                try
                {
                    viewModel.LoadCharacterFromJson(list);
                }
                catch (Exception e)
                {
                    File.Delete(BASE_PATH);
                }
            }
        }

        public static void LoadUnionDatas()
        {
            if (File.Exists(BASE_PATH_UNION))
            {
                string jarr = File.ReadAllText(BASE_PATH_UNION);
                var unionStatus = JsonConvert.DeserializeObject<EquipmentStatus>(jarr);
                viewModel.UnionStatus = unionStatus;
            }
        }


        public static void UpdateCharacterDatas()
        {
            SaveCharacterData();
            SaveUnionData();
        }

        private static void SaveCharacterData()
        {
            var CharacterJsonDatas = GetCharacterJsonDatas();

            JArray jarr = new JArray();
            for (int i = 0; i < CharacterJsonDatas.Count; i++)
            {
                jarr.Add(CharacterJsonDatas[i]);
            }

            if (File.Exists(BASE_PATH))
            {
                File.Delete(BASE_PATH);
            }

            File.WriteAllText(BASE_PATH, jarr.ToString());
        }

        public static List<string> GetCharacterJsonDatas()
        {
            List<string> retval = new List<string>();

            for (int i = 0; i < viewModel.CharacterList.Count; i++)
            {
                string json = JsonConvert.SerializeObject(viewModel.CharacterList[i]);
                retval.Add(json);
            }

            return retval;
        }

        private static void SaveUnionData()
        {
            string json = JsonConvert.SerializeObject(Setting.UnionStatus);

            if (File.Exists(BASE_PATH_UNION))
            {
                File.Delete(BASE_PATH_UNION);
            }

            File.WriteAllText(BASE_PATH_UNION, json);
        }

        #endregion

        #region Thread

        public static void Load()
        {
            LoadThread.Start();
        }

        private static void LoadData()
        {
            viewModel.LoadWz(Settings.Default.MapleStoryPath);
            LoadCharacterDatas();
            LoadUnionDatas();

            App.Current.Dispatcher.Invoke(() => 
            {
                OnWzLoaded?.Invoke(null, null);
            });

            LoadThread.Join();
        }

        #endregion
    }
}
