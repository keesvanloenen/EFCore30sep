using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab06
{
    public static void DisplayEnrollments(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Enrollments:");

        using var context = new SchoolContext(options);

        var enrollments = context.Enrollments;

        foreach (var enrollment in enrollments)
        {
            Console.WriteLine($"StudentId = {enrollment.StudentId}, CourseId = {enrollment.CourseId}");
        }
    }
}
