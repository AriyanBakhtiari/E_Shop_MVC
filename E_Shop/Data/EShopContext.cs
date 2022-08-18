using System;
using E_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Data
{
    public class EShopContext : DbContext
    {
        //
        public EShopContext(DbContextOptions<EShopContext> options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SeedData Category
            modelBuilder.Entity<Category>().HasData( new Category
            {
                Id = 1,
                Name = "Test",
                Description = "Test"
            });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
