using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab04
{
    public static void DisplayDepartments(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Departments:");

        using var context = new SchoolContext(options);
        var departments = context.Departments;

        foreach (var department in departments)
        {
            Console.WriteLine($"Id = {department.Id}, Name = {department.Name}, Budget = {department.Budget}, Startdate = {department.StartDate}, AdministratorId = {department.AdministratorId}");
        }
    }
}
