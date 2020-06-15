using MapleStoryHelper.Framework.ResourceManager.Utils;
using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using MapleStoryHelper.Standard.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
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

        private Dictionary<EEquipmentCategory, List<EquipmentItem>> EquipItems;

        #region WzFile

        private Wz_File wzFile;
        private Wz_Structure wzStruct
        {
            get => wzFile.WzStructure;
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
            EquipItems = new Dictionary<EEquipmentCategory, List<EquipmentItem>>();
        }

        #endregion

        #region LoadFile

        /// <summary>
        /// Load .wz File
        /// </summary>
        /// <param name="filePath">The folder path where .wz file exists</param>
        public void LoadFile(string filePath)
        {
            SaveFilePath(filePath);
        }

        private void LoadWzFile()
        {
            wzFile = new Wz_File(FilePath, new Wz_Structure());
            wzStruct.Load(FilePath);
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
