using MapleStoryHelper.Standard.Item;
using MapleStoryHelper.Standard.Item.Equipment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Database.Context
{
    public class EquipmentContext : DbContext
    {
        private string DATABASE_NAME = "Equipment.db";

        public DbSet<EquipmentStatus> StatusData { get; set; }
        public DbSet<EquipmentItem> EquipmentData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var CurDir = Environment.CurrentDirectory;
            options.UseSqlite("Data Source=" + DATABASE_NAME);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentItem>()
                        .HasOne(e => e.Status)
                        .WithOne(s => s.Equipment)
                        .HasForeignKey<EquipmentItem>(e => e.PrimaryKey);
        }

        internal void AddItem(EquipmentItem item)
        {
            EquipmentData.Add(item);
            StatusData.Add(item.Status);
        }
    }
}
