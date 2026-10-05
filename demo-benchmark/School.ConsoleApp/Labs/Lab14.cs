using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;

namespace School.Library.Labs;

public class Lab14
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Create Department");
            Console.WriteLine("2. Show Departments");
            Console.WriteLine("3. Show Department Administrators");
            Console.WriteLine("4. Delete Department Administrator (keep Departments)");
            Console.WriteLine("5. Delete Administrator with related Departments");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();

            key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    Lab13.AddDepartentWithRelatedAdministrator(options);
                    break;
                case '2':
                    Lab04.DisplayDepartments(options);
                    break;
                case '3':
                    Lab03.DisplayDepartmentAdministrators(options);
                    break;
                case '4':
                    DeleteDepartmentAdministratorKeepDepartments(options);
                    break;
                case '5':
                    DeleteAdministratorWithDepartments(options);
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

    private static void DeleteDepartmentAdministratorKeepDepartments(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Delete Administrator, but keep Departments");
        Console.Write("Enter administrator id: ");
        var administratorId = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);
        var administrator = context.DepartmentAdministrators
            .Include(a => a.Departments)
            .FirstOrDefault(a => a.Id == administratorId);

        if (administrator == null)
        {
            Console.WriteLine($"No administrator found with id {administratorId}");
            return;
        }
            
        context.DepartmentAdministrators.Remove(administrator!);
        context.SaveChanges();

        Console.WriteLine($"Department Administrator {administrator.FirstName} {administrator.LastName} deleted and {administrator.Departments.Count} related department(s) were kept");
    }

    private static void DeleteAdministratorWithDepartments(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Delete Administrator along with the Departments");
        Console.Write("Enter administrator id: ");
        var administratorId = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);
        var administrator = context.DepartmentAdministrators
            .Include(a => a.Departments)
            .FirstOrDefault(a => a.Id == administratorId);

        if (administrator == null)
        {
            Console.WriteLine($"No administrator found with id {administratorId}");
            return;
        }

        try
        {
            context.Departments.RemoveRange(administrator.Departments);
            context.DepartmentAdministrators.Remove(administrator);
            context.SaveChanges();
        } 
        catch (DbUpdateException e)
        {
            Console.WriteLine("Error deleting the Department Administrator. They may have courses associated with it.");
            Console.WriteLine(e?.InnerException?.Message);
            return;
        }

        Console.WriteLine($"Department Administrator {administrator.FirstName} {administrator.LastName} and {administrator.Departments.Count} related department(s) deleted");
    }
}
