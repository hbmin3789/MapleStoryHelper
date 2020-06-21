using MapleStoryHelper.Framework.ResourceManager.Utils;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public class MapleWz
    {
        private string FilePath;

        #region WzFile

        private StringWzReader stringWzReader;

        private Wz_File characterWz;
        private Wz_File stringWz;

        private Wz_Structure CharacterWzStruct
        {
            get => characterWz.WzStructure;
        }
        private Wz_Structure StringWzStruct
        {
            get => stringWz.WzStructure;
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

            CharacterWzStruct.Load(FilePath + "\\Character.wz");
            StringWzStruct.Load(FilePath + "\\String.wz");
            if(stringWz.Loaded == true)
            {
                stringWzReader.Load(StringWzStruct,CharacterWzStruct);
            }
        }

        #endregion

        #region GetItems

        public List<EquipmentItem> GetEquipmentItems(EEquipmentCategory category, string keyWord)
        {
            var items = stringWzReader.GetEquipmentItems(category, keyWord);
            if(category == EEquipmentCategory.Weapon || category == EEquipmentCategory.SubWeapon || category == EEquipmentCategory.Emblem)
            {
                
            }
            for(int i = 0; i < items.Count; i++)
            {
                items[i].ImgBitmapSource = items[i].ImgByte.LoadImage();
            }
            return items;
        }

        #endregion

        private void SaveFilePath(string filePath)
        {
            FilePath = filePath;
            LoadWzFile();
        }
    }
}
