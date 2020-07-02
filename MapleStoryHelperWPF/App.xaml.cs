using MapleStoryHelper.Framework.ResourceManager;
using MapleStoryHelper.Standard.Character.Model;
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
using System.Threading.Tasks;
using System.Windows;

namespace MapleStoryHelperWPF
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static string BASE_PATH = AppDomain.CurrentDomain.BaseDirectory + "Data.dat";
        public static MapleStoryHelperViewModel viewModel = new MapleStoryHelperViewModel();
        public static MapleWz Wz
        {
            get => viewModel.MapleWz;
        }

        public static List<string> CharacterJsonDatas
        {
            get => GetCharacterJsonDatas();
        }

        public static void LoadCharacterDatas()
        {
            if (File.Exists(BASE_PATH))
            {
                string jarr = File.ReadAllText(BASE_PATH);
                var list = JsonConvert.DeserializeObject<List<string>>(jarr);
                try
                {
                    App.viewModel.LoadCharacterJson(list);
                }
                catch(Exception e)
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
    }
}
