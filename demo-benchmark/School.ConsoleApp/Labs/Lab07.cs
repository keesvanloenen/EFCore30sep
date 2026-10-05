using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab07
{
    public static void ShowNamesAndSurnamesOfEachStudentOrderedByEnrollmentDate(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Names Of All Students Ordered By EnrollmentDate:");

        using var context = new SchoolContext(options);

        var students = context.Students
            .AsNoTracking()
            .OrderBy(s => s.EnrollmentDate);

        Console.WriteLine($"{"Student",-22} EnrollmentDate");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName + " " + student.LastName,-22} {student.EnrollmentDate}");
        }
    }

    public static void ShowFirstInstructorHired(DbContextOptions<SchoolContext> options)
    {
        Console.Write("First Instructor Hired: ");

        using var context = new SchoolContext(options);

        var instructor = context.Instructors
            .AsNoTracking()
            .OrderBy(i => i.HireDate)
            .First();

        Console.WriteLine($"{instructor.FirstName} {instructor.LastName} ({instructor.HireDate})");
    }

    public static void ShowAverageGradeOfEachStudentId(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Average Grade Of Each StudentId:");

        using var context = new SchoolContext(options);

        var grades = context.Enrollments
            .AsNoTracking()
            .Where(e => e.Grade != null)
            .GroupBy(e => e.StudentId)
            .Select(g => new { StudentId = g.Key, AverageGrade = g.Average(e => e.Grade!.Value) });

        foreach (var grade in grades)
        {
            Console.WriteLine($"{grade.StudentId}: {grade.AverageGrade:N2}");
        }
    }

    public static void ShowLowestGradeOfEachCourseId(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Lowest Grade For Each CourseId:");

        using var context = new SchoolContext(options);

        var grades = context.Enrollments
            .AsNoTracking()
            .Where(e => e.Grade != null)
            .GroupBy(e => e.CourseId)
            .Select(g => new { CourseId = g.Key, LowestGrade = g.Min(e => e.Grade!.Value) });

        foreach (var grade in grades)
        {
            Console.WriteLine($"{grade.CourseId}: grade:{grade.LowestGrade}");
        }
    }
}
