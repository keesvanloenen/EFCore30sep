using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;

namespace School.Library.Labs;

public class Lab15
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Show Departments");
            Console.WriteLine("2. Show Office Assignments");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Update Office Assignment");
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
                    Lab05.DisplayOfficeAssignments(options);
                    break;
                case '3':
                    UpdateDepartment(options);
                    break;
                case '4':
                    UpdateOfficeAssignment(options);
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

    private static void UpdateDepartment(DbContextOptions<SchoolContext> options)
    {
        Console.Write("Enter the Id of the Department you want to update: ");
        var departmentId = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);

        var department = context.Departments.Find(departmentId);

        if (department == null)
        {
            Console.WriteLine("Invalid Department Id");
            return;
        }

        Console.WriteLine($"Id = {department.Id}, Name = {department.Name}, Budget = {department.Budget}, Startdate = {department.StartDate}, AdministratorId = {department.AdministratorId}");

        Console.Write("Enter the new name: ");
        var newName = Console.ReadLine()!;

        Console.Write("Enter the new budget: ");
        var newBudget = decimal.Parse(Console.ReadLine()!);

        Console.Write("Enter the new start date: ");
        var newStartDate = DateOnly.Parse(Console.ReadLine()!);

        // Simulate a change in the database by another user
        context.Database.ExecuteSql($"Update Departments SET Name = 'Something different' WHERE Id = {departmentId}");

        department.Name = newName;
        department.Budget = newBudget;
        department.StartDate = newStartDate;

        try
        {
            context.SaveChanges();
            Console.WriteLine($"Department updated:");
            Console.WriteLine($"Id = {department.Id}, Name = {department.Name}, Budget = {department.Budget}, Startdate = {department.StartDate}, AdministratorId = {department.AdministratorId}");

        }
        catch (DbUpdateConcurrencyException ex)
        {
            foreach(var entry in ex.Entries)
            {
                if (entry.Entity is Department)
                {
                    var databaseValues = entry.GetDatabaseValues();
                    entry.CurrentValues.SetValues(databaseValues!);
                }
            }
            Console.WriteLine("The record has been modified by another user. Please try again!");
        }
    }


    private static void UpdateOfficeAssignment(DbContextOptions<SchoolContext> options)
    {
        Console.Write("Enter the Id of the Instructor you want to update: ");
        var instructorId = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);

        var officeAssignment = context.OfficeAssignments.Find(instructorId);

        if (officeAssignment == null)
        {
            Console.WriteLine("Invalid Instructor Id");
            return;
        }

        Console.WriteLine($"Id = {officeAssignment.InstructorId}, Location = {officeAssignment.Location}, TimeStamp = {BitConverter.ToString(officeAssignment.Timestamp)}");

        Console.Write("Enter the new location: ");
        var newLocation = Console.ReadLine()!;

        // Simulate a change in the database by another user
        context.Database.ExecuteSql($"Update OfficeAssignments SET Location = 'Something different' WHERE Id = {instructorId}");

        officeAssignment.Location = newLocation;

        try
        {
            context.SaveChanges();
            Console.WriteLine($"Id = {officeAssignment.InstructorId}, Location = {officeAssignment.Location}, TimeStamp = {BitConverter.ToString(officeAssignment.Timestamp)}");
        }
        catch (DbUpdateConcurrencyException ex)
        {
            foreach (var entry in ex.Entries)
            {
                if (entry.Entity is OfficeAssignment)
                {
                    var databaseValues = entry.GetDatabaseValues();

                    entry.OriginalValues.SetValues(databaseValues!);
                    context.SaveChanges();
                }
            }
        }
    }
}
