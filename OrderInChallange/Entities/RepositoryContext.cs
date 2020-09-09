using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuCategory> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Restaurant>().HasKey(e => new { e.Id });
            //modelBuilder.Entity<MenuItem>().HasKey(e => new { e.Id });
            //modelBuilder.Entity<MenuCategory>().HasKey(e => new { e.Id });
            //modelBuilder.Ignore<MenuCategory>();
            //modelBuilder.Entity<MenuCategory>().HasNoKey();
        }
    }
}
