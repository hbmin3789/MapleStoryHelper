using MapleStoryHelper.Standard.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Database.Context
{
    public class ResourceContext : DbContext
    {
        private string DATABASE_NAME = "Resources.db";

        public DbSet<MHResource> ReourceDatas { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var CurDir = Environment.CurrentDirectory;
            options.UseSqlite("Data Source=" + DATABASE_NAME);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<FingerPrintData>()
        //        .HasOne(f => f.studentFingerData)
        //        .WithMany(s => s.FingerDatas)
        //        .HasForeignKey(f => f.StudentId);
        //}
    }
}
