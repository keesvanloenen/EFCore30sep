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
        //ShowCustomers(options);
        //ShowProducts(options);
        ShowOrders(options);
    }

    private static void ShowOrders(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);

        var orders = context.Orders
            .Include(o => o.Customer);      // 😀 later more...
        
        foreach (var order in orders)
        {
            Console.WriteLine($"[{order.Id}] {order.OrderDate} {order.TotalAmount:c} - Customer: {order.Customer.Name} and the FK is: {order.CustomerId}");
        }
    }

    private static void ShowProducts(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);

        var products = context.Products.Where(p => p.Price > 1);

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id} {product.Name} {product.Price:c}");
        }
    }

    private static void InitalizeDb(DbContextOptions<WebShopDbContext> options)
    {
        using (var context = new WebShopDbContext(options))
        {
            context.Database.EnsureDeleted();       // quick prototyping
            context.Database.EnsureCreated();       // quick prototyping
        }
    }

    private static void DataSeed(DbContextOptions<WebShopDbContext> options)
    {
        var customer1 = new Customer { Name = "Ab" };
        var customer2 = new Customer { Name = "Bo" };
        var customer3 = new Customer { Name = "Cas" };

        customer1.Orders.Add(new Order { OrderDate = DateTime.Now.AddDays(-4), TotalAmount = 450.00m });
        customer1.Orders.Add(new Order { OrderDate = DateTime.Now.AddDays(-7), TotalAmount = 190.00m });
        customer2.Orders.Add(new Order { OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 27.50m });

        using var context = new WebShopDbContext(options);
        context.Customers.AddRange([customer1, customer2, customer3]);
        context.SaveChanges();

        var physicalProduct1 = new PhysicalProduct { Name = "Laptop", Price = 999.99m, Weight = 1.5m };
        var physicalProduct2 = new PhysicalProduct { Name = "Mouse", Price = 19.99m, Weight = 0.1m };
        var digitalProduct1 = new DigitalProduct { Name = "C# for Dummies", Price = 9.99m, FileSizeInMb = 5 };
        var digitalProduct2 = new DigitalProduct { Name = "LINQ Course", Price = 49.99m, FileSizeInMb = 1200 };

        context.Products.AddRange([physicalProduct1, physicalProduct2, digitalProduct1, digitalProduct2]);
        context.SaveChanges();
    }


    private static void ShowCustomers(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);

        var customers = context.Customers.OrderByDescending(c => c.Name);

        foreach(var customer in customers)
        {
            Console.WriteLine($"{customer.Id} {customer.Name}");
        }
    }
}
