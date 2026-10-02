using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebShop.ConsoleApp.Models;


public class Customer
{
    [Key]
    public int Id { get; set; }

    //[Key]
    //[Column(TypeName = "uniqueidentifier")]
    //public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(20)]
    public string? PhoneNumber { get; set; }

    public DateOnly BirthDate{ get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal CreditLimit { get; set; }

    public byte[] RowVersion { get; set; } = null!;    // 👈

    // Navigation Property
    public List<Order> Orders { get; set; } = [];
}
