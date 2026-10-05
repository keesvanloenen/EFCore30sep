using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class OfficeAssignmentConfiguration : IEntityTypeConfiguration<OfficeAssignment>
{
    public void Configure(EntityTypeBuilder<OfficeAssignment> builder)
    {
        builder.HasKey(oa => oa.InstructorId);
        builder.Property(oa => oa.InstructorId)
            .ValueGeneratedNever();

        builder
            .Property(oa => oa.Location)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(oa => oa.Timestamp)
               .IsRowVersion()
               .IsRequired();

        builder
            .HasOne(oa => oa.Instructor)
            .WithOne(i => i.OfficeAssignment)
            .HasForeignKey<OfficeAssignment>(oa => oa.InstructorId);

        builder.HasData(
            new OfficeAssignment { InstructorId = 1, Location = "29 Adams" },
            new OfficeAssignment { InstructorId = 2, Location = "271 Williams" },
            new OfficeAssignment { InstructorId = 3, Location = "131 Smith" },
            new OfficeAssignment { InstructorId = 4, Location = "203 Williams" },
            new OfficeAssignment { InstructorId = 5, Location = "213 Smith" },
            new OfficeAssignment { InstructorId = 31, Location = "17 Smith" },
            new OfficeAssignment { InstructorId = 32, Location = "37 Williams" },
            new OfficeAssignment { InstructorId = 33, Location = "143 Smith" },
            new OfficeAssignment { InstructorId = 34, Location = "57 Adams" }
        );
    }
}
