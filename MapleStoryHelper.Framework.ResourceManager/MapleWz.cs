using MapleStoryHelper.Framework.ResourceManager.Utils;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Character.Common;
using MapleStoryHelper.Standard.Character.Model;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using WzComparerR2.CharaSim;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public partial class MapleWz
    {
        private string FilePath;

        #region WzFile

        private StringWzReader stringWzReader;
        private SetItemManager setItemManager;

        private Wz_File characterWz;
        private Wz_File stringWz;
        private Wz_File skillWz;
        private Wz_File etcWz;
        private Wz_File mobWz;

        public Wz_Structure CharacterWzStruct
        {
            get => characterWz.WzStructure;
        }
        public Wz_Structure StringWzStruct
        {
            get => stringWz.WzStructure;
        }
        public Wz_Structure SkillWzStruct
        {
            get => skillWz.WzStructure;
        }
        public Wz_Structure EtcWzStruct
        {
            get => etcWz.WzStructure;
        }
        public Wz_Structure MobWzStruct
        {
            get => mobWz.WzStructure;
        }

        #endregion

        #region Constructor

        public MapleWz()
        {
            InitVariables();
        }

        /// <summary>
        /// Load .wz File
        /// </summary>
        /// <param name="filePath">The folder path where .wz file exists</param>
        public MapleWz(string filePath)
        {
            SaveFilePath(filePath);
        }

        #endregion

        #region Initialize

        private void InitVariables()
        {
            stringWzReader = new StringWzReader();
            setItemManager = new SetItemManager();
        }

        #endregion

        #region LoadFile

        /// <summary>
        /// Load .wz File
        /// </summary>
        /// <param name="filePath">The folder where .wz file exists</param>
        public void LoadFile(string filePath)
        {
            SaveFilePath(filePath);
        }

        private void LoadWzFile()
        {
            if (FilePath.Last().ToString().Equals("\\"))
            {
                FilePath = FilePath.Remove(FilePath.LastIndexOf("\\"));
            }

            characterWz = new Wz_File(FilePath + "\\Character.wz", new Wz_Structure());
            stringWz = new Wz_File(FilePath + "\\String.wz", new Wz_Structure());
            skillWz = new Wz_File(FilePath + "\\Skill.wz", new Wz_Structure());
            etcWz = new Wz_File(FilePath + "\\Etc.wz", new Wz_Structure());
            mobWz = new Wz_File(FilePath + "\\Mob.wz", new Wz_Structure());

            CharacterWzStruct.Load(FilePath + "\\Character.wz");
            StringWzStruct.Load(FilePath + "\\String.wz");
            SkillWzStruct.Load(FilePath + "\\Skill.wz");
            EtcWzStruct.Load(FilePath + "\\Etc.wz");
            MobWzStruct.Load(FilePath + "\\Mob.wz");

            if(stringWz.Loaded == true)
            {
                stringWzReader.Load(StringWzStruct, CharacterWzStruct);
            }
        }

        #endregion

        private void SaveFilePath(string filePath)
        {
            FilePath = filePath;
            LoadWzFile();
        }
    }
}
