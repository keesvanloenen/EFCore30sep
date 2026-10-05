using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab09
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Show All Instructors");
            Console.WriteLine("2. View Instructor Details");
            Console.WriteLine("Q. Quit");

            key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '1':
                    Lab03.DisplayInstructors(options);
                    break;
                case '2':
                    ViewInstructorDetails(options);
                    break;
                case 'Q' or 'q':
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    private static int GetInstructorId()
    {
        while (true)
        {
            Console.Write("Enter instructor id: ");
            string? input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int id) && id > 0)
            {
                return id;
            }
            Console.WriteLine("Invalid instructor id. Please enter a positive integer.");
        }
    }

    private static void ViewInstructorDetails(DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);

        int id = GetInstructorId();
        var instructor = context.Instructors.Find(id);

        if (instructor == null)
        {
            Console.WriteLine($"No instructor found with id {id}.");
            return;
        }

        // Explicit load OfficeAssignment and Courses
        context.Entry(instructor).Reference(i => i.OfficeAssignment).Load();
        context.Entry(instructor).Collection(i => i.Courses).Load();

        Console.WriteLine($"Instructor {instructor.FirstName} {instructor.LastName}, Location: {instructor.OfficeAssignment.Location}");
        Console.WriteLine("Teaching:");

        if (instructor.Courses.Count == 0)
        {
            Console.WriteLine("\t- No courses assigned");
            return;
        }

        foreach (var course in instructor.Courses)
        {
            Console.WriteLine($"\t- {course.Title}");
        }
    }
}
