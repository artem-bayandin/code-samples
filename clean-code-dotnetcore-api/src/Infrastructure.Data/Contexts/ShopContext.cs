using CrossCutting.Data.Extensions;
using Domain.Entities;
using Infrastructure.Data.Mappings;
using Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.Contexts
{
    public class ShopContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductLineItem> ProductLineItems { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: autoconfigure and autoadd
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductLineItemMap());

            // seeds
            // TODO: autoconfigure and autoadd
            modelBuilder.ApplyConfiguration(new ProductCategorySeed());

            modelBuilder.TypeDateTimeToDatetime2();
            modelBuilder.TypeStringToNvarchar255();
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.SetOnDeleteBehaviorToRestrict();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //// get the configuration from the app settings
            //var config = new ConfigurationBuilder()
            //    // Microsoft.Extensions.Configuration.FileExtensions
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    // Microsoft.Extensions.Configuration.Json
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //optionsBuilder.UseSqlServer(config.GetConnectionString("EntitiesDatabase"));
        }
    }
}
