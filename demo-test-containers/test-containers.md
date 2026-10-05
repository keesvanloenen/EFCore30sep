# Aan de slag met Testcontainers voor .NET

## Overzicht

Testcontainers is een testing library die eenvoudige en lichtgewicht APIs biedt voor het opzetten van integratietests met echte services verpakt in Docker containers. Met Testcontainers kun je tests schrijven die communiceren met hetzelfde type services dat je in productie gebruikt, zonder mocks of in-memory services.

Laten we kijken hoe we Testcontainers kunnen gebruiken om een .NET applicatie te testen met een SQL Server database.

## 1. Solution met class library en test project

1. Maak een solution **TestcontainersDemo** project met _Class Library_ **CustomerService**.

1. Voeg _xUnit Test_ project toe **CustomerService.Tests**.

1. Voeg het package _`Microsoft.EntityFrameworkCore.SqlServer`_ toe aan het CustomerService project.

## Implementeer business logic

1. Maak een **Customer** type

   ```cs
   namespace CustomerService;

   public class Customer
   {
       public long Id { get; set; }
       public string Name { get; set; } = string.Empty;
   }
   ```

1. Maak een **CustomerDbContext** class

   ```cs
   using Microsoft.EntityFrameworkCore;

   namespace CustomerService;

   public class CustomerDbContext : DbContext
   {
     public DbSet<Customer> Customers { get; set; }

     public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
     {
     }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Customer>(entity =>
           {
               entity.HasKey(c => c.Id);
               entity.Property(c => c.Name)
                 .HasMaxLength(100)
                 .IsRequired();
           });
       }
   }
   ```

1. Maak een **CustomerService** class

   ```cs
   namespace CustomerService;

   public class CustomerService
   {
       private readonly CustomerDbContext _context;

       public CustomerService(CustomerDbContext context)
       {
           _context = context;
           _context.Database.EnsureCreated();
       }

       public IEnumerable<Customer> GetAllCustomers() =>
           _context.Customers.ToList();

       public void Add(Customer Customer)
       {
           _context.Customers.Add(Customer);
           _context.SaveChanges();
       }
   }
   ```

## Voeg Testcontainers dependencies toe

1. Voeg het package _`Testcontainers.MsSql`_ toe aan het test project.

## Maak Test class
1. Maak een **CustomerServiceTest** klasse aan in het testproject

   ```cs
   using Microsoft.EntityFrameworkCore;
   using Testcontainers.MsSql;

   namespace CustomerService.Tests;

   public sealed class CustomerServiceTest : IAsyncLifetime
   {
       private readonly MsSqlContainer _msSql = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-latest")
           .Build();

       public Task InitializeAsync() => _msSql.StartAsync();

       public Task DisposeAsync() => _msSql.DisposeAsync().AsTask();

       [Fact]
       public void ShouldReturnTwoCustomers()
       {
           // Given
           var options = new DbContextOptionsBuilder<CustomerDbContext>()
               .UseSqlServer(_msSql.GetConnectionString())
               .Options;

           using var context = new CustomerDbContext(options);
           var CustomerService = new CustomerService(context);

           // When
           CustomerService.Add(new Customer { Name = "Ab" });
           CustomerService.Add(new Customer { Name = "Bo" });
           var Customers = CustomerService.GetAllCustomers();

           // Then
           Assert.Equal(2, Customers.Count());
           Assert.Equal("Ab", Customers.First().Name);
           Assert.Contains(Customers, c => c.Name == "Bo");
       }
   }
   ```

   - **MsSqlContainer declaratie** - Declareer een `MsSqlContainer` door de Docker image naam `mcr.microsoft.com/mssql/server:2022-latest` door te geven aan de MsSql builder
   - **Container lifecycle** - De SQL Server container wordt gestart met behulp van xUnit.net's `IAsyncLifetime` interface, die `InitializeAsync` uitvoert direct nadat de testklasse is aangemaakt
   - **Test implementatie** - `ShouldReturnTwoCustomers()` test
   - **Cleanup** - Ten slotte wordt de SQL Server container verwijderd in de `DisposeAsync()` methode, die wordt uitgevoerd nadat de testmethode is voltooid

## Voordelen van Testcontainers

- ✅ Test met echte databases in plaats van mocks of in-memory alternatieven
- ✅ Consistente test omgeving voor alle ontwikkelaars
- ✅ Geen lokale database installatie nodig
- ✅ Eenvoudig te integreren in CI/CD pipelines
- ✅ Automatische cleanup na tests
