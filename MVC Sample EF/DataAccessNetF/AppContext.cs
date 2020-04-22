using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DataAccessNetF
{
    class AppContext : DbContext
    {
        public AppContext()
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>().HasMany(p1 => p1.Friends).WithMany().Map(t => t.MapLeftKey("UserId")
                    .MapRightKey("FriendId").ToTable("UserFriends"));

            modelBuilder.Entity<Pet>()
                .HasRequired(pet => pet.Owner)
                .WithMany(p => p.Pets)
                .HasForeignKey<int>(pet => pet.OwnerId);

            modelBuilder.Entity<Person>().HasOptional(t => t.Partner).WithMany().HasForeignKey(t => t.PartnerId);

        }
    }
}
