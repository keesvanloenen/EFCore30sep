using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => new { e.StudentId, e.CourseId });

        builder.Property(e => e.Grade)
            .IsRequired(false)
            .HasColumnType("decimal(3,2)");

        builder.HasData(
            new Enrollment { CourseId = 1045, StudentId = 24, Grade = 1.50m },
            new Enrollment { CourseId = 1045, StudentId = 27, Grade = 2.50m },
            new Enrollment { CourseId = 1050, StudentId = 26, Grade = 3.50m },
            new Enrollment { CourseId = 1050, StudentId = 27, Grade = 3.50m },
            new Enrollment { CourseId = 1050, StudentId = 29, Grade = 3.50m },
            new Enrollment { CourseId = 1061, StudentId = 25, Grade = 4.00m },
            new Enrollment { CourseId = 1061, StudentId = 26, Grade = 3.00m },
            new Enrollment { CourseId = 1061, StudentId = 28, Grade = 4.00m },
            new Enrollment { CourseId = 1061, StudentId = 29, Grade = 4.00m },
            new Enrollment { CourseId = 2021, StudentId = 6, Grade = 4.00m },
            new Enrollment { CourseId = 2021, StudentId = 7, Grade = 3.00m },
            new Enrollment { CourseId = 2021, StudentId = 8, Grade = 2.50m },
            new Enrollment { CourseId = 2021, StudentId = 9, Grade = 3.50m },
            new Enrollment { CourseId = 2021, StudentId = 10, Grade = 3.00m },
            new Enrollment { CourseId = 2030, StudentId = 6, Grade = 3.50m },
            new Enrollment { CourseId = 2030, StudentId = 7, Grade = 4.00m },
            new Enrollment { CourseId = 2042, StudentId = 8, Grade = 3.50m },
            new Enrollment { CourseId = 2042, StudentId = 9, Grade = 4.00m },
            new Enrollment { CourseId = 2042, StudentId = 10, Grade = 3.00m },
            new Enrollment { CourseId = 4022, StudentId = 15, Grade = 4.00m },
            new Enrollment { CourseId = 4022, StudentId = 16, Grade = 3.00m },
            new Enrollment { CourseId = 4022, StudentId = 17, Grade = 2.50m },
            new Enrollment { CourseId = 4022, StudentId = 18, Grade = 2.00m },
            new Enrollment { CourseId = 4022, StudentId = 19, Grade = null },
            new Enrollment { CourseId = 4022, StudentId = 20, Grade = 3.50m },
            new Enrollment { CourseId = 4022, StudentId = 23, Grade = 3.00m },
            new Enrollment { CourseId = 4022, StudentId = 24, Grade = 3.00m },
            new Enrollment { CourseId = 4041, StudentId = 11, Grade = 3.50m },
            new Enrollment { CourseId = 4041, StudentId = 12, Grade = null },
            new Enrollment { CourseId = 4041, StudentId = 13, Grade = 2.50m },
            new Enrollment { CourseId = 4041, StudentId = 14, Grade = null },
            new Enrollment { CourseId = 4041, StudentId = 16, Grade = 3.00m },
            new Enrollment { CourseId = 4041, StudentId = 23, Grade = 3.50m },
            new Enrollment { CourseId = 4061, StudentId = 14, Grade = null },
            new Enrollment { CourseId = 4061, StudentId = 15, Grade = 4.00m },
            new Enrollment { CourseId = 4061, StudentId = 21, Grade = 4.00m },
            new Enrollment { CourseId = 4061, StudentId = 22, Grade = 2.00m },
            new Enrollment { CourseId = 4061, StudentId = 23, Grade = 2.50m }
        );
    }
}
