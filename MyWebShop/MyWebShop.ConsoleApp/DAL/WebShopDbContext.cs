using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyWebShop.ConsoleApp.DAL.Configuration;
using MyWebShop.ConsoleApp.Models;

namespace MyWebShop.ConsoleApp.DAL;

public class WebShopDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PhysicalProduct> PhysicalProducts { get; set; }
    public DbSet<DigitalProduct> DigitalProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (!builder.IsConfigured)
        {
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyWebShop;ConnectRetryCount=0");
        }
    }


    // Inject the context options in the constructor              👇
    public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
    {
    }

    public WebShopDbContext()    // 👈 Add parameterless constructor for migrations
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);      // 🥸 keep me here

        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new ProductCategoryConfiguration());

        // If we don't want Tph (table per hierarchy), use Tpt or Tpc:
        // builder.Entity<Product>()
        //     .UseTpcMappingStrategy();
    }
}
