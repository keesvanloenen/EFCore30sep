using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .HasMaxLength(50)
            .IsConcurrencyToken()
            .IsRequired();

        builder.Property(d => d.Budget)
            .HasColumnType("Money")
            .IsRequired();

        builder.Property(d => d.StartDate)
            .IsRequired();

        builder
            .HasOne(d => d.Administrator)
            .WithMany(a => a.Departments)
            .HasForeignKey(d => d.AdministratorId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);      // Default is ClientSetNull
                                                    // However the requirement is:
                                                    // "set to null directly in the database"

        // builder.HasQueryFilter(d => d.AdministratorId.HasValue);

        builder.HasData(
            new Department
            {
                Id = 1,
                Name = "Engineering",
                Budget = 350000.0000M,
                StartDate = new DateOnly(2007, 1, 9),
                AdministratorId = 31
            },
            new Department
            {
                Id = 2,
                Name = "English",
                Budget = 120000.0000M,
                StartDate = new DateOnly(2007, 1, 9),
                AdministratorId = 34
            },
            new Department
            {
                Id = 3,
                Name = "Economics",
                Budget = 200000.0000M,
                StartDate = new DateOnly(2007, 1, 9),
                AdministratorId = 33
            },
            new Department
            {
                Id = 4,
                Name = "Mathematics",
                Budget = 250000.0000M,
                StartDate = new DateOnly(2007, 1, 9),
                AdministratorId = 32
            }
        );
    }
}
