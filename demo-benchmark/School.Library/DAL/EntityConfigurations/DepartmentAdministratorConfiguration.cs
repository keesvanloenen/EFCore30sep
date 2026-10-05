using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class DepartmentAdministratorConfiguration : IEntityTypeConfiguration<DepartmentAdministrator>
{
    public void Configure(EntityTypeBuilder<DepartmentAdministrator> builder)
    {
        builder.HasData(
            new DepartmentAdministrator { Id = 31, LastName = "Abercrombie", FirstName = "Kim", HireDate = DateOnly.Parse("11/03/1995") },
            new DepartmentAdministrator { Id = 32, LastName = "Harui", FirstName = "Roger", HireDate = DateOnly.Parse("01/07/1998") },
            new DepartmentAdministrator { Id = 33, LastName = "Zheng", FirstName = "Roger", HireDate = DateOnly.Parse("12/02/2004") },
            new DepartmentAdministrator { Id = 34, LastName = "Kapoor", FirstName = "Candace", HireDate = DateOnly.Parse("15/01/2001") }
        );
    }
}
