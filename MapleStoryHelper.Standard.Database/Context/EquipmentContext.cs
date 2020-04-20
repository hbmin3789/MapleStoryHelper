using MapleStoryHelper.Standard.Item;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Database.Context
{
    public class EquipmentContext : DbContext
    {
        private string DATABASE_NAME = "Equipment.db";

        public DbSet<StatusBase> Status { get; set; }
        public DbSet<EquipmentItem> Equipment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var CurDir = Environment.CurrentDirectory;
            options.UseSqlite("Data Source=" + DATABASE_NAME);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusBase>().HasOne<EquipmentItem>();
        }

    }
}
