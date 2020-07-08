using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character.Model;
using MapleStoryHelper.Standard.SkillLib.Model;
using MapleStoryHelperWPF.Properties;
using MapleStoryHelperWPF.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        public static EventHandler OnLoaded;
        public static string BASE_PATH = AppDomain.CurrentDomain.BaseDirectory + "Data.dat";
        public static MapleStoryHelperViewModel viewModel = new MapleStoryHelperViewModel();

        public static MapleWz mapleWz 
        { 
            get => viewModel.MapleWz;
        }

        public static List<SkillBase> Skills { get; internal set; }

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

        public static void UpdateCharacterDatas()
        {
            var CharacterJsonDatas = GetCharacterJsonDatas();

            JArray jarr = new JArray();
            for(int i = 0; i < CharacterJsonDatas.Count; i++)
            {
                jarr.Add(CharacterJsonDatas[i]);
            }

            if (File.Exists(BASE_PATH))
            {
                File.Delete(BASE_PATH);
            }

            File.WriteAllText(BASE_PATH, jarr.ToString());
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

            App.Current.Dispatcher.Invoke(() => 
            {
                OnLoaded?.Invoke(null, null);
            });

            LoadThread.Join();
        }

        #endregion
    }
}
