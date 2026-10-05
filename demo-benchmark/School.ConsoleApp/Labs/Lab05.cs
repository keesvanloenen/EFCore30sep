using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab05
{
    public static void DisplayOfficeAssignments(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Office Assignements:");

        using var context = new SchoolContext(options);

        var officeAssignments = context.OfficeAssignments;

        foreach (var assignment in officeAssignments)
        {
            Console.WriteLine($"Id = {assignment.InstructorId}, Location = {assignment.Location}");
        }
    }
}
