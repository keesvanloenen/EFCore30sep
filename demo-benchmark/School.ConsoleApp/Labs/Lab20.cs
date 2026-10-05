using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;

namespace School.Library.Labs;

public class Lab20
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("0. Add Department without an Administrator");
            Console.WriteLine("1. Show Departments with an Administrator");
            Console.WriteLine("2. Show All Departments (ignore the global query filter)");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();

            key = Console.ReadKey(true);
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '0':
                    AddDepartmentWithoutAnAdministrator(options);
                    break;
                case '1':
                    ShowDepartmentsWithAnAdministrator(options);
                    break;
                case '2':
                    ShowAllDepartments(options);
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

    private static void AddDepartmentWithoutAnAdministrator(DbContextOptions<SchoolContext> options)
    {
        var newDepartment = new Department
        {
            Name = "Kennis Centrum",
            Budget = 1_000_000m,
            StartDate = DateOnly.FromDateTime(DateTime.Now),
        };

        using var context = new SchoolContext(options);
        context.Add(newDepartment);
        context.SaveChanges();

        Console.WriteLine($"New Department created: {newDepartment.Name}");
    }

    private static void ShowDepartmentsWithAnAdministrator(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Show Departments With an Administrator");

        using var context = new SchoolContext(options);

        var departments = context.Departments
            .AsNoTracking();

        foreach (var department in departments)
        {
            Console.WriteLine($"Department: {department.Name}, DepartmentAdministrator: {department.AdministratorId}");
        }
    }

    private static void ShowAllDepartments(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("ShowAllDepartments");

        using var context = new SchoolContext(options);

        var departments = context.Departments
            .AsNoTracking()
            .IgnoreQueryFilters();

        foreach (var department in departments)
        {
            Console.WriteLine($"Department: {department.Name}, DepartmentAdministrator: {department.AdministratorId}");
        }
    }
}
