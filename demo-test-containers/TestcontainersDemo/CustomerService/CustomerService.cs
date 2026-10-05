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