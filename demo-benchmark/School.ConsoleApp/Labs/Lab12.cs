using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;

namespace School.Library.Labs
{
    internal class Lab12
    {
        internal static void AddNewDepartment(DbContextOptions<SchoolContext> options)
        {
            Console.WriteLine("Add a new Department");
            
            Console.Write("Name: ");
            var name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine($"Not a valid name: {name}");
                return;
            }
            
            Console.Write("Budget: ");
            var input = Console.ReadLine();
            if (!decimal.TryParse(input, out var budget))
            {
                Console.WriteLine($"Not a valid budget: {input}");
                return;
            }
            
            var department = new Department { Name = name, Budget = budget, StartDate = DateOnly.FromDateTime(DateTime.Now) };
            using var context = new SchoolContext(options);

            context.Add(department);
            context.SaveChanges();

            Console.WriteLine($"Department {department.Name} added with ID {department.Id}");
        }

        internal static void UpdateBudgetLastAddedDepartment(DbContextOptions<SchoolContext> options)
        {
            using var context = new SchoolContext(options);

            var department = context.Departments.OrderBy(d => d.Id).LastOrDefault();

            if (department == null)
            {
                Console.WriteLine("No departments found");
                return;
            }

            Console.Write("New budget for department: ");
            var input = Console.ReadLine();
            if (!decimal.TryParse(input, out var budget))
            {
                Console.WriteLine($"Not a valid budget: {input}");
                return;
            }

            department.Budget = budget;
            context.SaveChanges();

            Console.WriteLine($"Department {department.Name} has new budget: {department.Budget}");
        }

        internal static void DeleteLastAddedDepartment(DbContextOptions<SchoolContext> options)
        {
            using var context = new SchoolContext(options);

            var department = context.Departments.OrderBy(d => d.Id).LastOrDefault();

            if (department == null)
            {
                Console.WriteLine("No departments found");
                return;
            }

            context.Remove(department);
            context.SaveChanges();

            Console.WriteLine($"Department {department.Name} has been deleted");
        }

    }
}
