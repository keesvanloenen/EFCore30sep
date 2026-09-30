using Microsoft.EntityFrameworkCore;
using MyWebShop.ConsoleApp.Models;

namespace MyWebShop.ConsoleApp.DAL;

public class WebShopDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

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

        builder.Entity<Customer>()
            .Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

    }
}
