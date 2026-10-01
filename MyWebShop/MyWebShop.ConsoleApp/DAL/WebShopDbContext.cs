using Microsoft.EntityFrameworkCore;
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


    //protected override void OnConfiguring(DbContextOptionsBuilder builder)
    //{
    //    builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyWebShop;ConnectRetryCount=0");
    //}


    // Inject the context options in the constructor              👇
    public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);      // 🥸 keep me here

        builder.ApplyConfiguration(new CustomerConfiguration());

        //builder.Entity<Product>()
        //    .UseTpcMappingStrategy();

        builder.Entity<Order>()
            .HasKey(o => o.Id);

        builder.Entity<Order>()
            .Property(o => o.TotalAmount)
            //.HasColumnType("decimal(7,2)")
            .HasPrecision(7, 2);

        builder.Entity<Order>().HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey("CustomerId")        // still  a shadow property!
            .OnDelete(DeleteBehavior.Cascade);
    }
}
