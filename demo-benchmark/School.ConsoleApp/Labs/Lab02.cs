using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab02
{
    public static void DisplayCourses(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Courses:");

        using var context = new SchoolContext(options);
        var courses = context.Courses;

        foreach (var course in courses)
        {
            Console.WriteLine($"Id = {course.Id}, Title = {course.Title}, Credits = {course.Credits}");
        }
    }

    public static void DisplayDepartments(DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);

        var departments = context.Departments;

        Console.WriteLine("Departments:");
        foreach (var department in departments)
        {
            Console.WriteLine($"Id = {department.Id}, Name = {department.Name}, Budget = {department.Budget}, Startdate = {department.StartDate}");
        }
    }
}
