using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using School.Library.DAL;
using School.Library.Labs;

namespace School.Library;

internal class Program
{
    static void Main(string[] args)
    {
        var options = BuildContextOptions();

        //RebuildDatabase(options);
        //SchoolInitializer.Seed(options);

        //Lab01.DisplayPeople(options);

        //Lab02.DisplayCourses(options);
        //Lab02.DisplayDepartments(options);

        //Lab03.DisplayStudents(options);
        //Lab03.DisplayInstructors(options);
        //Lab03.DisplayDepartmentAdministrators(options);
        //Lab03.DisplayOnlineCourses(options);
        //Lab03.DisplayOnsiteCourses(options);

        //Lab04.DisplayDepartments(options);

        //Lab05.DisplayOfficeAssignments(options);

        //Lab06.DisplayEnrollments(options);

        //Lab07.ShowNamesAndSurnamesOfEachStudentOrderedByEnrollmentDate(options);
        //Lab07.ShowFirstInstructorHired(options);
        //Lab07.ShowAverageGradeOfEachStudentId(options);
        //Lab07.ShowLowestGradeOfEachCourseId(options);

        //Lab08.DisplayDepartmentDetails(options);
        //Lab08.DisplayInstructorDetails(options);
        //Lab08.DisplayAverageGradePerStudent(options);
        //Lab08.DisplayLowestGradePerCourse(options);

        //Lab09.Menu(options);

        //Lab10.Menu(options);

        //Lab11.Pagination(options);

        //Lab12.AddNewDepartment(options);
        //Lab12.UpdateBudgetLastAddedDepartment(options);
        //Lab12.DeleteLastAddedDepartment(options);

        // Lab13.AddDepartentWithRelatedAdministrator(options);

        // Lab14.Menu(options);

        // Lab15.Menu(options);

        // Lab16.Menu(options);

        // Lab17.Menu(options);

        // Lab18.ShowCourseGradeStandardDeviations(options);

        // Lab19.Menu(options);

        Lab20.Menu(options);

        // Lab25.Menu(options);
    }
    
    static DbContextOptions<SchoolContext> BuildContextOptions()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var configuration = builder.Build();

        return new DbContextOptionsBuilder<SchoolContext>()
            .LogTo(Console.WriteLine, [DbLoggerCategory.ChangeTracking.Name], LogLevel.Debug)
            .EnableSensitiveDataLogging()
            .UseSqlServer(configuration.GetConnectionString("DefaultConn"))
            .Options;
    }

    static void RebuildDatabase(DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
}
