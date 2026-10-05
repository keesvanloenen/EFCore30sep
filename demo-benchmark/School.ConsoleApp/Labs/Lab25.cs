using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using School.Library.DAL;
using School.Library.Models;

namespace School.Library.Labs;

public class Lab25
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Show Students");
            Console.WriteLine("2. Tracking From Queries");
            Console.WriteLine("3. Show Online Courses");
            Console.WriteLine("4. Show Departments");
            Console.WriteLine("5. Explicitly Tracking: Insert - explicit keys");
            Console.WriteLine("6. Show Department Administrators");
            Console.WriteLine("7. Explicitly Tracking: Insert - generated keys");
            Console.WriteLine("8. Accessing Tracked Entities");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();

            key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    Lab03.DisplayStudents(options);
                    break;
                case '2':
                    TrackingFromQueries(options);
                    break;
                case '3':
                    Lab03.DisplayOnlineCourses(options);
                    break;
                case '4':
                    Lab04.DisplayDepartments(options);
                    break;
                case '5':
                    ExplicitlyTrackingInsertWithExplicitKeys(options);
                    break;
                case '6':
                    Lab03.DisplayDepartmentAdministrators(options);
                    break;
                case '7':
                    ExplicitlyTrackingInsertWithGeneratedKeys(options);
                    break;
                case '8':
                    AccessingTrackedEntities(options);
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

    private static void TrackingFromQueries(DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);

        Console.Write("Enter the Id of the student you want to load: ");
         var studentId = int.Parse(Console.ReadLine()!);

        var student = context.Students.Find(studentId);
        if (student is null)
        {
            Console.WriteLine("Student not found");
            return;
        }

        // Display the DebugView of the ChangeTracker
        DisplayChangeTrackerDebugView(context);

        Console.Write("Enter the new last name: ");
        var newLastName = Console.ReadLine()!;
                student.LastName = newLastName;

        Console.WriteLine("***** After modifying the student, before SaveChanges *****");
        DisplayChangeTrackerDebugView(context);

        context.SaveChanges();

        Console.WriteLine("***** After modifying the student, after SaveChanges *****");
        DisplayChangeTrackerDebugView(context);
    }

    private static void ExplicitlyTrackingInsertWithExplicitKeys(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Create Online Course");
        Console.Write("Enter Id: ");
        var id = int.Parse(Console.ReadLine()!);
        Console.Write("Enter Title: ");
        var title = Console.ReadLine()!;
        Console.Write("Enter Url: ");
        var url = Console.ReadLine()!;
        Console.Write("Enter DepartmentId: ");
        var departmentId = int.Parse(Console.ReadLine()!);

        var onlineCourse = new OnlineCourse { Id = id, Title = title, Url = url, DepartmentId = departmentId };

        using var context = new SchoolContext(options);

        context.Add(onlineCourse);
        Console.WriteLine("***** After adding the online course, before SaveChanges *****");
        DisplayChangeTrackerDebugView(context);
        context.SaveChanges();
        Console.WriteLine("***** After adding the online course, after SaveChanges *****");
        DisplayChangeTrackerDebugView(context);
    }

    private static void ExplicitlyTrackingInsertWithGeneratedKeys(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Create Department Administrator");
        Console.Write("Enter First Name: ");
        var firstName = Console.ReadLine()!;
        Console.Write("Enter Last Name: ");
        var lastName = Console.ReadLine()!;
        var hireDate = DateOnly.FromDateTime(DateTime.Now);

        var departmentAdministrator = new DepartmentAdministrator { FirstName = firstName, LastName = lastName, HireDate = hireDate };

        using var context = new SchoolContext(options);

        context.Add(departmentAdministrator);

        Console.WriteLine("***** After adding the department administrator, before SaveChanges *****");
        DisplayChangeTrackerDebugView(context);

        context.SaveChanges();
        
        Console.WriteLine("***** After adding the department administrator, after SaveChanges *****");
        DisplayChangeTrackerDebugView(context);

    }

    private static void AccessingTrackedEntities(DbContextOptions<SchoolContext> options)
    {
        // Ask user for student id
        Console.Write("Enter Student Id: ");
        var studentId = int.Parse(Console.ReadLine()!);

        using var context = new SchoolContext(options);
        
        // Find student
        var student = context.Students.Find(studentId);
        if (student is null)
        {
            Console.WriteLine("Student not found");
            return;
        }

        // Display
        Console.WriteLine("***** Before modifying the student *****");
        Console.WriteLine("State: " + context.Entry(student).State);
        DisplayPropertyEntries(context.Entry(student).Properties);

        // Update last name
        Console.Write("Enter new Last Name:  ");
        string newLastName = Console.ReadLine()!;
        student.LastName = newLastName;

        // Display
        Console.WriteLine("***** After modifying the student, before SaveChanges *****");
        Console.WriteLine("State: " + context.Entry(student).State);
        DisplayPropertyEntries(context.Entry(student).Properties);

        context.SaveChanges();

        // Display
        Console.WriteLine("***** After modifying the student, after SaveChanges *****");
        Console.WriteLine("State: " + context.Entry(student).State);
        DisplayPropertyEntries(context.Entry(student).Properties);

        // Reload the modified record
        context.Entry(student).Reload();
        Console.WriteLine($"***** After reload *****");
        Console.WriteLine("State: " + context.Entry(student).State);
        DisplayPropertyEntries(context.Entry(student).Properties);
    }

    private static void DisplayChangeTrackerDebugView(SchoolContext context, bool detectChanges = true)
    {
        var defaultColor = Console.ForegroundColor;

        if (detectChanges)
        {
            context.ChangeTracker.DetectChanges();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(context.ChangeTracker.DebugView.LongView);
        Console.ForegroundColor = defaultColor;
    }

    private static void DisplayPropertyEntries(IEnumerable<PropertyEntry> propertyEntries)
    {
        var defaultColor = Console.ForegroundColor;
        foreach (PropertyEntry property in propertyEntries)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{property.Metadata.Name}: CurrentValue={property.CurrentValue}, OriginalValue={property.OriginalValue}");
            Console.ForegroundColor = defaultColor;
        }
    }


    
}
