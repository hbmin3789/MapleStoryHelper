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
            options.UseSqlite("Data Source=" + DATABASE_NAME);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character.Character>()
                        .HasOne(c => c.CharacterStatus)
                        .WithOne(s => s.Character)
                        .HasForeignKey<Character.Character>(c => c.PrimaryKey);
        }

        internal void AddItem(Character.Character item)
        {
            CharacterData.Add(item);
            CharacterStatusData.Add(item.CharacterStatus);
        }

    }
}
