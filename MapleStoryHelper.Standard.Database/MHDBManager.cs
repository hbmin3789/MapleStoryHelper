using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Database.Context;
using MapleStoryHelper.Standard.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MapleStoryHelper.Standard.Database
{
    public class MHDBManager
    {
        public ResourceContext ResourceContext { get; set; }
        public EquipmentContext EquipmentContext { get; set; }
        public CharacterContext CharacterContext { get; set; }

        public MHDBManager()
        {
            InitVariables();
            //InitTables();
        }

        #region Initialize

        private void InitVariables()
        {
            ResourceContext = new ResourceContext();
            EquipmentContext = new EquipmentContext();
            CharacterContext = new CharacterContext();
        }

        private void InitTables()
        {
            RelationalDatabaseCreator databaseCreator;
            databaseCreator = (RelationalDatabaseCreator)ResourceContext.Database.GetService<IDatabaseCreator>();
            if (!databaseCreator.Exists())
            {
                databaseCreator.Create();
                databaseCreator.CreateTables();
            }

            databaseCreator = (RelationalDatabaseCreator)EquipmentContext.Database.GetService<IDatabaseCreator>();
            if (!databaseCreator.Exists())
            {
                databaseCreator.Create();
                databaseCreator.CreateTables();
            }

            databaseCreator = (RelationalDatabaseCreator)CharacterContext.Database.GetService<IDatabaseCreator>();
            if (!databaseCreator.Exists())
            {
                databaseCreator.Create();
                databaseCreator.CreateTables();
            }
        }

        #endregion

        #region DataMethod

        #region Save

        public void SaveResource(MHResource res)
        {
            ResourceContext.AddResource(res);
            SaveChanges();
        }

        public void SaveEquipmentItem(EquipmentItem item)
        {
            EquipmentContext.AddItem(item);
            SaveChanges();
        }

        public void SaveCharacter(Character.Character character)
        {
            CharacterContext.Add(character);
            CharacterContext.SaveChanges();
        }

        #endregion

        #region Load

        public List<MHResource> GetResource()
        {
            return ResourceContext.ResourceDatas.ToList();
        }

        public List<EquipmentItem> GetEquipmentItems()
        {
            return EquipmentContext.EquipmentData.ToList();
        }

        public List<Character.Character> GetCharacterItems()
        {
            return CharacterContext.CharacterData.ToList();
        }

        #endregion

        #endregion

        private void SaveChanges()
        {
            ResourceContext.SaveChanges();
            EquipmentContext.SaveChanges();
            CharacterContext.SaveChanges();
        }
    }
}
