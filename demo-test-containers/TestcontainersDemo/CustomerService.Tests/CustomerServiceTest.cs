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