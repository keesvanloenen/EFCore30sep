using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;

namespace School.Library.Labs;

public class Lab13
{
    internal static void AddDepartentWithRelatedAdministrator(DbContextOptions<SchoolContext> options)
    {
        var newDepartment = AskUserForNewDepartmentInformation();

        using var context = new SchoolContext(options);

        Console.WriteLine("Do you want to assign a new or existing admin? (N/E): ");
        var input = Console.ReadLine()!;

        var departmentAdministrator = (input == "N" || input == "n")
                                      ? AskUserForNewDepartmentAdministratorInformation()
                                      : AskUserForExistingAdministrator(context);

        newDepartment.Administrator = departmentAdministrator;
        
        context.Add(newDepartment);
        context.SaveChanges();

        Console.WriteLine($"Department {newDepartment.Name} added with ID {newDepartment.Id}");
        Console.WriteLine($"Administered by {newDepartment.Administrator?.FirstName} {newDepartment.Administrator?.LastName} with ID {newDepartment.Administrator?.Id}, hired on {newDepartment.Administrator?.HireDate}");
    }

    private static DepartmentAdministrator AskUserForExistingAdministrator(SchoolContext context)
    {
        Console.WriteLine("Add an existing Department Administrator");

        var departmentAdministrators = context.DepartmentAdministrators;

        foreach (var admin in departmentAdministrators)
        {
            Console.WriteLine($"{admin.Id} - {admin.FirstName} {admin.LastName}, HireDate: {admin.HireDate}");
        }
        Console.Write("Enter administrator id: ");

        while(true)
        {
            var id = int.Parse(Console.ReadLine()!);
            var departmentAdministrator = context.DepartmentAdministrators.Find(id);
            if (departmentAdministrator != null)
            {
                return departmentAdministrator;
            }
            Console.Write("Invalid administrator id. Try again: ");
        }
    }

    private static Department AskUserForNewDepartmentInformation()
    {
        Console.WriteLine("Add a new Department");

        Console.Write("Name: ");
        var name = Console.ReadLine()!;
        
        Console.Write("Budget: ");
        var budget = decimal.Parse(Console.ReadLine()!);

        return new Department { Name = name, Budget = budget, StartDate = DateOnly.FromDateTime(DateTime.Now) };
    }

    private static DepartmentAdministrator AskUserForNewDepartmentAdministratorInformation()
    {
        Console.WriteLine("Add a new Department Administrator");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;
        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;
        Console.Write("Hire Date (dd/mm/yyyy): ");
        var hireDate = DateOnly.ParseExact(Console.ReadLine()!, "dd/MM/yyyy");
        
        return new DepartmentAdministrator() { FirstName = firstName, LastName = lastName, HireDate = hireDate };
    }
}
