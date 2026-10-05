using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab16
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Show Departments");
            Console.WriteLine("2. Show Courses");
            Console.WriteLine("3. Increase Credits of Courses in Selected Department");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();

            key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    Lab04.DisplayDepartments(options);
                    break;
                case '2':
                    DisplayCourses(options);
                    break;
                case '3':
                    IncreaseCreditsOfCoursesInSelectedDepartment(options);
                    break;
                case 'Q' or 'q':
                    Console.WriteLine("Bye!");
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    private static void DisplayCourses(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Courses:");

        using var context = new SchoolContext(options);
        var courses = context.Courses;

        foreach (var course in courses)
        {
            Console.WriteLine($"Id = {course.Id}, Title = {course.Title}, Credits = {course.Credits}, DepartmentId = {course.DepartmentId}");
        }
    }

    private static void IncreaseCreditsOfCoursesInSelectedDepartment(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Increase credits of Courses by 1");
        Console.Write("Provide Department Id: ");
        var departmentId = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);

        var numberOfUpdatedCourses = context.Courses
            .Where(c => c.DepartmentId == departmentId)
            .ExecuteUpdate(setters => setters.SetProperty(c => c.Credits, c => c.Credits + 1));

        if (numberOfUpdatedCourses == 0)
        {
            Console.WriteLine($"No Courses found for department with id {departmentId}");
            return;
        }

        Console.WriteLine($"Credits increased for {numberOfUpdatedCourses} courses for department {departmentId}");
    }
}
