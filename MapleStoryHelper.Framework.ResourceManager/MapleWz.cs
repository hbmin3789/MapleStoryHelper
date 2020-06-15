using MapleStoryHelper.Framework.ResourceManager.Utils;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WzComparerR2.WzLib;

namespace MapleStoryHelper.Framework.ResourceManager
{
    public class MapleWz
    {
        private string FilePath;

        #region WzFile

        private Wz_File CharacterWz;
        private Wz_File StringWz;

        private Wz_Structure CharacterWzStruct
        {
            get => CharacterWz.WzStructure;
        }
        private Wz_Structure StringWzStruct
        {
            get => StringWz.WzStructure;
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
            CharacterWz = new Wz_File(FilePath + "\\Character.wz", new Wz_Structure());
            StringWz = new Wz_File(FilePath + "\\String.wz", new Wz_Structure());

            CharacterWzStruct.Load(FilePath + "\\Character.wz");
            StringWzStruct.Load(FilePath + "\\String.wz");
        }

        #endregion

        #region GetItems

        #endregion

        private void SaveFilePath(string filePath)
        {
            FilePath = filePath;
            LoadWzFile();
        }
    }
}
