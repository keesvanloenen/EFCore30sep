using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class OnsiteCourseConfiguration : IEntityTypeConfiguration<OnsiteCourse>
{
    public void Configure(EntityTypeBuilder<OnsiteCourse> builder)
    {
        builder.HasData(
            new OnsiteCourse { Id = 1045, Location = "121 Smith", Time = TimeOnly.Parse("15:30:00"), Title = "Calculus", Credits = 4, DepartmentId = 4 },
            new OnsiteCourse { Id = 1050, Location = "123 Smith", Time = TimeOnly.Parse("11:30:00"), Title = "Chemistry", Credits = 4, DepartmentId = 1 },
            new OnsiteCourse { Id = 1061, Location = "234 Smith", Time = TimeOnly.Parse("13:15:00"), Title = "Physics", Credits = 4, DepartmentId = 1 },
            new OnsiteCourse { Id = 2042, Location = "225 Adams", Time = TimeOnly.Parse("11:00:00"), Title = "Literature", Credits = 4, DepartmentId = 2 },
            new OnsiteCourse { Id = 4022, Location = "23 Williams", Time = TimeOnly.Parse("09:00:00"), Title = "Microeconomics", Credits = 3, DepartmentId = 3 },
            new OnsiteCourse { Id = 4061, Location = "22 Williams", Time = TimeOnly.Parse("11:15:00"), Title = "Quantitative", Credits = 2, DepartmentId = 3 }
        );
    }
}
