using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWebShop.ConsoleApp.DAL;
using MyWebShop.ConsoleApp.Models;
using System.Text;

namespace MyWebShop.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var config = builder.Build();

        var options = new DbContextOptionsBuilder<WebShopDbContext>()
            .UseSqlServer(config.GetConnectionString("DefaultConn"))
            .Options;

        InitalizeDb(options);
        DataSeed(options);
        //ShowCustomers(options);
        //ShowProducts(options);
        //ShowOrders(options);
        //ShowCategories(options);
        //ShowCustomer(options);

        //SeverSideClientSide(options);

        ExplicitLoading(options);
    }

    private static void ExplicitLoading(DbContextOptions<WebShopDbContext> options)
    {
        Console.Write("Enter the customer id: ");
        string input = Console.ReadLine() ?? string.Empty;

        int customerId = int.Parse(input);

        using var context = new WebShopDbContext(options);

        Customer? customer = context.Customers.Find(customerId);

        if (customer is null)
        {
            Console.WriteLine($"Customer with Id {customerId} not found");
            return;
        }

        context.Entry(customer)
            .Collection(c => c.Orders)
            .Load();

        foreach(var order in customer.Orders)
        {
            Console.WriteLine($"\t[{order.Id}] - {order.OrderDate:dd.MM.yyyy} {order.TotalAmount:C}");
        }


    }

    private static void SeverSideClientSide(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);

        var customers = context.Customers
            .AsNoTracking()                 // don't store in the change tracker
            .Where(c => c.Name.Length >= 3)
            .Select(c => new { c.Id, NameInUpper = c.Name.ToUpper() })
            .ToList()                       // move to memory, so we can do things the db can't 
            .Where(c => IsVowelName(c.NameInUpper)); // 👈 added

        //Console.WriteLine(customers.ToQueryString());


        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.Id} {customer.NameInUpper}");
        }
    }

    private static bool IsVowelName(string name) =>
        char.ToLower(name[0]) is 'a' or 'e' or 'i' or 'u' or 'ü';
        

    private static void ShowCustomer(DbContextOptions<WebShopDbContext> options)
    {
        // FirstOrDefault()
        // First()
        // SingleOrDefault()
        // Single()
        // Find() // 🍾

        using var context = new WebShopDbContext(options);

        Customer? customer1 = context.Customers.SingleOrDefault(c => c.Name.Contains("el"));
        Console.WriteLine($"Found: {(customer1?.Name ?? "nothing")}");

        Customer? customer2 = context.Customers.FirstOrDefault(c => c.Id == 3);
        Customer? customer3 = context.Customers.Find(3);

        Console.WriteLine(customer2?.Name + ", " + customer3?.Name);
    }

    private static void ShowCategories(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);

        var productCategories = context.ProductCategories
            .Include(pc => pc.Product)      // 😀 later more...
            .Include(pc => pc.Category);

        //var productCategories = context.Products
        //    .Include(p => p.ProductCategories)      // 😀 later more...
        //    .ThenInclude(pc => pc.Category);

        Console.WriteLine(productCategories.ToQueryString());

        foreach (var pc in productCategories)
        {
            Console.WriteLine($"{pc.Category.Name} - {pc.Product.Name} ({pc.AddedOn})");
        }
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
        var customer4 = new Customer { Name = "Nico" };
        var customer5 = new Customer { Name = "Nele" };
        var customer6 = new Customer { Name = "Eva" };
        

        customer1.Orders.Add(new Order { OrderDate = DateTime.Now.AddDays(-4), TotalAmount = 450.00m });
        customer1.Orders.Add(new Order { OrderDate = DateTime.Now.AddDays(-7), TotalAmount = 190.00m });
        customer2.Orders.Add(new Order { OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 27.50m });

        using var context = new WebShopDbContext(options);
        context.Customers.AddRange([customer1, customer2, customer3, customer4, customer5, customer6]);
        context.SaveChanges();

        var physicalProduct1 = new PhysicalProduct { Name = "Laptop", Price = 999.99m, Weight = 1.5m };
        var physicalProduct2 = new PhysicalProduct { Name = "Mouse", Price = 19.99m, Weight = 0.1m };
        var digitalProduct1 = new DigitalProduct { Name = "C# for Dummies", Price = 9.99m, FileSizeInMb = 5 };
        var digitalProduct2 = new DigitalProduct { Name = "LINQ Course", Price = 49.99m, FileSizeInMb = 1200 };

        context.Products.AddRange([physicalProduct1, physicalProduct2, digitalProduct1, digitalProduct2]);
        context.SaveChanges();

        // Many-to-many: automatic (no explicit join table)
        var electronics = new Category { Name = "Electronics" };
        var software = new Category { Name = "Software" };
        var accessories = new Category { Name = "Accessories" };

        context.Categories.AddRange([electronics, software, accessories]);

        context.ProductCategories.AddRange([
            new ProductCategory { Product = physicalProduct1, Category = electronics, AddedOn = DateTime.Now.AddDays(-10) },
            new ProductCategory { Product = physicalProduct2, Category = electronics, AddedOn = DateTime.Now.AddDays(-1) },
            new ProductCategory { Product = physicalProduct2, Category = accessories, AddedOn = DateTime.Now.AddDays(-22) },
            new ProductCategory { Product = digitalProduct1, Category = software, AddedOn = DateTime.Now.AddDays(-7) },
            new ProductCategory { Product = digitalProduct2, Category = software, AddedOn = DateTime.Now.AddDays(-5) },
        ]);

        context.SaveChanges();
    }


    private static void ShowCustomers(DbContextOptions<WebShopDbContext> options)
    {
        using var context = new WebShopDbContext(options);

        IQueryable<Customer> customers = context.Customers
            .Where(c => c.Name.Contains('e'))
            .OrderByDescending(c => c.Name);

        Console.WriteLine(customers.ToQueryString());

        foreach(var customer in customers)
        {
            Console.WriteLine($"{customer.Id} {customer.Name}");
        }

        customers = customers.Where(c => c.Name.StartsWith("Ne"));
        
        Console.WriteLine(customers.ToQueryString());

        Console.WriteLine(customers.First().Name);

    }
}
