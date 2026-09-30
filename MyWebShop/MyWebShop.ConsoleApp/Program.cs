using Microsoft.EntityFrameworkCore;
using MyWebShop.ConsoleApp.DAL;
using MyWebShop.ConsoleApp.Models;

namespace MyWebShop.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<WebShopDbContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyWebShop;ConnectRetryCount=0")
            .Options;
                
        using var context = new WebShopDbContext(options);
        context.Database.EnsureDeleted();       // quick prototyping
        context.Database.EnsureCreated();       // quick prototyping

        var customer1 = new Customer { Name = "Ab" };
        var customer2 = new Customer { Name = "Bo" };
        var customer3 = new Customer { Name = "Cas" };

        context.Customers.AddRange([customer1, customer2, customer3]);
        context.SaveChanges();

        ShowCustomers();
    }

    private static void ShowCustomers()
    {
        using var context = new WebShopDbContext();

        var customers = context.Customers;

        foreach(var customer in customers)
        {
            Console.WriteLine($"{customer.Id} {customer.Name}");
        }
        
    }
}
