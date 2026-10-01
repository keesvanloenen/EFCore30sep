namespace MyWebShop.ConsoleApp.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }

    //public ICollection<Product> Products { get; } = [];

    // Navigation property for many-to-many with explicit join table:
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
}
