using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Library.Models;

namespace School.Library.DAL.EntityConfigurations;

public class OnlineCourseConfiguration : IEntityTypeConfiguration<OnlineCourse>
{
    public void Configure(EntityTypeBuilder<OnlineCourse> builder)
    {
        builder.HasData(
            new OnlineCourse
            {
                Id = 4041,
                Title = "Macroeconomics",
                Credits = 3,
                Url = "http://www.fineartschool.net/Macroeconomics",
                DepartmentId = 3
            },
            new OnlineCourse
            {
                Id = 3141,
                Title = "Trigonometry",
                Credits = 4,
                Url = "http://www.fineartschool.net/Trigonometry",
                DepartmentId = 4
            },
            new OnlineCourse
            {
                Id = 2021,
                Title = "Composition",
                Credits = 3,
                Url = "http://www.fineartschool.net/Composition",
                DepartmentId = 2
            },
            new OnlineCourse { Id = 2030,
                Title = "Poetry",
                Credits = 2,
                Url = "http://www.fineartschool.net/Poetry",
                DepartmentId = 2
            }
        );
    }
}
