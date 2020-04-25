using MapleStoryHelper.Standard.Character;
using MapleStoryHelper.Standard.Character.Status;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapleStoryHelper.Standard.Database.Context
{
    public class CharacterContext : DbContext
    {
        private string DATABASE_NAME = "CharacterData.db";

        public DbSet<Character.Character> CharacterData { get; set; }
        public DbSet<CharacterStatus> CharacterStatusData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var CurDir = Environment.CurrentDirectory;
            options.UseSqlite("Data Source=" + DATABASE_NAME);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character.Character>()
                        .HasOne(e => e.CharacterStatus)
                        .WithOne(s => s.Character)
                        .HasForeignKey<Character.Character>(e => e.PrimaryKey);
        }

        internal void AddItem(Character.Character item)
        {
            CharacterData.Add(item);
            CharacterStatusData.Add(item.CharacterStatus);
        }

    }
}
