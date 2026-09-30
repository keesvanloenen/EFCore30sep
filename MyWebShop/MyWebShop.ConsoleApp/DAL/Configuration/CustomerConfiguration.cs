using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebShop.ConsoleApp.Models;

namespace MyWebShop.ConsoleApp.DAL.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);             // primary key kolom

        builder.Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired(false);

        builder.Property(c => c.CreditLimit)
            .HasColumnType("decimal(18,2)")
            .HasPrecision(18, 2);
    }
}
