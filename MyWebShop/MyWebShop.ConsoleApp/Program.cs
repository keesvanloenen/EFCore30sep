using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWebShop.ConsoleApp.DAL;
using MyWebShop.ConsoleApp.Models;

namespace MyWebShop.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var config = builder.Build();

        var options = new DbContextOptionsBuilder<WebShopDbContext>()
            .UseSqlServer(config.GetConnectionString("DefaultConn"))
            .Options;

        InitalizeDb(options);
        DataSeed(options);
        ShowCustomers(options);
    }
    private static void InitalizeDb(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);
        context.Database.EnsureDeleted();       // quick prototyping
        context.Database.EnsureCreated();       // quick prototyping
    }

    private static void DataSeed(DbContextOptions<WebShopDbContext> options)
    {
        var customer1 = new Customer { Name = "Ab" };
        var customer2 = new Customer { Name = "Bo" };
        var customer3 = new Customer { Name = "Cas" };

        using var context = new WebShopDbContext(options);
        context.Customers.AddRange([customer1, customer2, customer3]);
        context.SaveChanges();
    }


    private static void ShowCustomers(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);

        var customers = context.Customers;

        foreach(var customer in customers)
        {
            Console.WriteLine($"{customer.Id} {customer.Name}");
        }
    }
}
