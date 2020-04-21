using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Database.Context;
using MapleStoryHelper.Standard.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapleStoryHelper.Standard.Database
{
    public class MHDBManager
    {
        public ResourceContext ResourceContext { get; set; }
        public EquipmentContext EquipmentContext { get; set; }

        public MHDBManager()
        {
            InitVariables();
            InitTables();
        }

        #region Initialize

        private void InitVariables()
        {
            ResourceContext = new ResourceContext();
            EquipmentContext = new EquipmentContext();
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

        #endregion

        #region Load

        public List<MHResource> GetResource()
        {
            return ResourceContext.ResourceDatas.ToList();
        }

        public List<EquipmentItem> GetEquipmentItems()
        {
            return EquipmentContext.Equipment.ToList();
        }

        #endregion

        #endregion

        private void SaveChanges()
        {
            ResourceContext.SaveChanges();
            EquipmentContext.SaveChanges();
        }
    }
}
