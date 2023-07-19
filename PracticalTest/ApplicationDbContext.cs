using Microsoft.EntityFrameworkCore;
using PracticalTest.Entities;
using System;
using System.Reflection.Metadata;

namespace PracticalTest
{
    public class ApplicationDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().Property(f => f.FriendName).HasMaxLength(25);
        }
        public DbSet<Friend> Friends { get; set; }
    }
}
