using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        builder.Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Credits)
            .IsRequired();

        builder.UseTptMappingStrategy();

        builder
            .HasOne(c => c.Department)
            .WithMany(d => d.Courses)
            .HasForeignKey("DepartmentId")
            .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasMany(c => c.Instructors)
           .WithMany(i => i.Courses)
           .UsingEntity(
             "CoursesInstructors",
             l => l.HasOne(typeof(Instructor)).WithMany().HasForeignKey("InstructorId"),
             r => r.HasOne(typeof(Course)).WithMany().HasForeignKey("CourseId")
           );
    }
}
