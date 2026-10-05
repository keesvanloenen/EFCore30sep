using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab03
{
    public static void DisplayStudents(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Students:");

        using var context = new SchoolContext(options);
        var students = context.Students;

        foreach (var student in students)
        {
            Console.WriteLine($"{student.Id} - {student.FirstName} {student.LastName}, EnrollmentDate: {student.EnrollmentDate}");
        }
    }

    public static void DisplayInstructors(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Instructors:");

        using var context = new SchoolContext(options);
        var instructors = context.Instructors;

        foreach (var instructor in instructors)
        {
            Console.WriteLine($"{instructor.Id} - {instructor.FirstName} {instructor.LastName}, HireDate: {instructor.HireDate}");
        }
    }

    public static void DisplayDepartmentAdministrators(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Department Administrators:");

        using var context = new SchoolContext(options);

        var departmentAdministrators = context.DepartmentAdministrators;

        foreach (var admin in departmentAdministrators)
        {
            Console.WriteLine($"{admin.Id} - {admin.FirstName} {admin.LastName}, HireDate: {admin.HireDate}");
        }
    }

    public static void DisplayOnlineCourses(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Online Courses:");

        using var context = new SchoolContext(options);

        var onlineCourses = context.OnlineCourses;

        foreach (var course in onlineCourses)
        {
            Console.WriteLine($"Id = {course.Id}, Title = {course.Title}, Credits = {course.Credits}, Url = {course.Url}");
        }
    }

    public static void DisplayOnsiteCourses(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Onsite Courses:");

        using var context = new SchoolContext(options);

        var onsiteCourses = context.OnSiteCourses;

        foreach (var course in onsiteCourses)
        {
            Console.WriteLine($"Id = {course.Id}, Title = {course.Title}, Credits = {course.Credits}, Location = {course.Location}, Time = {course.Time}");
        }
    }
}
