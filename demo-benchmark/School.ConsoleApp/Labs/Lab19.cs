using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab19
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Show Departments Whose EnrollmentCount Is Greater Than Given Number - Scalar Function");
            Console.WriteLine("2. Show Departments Whose EnrollmentCount Is Greater Than Given Number - Table Valued Function");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();

            key = Console.ReadKey(true);
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    ShowDepartmentsWhoseEnrollmentCountIsGreaterThanGivenNumberWithScalarFunction(options);
                    break;
                case '2':
                    ShowDepartmentsWhoseEnrollmentCountIsGreaterThanGivenNumberWithTableValuedFunction(options);
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

    private static void ShowDepartmentsWhoseEnrollmentCountIsGreaterThanGivenNumberWithScalarFunction(DbContextOptions<SchoolContext> options)
    {
        Console.Write("Enter number of Enrollments: ");
        var numberOfEnrollments = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);

        var departments = context.Departments
            .Where(d => context.GetEnrollmentsCountByDepartmentId(d.Id) > numberOfEnrollments)
            .ToList();

        Console.WriteLine($"Show Enrollments With More Than {numberOfEnrollments} Enrollments:");

        foreach(var department in departments)
        {
            Console.WriteLine($"{department.Id} {department.Name}");
        }
    }

    private static void ShowDepartmentsWhoseEnrollmentCountIsGreaterThanGivenNumberWithTableValuedFunction(DbContextOptions<SchoolContext> options)
    {
        Console.Write("Enter number of Enrollments: ");
        var numberOfEnrollments = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);

        var departments = context.GetDepartmentsWithMoreThanGivenNumberOfEnrollments(numberOfEnrollments)
            .ToList();

        Console.WriteLine($"Show Enrollments With More Than {numberOfEnrollments} Enrollments:");

        foreach (var department in departments)
        {
            Console.WriteLine($"{department.Id} {department.Name}");
        }
    }
}
