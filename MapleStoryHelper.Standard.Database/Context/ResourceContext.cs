using MapleStoryHelper.Standard.Common;
using MapleStoryHelper.Standard.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Database.Context
{
    public class ResourceContext : DbContext
    {
        private string DATABASE_NAME = "Resources.db";

        public DbSet<MHResource> ResourceDatas { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=" + DATABASE_NAME);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MHResource>();
        }

        internal void AddResource(MHResource res)
        {
            ResourceDatas.Add(res);
        }
    }
}
