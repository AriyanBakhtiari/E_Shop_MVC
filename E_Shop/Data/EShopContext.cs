using E_Shop.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Data
{
    public class EShopContext : DbContext
    {
        //
        public EShopContext(DbContextOptions<EShopContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Select Key CategoryToProduct
            modelBuilder.Entity<CategoryToProduct>().HasKey(c => new { c.CategoryId, c.ProductId });
            #endregion

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
            });



            #region SeedData 
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "ورزشی",
                Description = "محصولات ورزشی"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "مردانه",
                Description = "محصولات مزدانه"
            });

            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 1,
                Price = 5000,
                QuantityInStock = 1,
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 2,
                Price = 15000,
                QuantityInStock = 10,
            }); 
            modelBuilder.Entity<Item>().HasData(new Item
            {
                Id = 3,
                Price = 45000,
                QuantityInStock = 24,
            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                ItemId = 1,
                Name = "تیشرت ورزشی مردانه ",
                Description = "تیشرت ورزشی مردانه شرکت متفرقه",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                ItemId = 2,
                Name = "پیراهن مردانه",
                Description = "پیرهن مردانه رسمی ",
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                ItemId = 3,
                Name = "کلاه مردانه",
                Description = "کلاس ورزشی مردانه",
            });

            modelBuilder.Entity<CategoryToProduct>().HasData(
            new CategoryToProduct { ProductId = 1, CategoryId = 1, },
            new CategoryToProduct { ProductId = 1, CategoryId = 2, },
            new CategoryToProduct { ProductId = 2, CategoryId = 1, },
            new CategoryToProduct { ProductId = 2, CategoryId = 2, },
            new CategoryToProduct { ProductId = 3, CategoryId = 1, },
            new CategoryToProduct { ProductId = 3, CategoryId = 2, });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
