using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasData(
            new Student { Id = 6, LastName = "Barzdukas", FirstName = "Gytis", EnrollmentDate = DateOnly.Parse("01/09/2005") },
            new Student { Id = 7, LastName = "Justice", FirstName = "Peggy", EnrollmentDate = DateOnly.Parse("01/09/2001") },
            new Student { Id = 8, LastName = "Li", FirstName = "Yan", EnrollmentDate = DateOnly.Parse("01/09/2002") },
            new Student { Id = 9, LastName = "Norman", FirstName = "Laura", EnrollmentDate = DateOnly.Parse("01/09/2003") },
            new Student { Id = 10, LastName = "Olivotto", FirstName = "Nino", EnrollmentDate = DateOnly.Parse("01/09/2005") },
            new Student { Id = 11, LastName = "Tang", FirstName = "Wayne", EnrollmentDate = DateOnly.Parse("01/09/2005") },
            new Student { Id = 12, LastName = "Alonso", FirstName = "Meredith", EnrollmentDate = DateOnly.Parse("01/09/2002") },
            new Student { Id = 13, LastName = "Lopez", FirstName = "Sophia", EnrollmentDate = DateOnly.Parse("01/09/2004") },
            new Student { Id = 14, LastName = "Browning", FirstName = "Meredith", EnrollmentDate = DateOnly.Parse("01/09/2000") },
            new Student { Id = 15, LastName = "Anand", FirstName = "Arturo", EnrollmentDate = DateOnly.Parse("01/09/2003") },
            new Student { Id = 16, LastName = "Walker", FirstName = "Alexandra", EnrollmentDate = DateOnly.Parse("01/09/2000") },
            new Student { Id = 17, LastName = "Powell", FirstName = "Carson", EnrollmentDate = DateOnly.Parse("01/09/2004") },
            new Student { Id = 18, LastName = "Jai", FirstName = "Damien", EnrollmentDate = DateOnly.Parse("01/09/2001") },
            new Student { Id = 19, LastName = "Carlson", FirstName = "Robyn", EnrollmentDate = DateOnly.Parse("01/09/2005") },
            new Student { Id = 20, LastName = "Bryant", FirstName = "Carson", EnrollmentDate = DateOnly.Parse("01/09/2001") },
            new Student { Id = 21, LastName = "Suarez", FirstName = "Robyn", EnrollmentDate = DateOnly.Parse("01/09/2004") },
            new Student { Id = 22, LastName = "Holt", FirstName = "Roger", EnrollmentDate = DateOnly.Parse("01/09/2004") },
            new Student { Id = 23, LastName = "Alexander", FirstName = "Carson", EnrollmentDate = DateOnly.Parse("01/09/2005") },
            new Student { Id = 24, LastName = "Morgan", FirstName = "Isaiah", EnrollmentDate = DateOnly.Parse("01/09/2001") },
            new Student { Id = 25, LastName = "Martin", FirstName = "Randall", EnrollmentDate = DateOnly.Parse("01/09/2005") },
            new Student { Id = 26, LastName = "Rogers", FirstName = "Cody", EnrollmentDate = DateOnly.Parse("01/09/2002") },
            new Student { Id = 27, LastName = "White", FirstName = "Anthony", EnrollmentDate = DateOnly.Parse("01/09/2001") },
            new Student { Id = 28, LastName = "Griffin", FirstName = "Rachel", EnrollmentDate = DateOnly.Parse("01/09/2004") },
            new Student { Id = 29, LastName = "Shan", FirstName = "Alicia", EnrollmentDate = DateOnly.Parse("01/09/2003") },
            new Student { Id = 30, LastName = "Gao", FirstName = "Erica", EnrollmentDate = DateOnly.Parse("30/01/2003") }
        );
    }
}
