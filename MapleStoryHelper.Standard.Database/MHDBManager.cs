using MapleStoryHelper.Standard.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
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
    }
}
