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

    public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
    {
    }
}
