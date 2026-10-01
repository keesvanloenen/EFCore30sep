namespace MyWebShop.ConsoleApp.Models;

public abstract class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }

    // public ICollection<Category> Categories { get; } = [];

    // Navigation property for many-to-many with explicit join table:
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
}
