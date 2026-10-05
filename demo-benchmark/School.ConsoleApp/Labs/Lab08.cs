using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab08
{
    public static void DisplayDepartmentDetails(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Department Details:");

        using var context = new SchoolContext(options);

        var departments = context.Departments
            .AsNoTracking()
            .Include(d => d.Administrator)
            .ThenInclude(a => a!.Courses);

        foreach (var d in departments)
        {
            Console.WriteLine($"Department name: {d.Name}, Budget: {d.Budget:N2}, Administrator: {d.Administrator?.FirstName} {d.Administrator?.LastName}");

            foreach (var c in d.Administrator?.Courses ?? [])
            {
                Console.WriteLine($"\t- {c.Title}");
            }
        }
    }

    public static void DisplayInstructorDetails(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Instructor Details:");

        using var context = new SchoolContext(options);

        var instructors = context.Instructors
            .AsNoTracking()
            .Include(i => i.OfficeAssignment)
            .Include(i => i.Courses)
            .ThenInclude(c => c.Enrollments)
            .ThenInclude(e => e.Student);

        foreach (var i in instructors)
        {
            Console.WriteLine($"Instructor: {i.FirstName}, Location: {i.OfficeAssignment.Location}");

            foreach (var c in i.Courses)
            {
                Console.WriteLine($"\t- Course: {c.Title}");

                foreach (var e in c.Enrollments)
                {
                    Console.WriteLine($"\t\t- Student: {e.Student.FirstName} {e.Student.LastName}, Grade: {e.Grade}");
                }
            }
        }
    }

    public static void DisplayAverageGradePerStudent(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Average Grade Per Student:");

        using var context = new SchoolContext(options);

        var students = context.Students
            .AsNoTracking()
            .Include(s => s.Enrollments)
            .Select(s => new
            {
                Student = $"{s.FirstName} {s.LastName}",
                AverageGrade = s.Enrollments.Where(e => e.Grade != null).Average(e => e.Grade)
            })
            .Where(r => r.AverageGrade != null);

        foreach (var s in students)
        {
            Console.WriteLine($"{s.Student}: {s.AverageGrade:N2}");
        }
    }

    public static void DisplayLowestGradePerCourse(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Lowest Grade Per Course:");

        using var context = new SchoolContext(options);

        var courses = context.Courses
            .AsNoTracking()
            .Include(c => c.Enrollments)
            .Select(c => new
            {
                Course = c.Title,
                LowestGrade = c.Enrollments.Where(e => e.Grade != null).Min(e => e.Grade)
            })
            .Where(r => r.LowestGrade != null);

        foreach (var c in courses)
        {
            Console.WriteLine($"{c.Course}: {c.LowestGrade:N2}");
        }
    }
}
