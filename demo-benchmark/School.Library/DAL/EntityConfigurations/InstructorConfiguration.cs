using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasData(
            new Instructor { Id = 1, LastName = "Fakhouri", FirstName = "Fadi", HireDate = DateOnly.Parse("06/08/2002") },
            new Instructor { Id = 2, LastName = "Serrano", FirstName = "Stacy", HireDate = DateOnly.Parse("01/06/1999") },
            new Instructor { Id = 3, LastName = "Stewart", FirstName = "Jasmine", HireDate = DateOnly.Parse("12/10/1997") },
            new Instructor { Id = 4, LastName = "Xu", FirstName = "Kristen", HireDate = DateOnly.Parse("23/07/2001") },
            new Instructor { Id = 5, LastName = "Van Houten", FirstName = "Roger", HireDate = DateOnly.Parse("07/12/2000") }
        );
    }
}
