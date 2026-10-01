using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.ConsoleApp.Models;

namespace MyWebShop.ConsoleApp.DAL.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.TotalAmount)
            //.HasColumnType("decimal(7,2)")    // SQL Server specific
            .HasPrecision(7, 2);

        builder
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey("CustomerId")        // still  a shadow property, when not defined in model
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
