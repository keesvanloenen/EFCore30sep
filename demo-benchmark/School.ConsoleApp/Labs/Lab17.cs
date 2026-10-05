using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;
using School.Library.ViewModels;
using System;

namespace School.Library.Labs;

public class Lab17
{
    public static void Menu(DbContextOptions<SchoolContext> options)
    {
        ConsoleKeyInfo key;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Show Best 5 Students");
            Console.WriteLine("2. Show Departments With Most Enrollments");
            Console.WriteLine("3. Show Instructors With Office");
            Console.WriteLine("Q. Quit");
            Console.WriteLine();

            key = Console.ReadKey();
            Console.WriteLine();
            switch (key.KeyChar)
            {
                case '1':
                    ShowBest5Students(options);
                    break;
                case '2':
                    ShowDepartmentsWithMostEnrollments(options);
                    break;
                case '3':
                    ShowInstructorsWithOffice(options);
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

    private static void ShowBest5Students(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("Best 5 Students:");

        using var context = new SchoolContext(options);

        var students = context.Students
            .FromSql($"""
                      SELECT TOP 5 p.Id, p.FirstName, p.LastName, p.Discriminator, p.HireDate, p.EnrollmentDate
                      FROM People p
                      INNER JOIN Enrollments e ON p.Id = e.StudentId
                      WHERE p.Discriminator = 'Student'
                      GROUP BY p.Id, p.FirstName, p.LastName, p.Discriminator, p.HireDate, p.EnrollmentDate
                      HAVING AVG(e.Grade) IS NOT NULL
                      ORDER BY AVG(e.Grade) DESC
                      """)
            .ToList();

        foreach(var student in students)
        {
            Console.WriteLine($"Student: ({student.Id}) {student.FirstName} {student.LastName}");
        }
    }

    private static void ShowDepartmentsWithMostEnrollments(DbContextOptions<SchoolContext> options)
    {
        var numberOfEnrollments = 5;

        using var context = new SchoolContext(options);

        var departments = context.Departments
            .FromSql($"EXECUTE dbo.GetDepartmentsWithMostEnrollments @NumberOfEnrollments={numberOfEnrollments}")
            .ToList();

        Console.WriteLine($"Show Departments with more than {numberOfEnrollments} enrollments");

        foreach (var department in departments)
        {
            Console.WriteLine($"Department: {department.Id} - {department.Name}, budget: {department.Budget}");
        }
    }

    private static void ShowInstructorsWithOffice(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine($"Show Instructors with Office");

        using var context = new SchoolContext(options);

        List<InstructorWithOffice> instructors = context.Database
            .SqlQuery<InstructorWithOffice>(
            @$"SELECT LastName, FirstName, HireDate, Location
               FROM People AS p
               INNER JOIN OfficeAssignments as o
               ON p.Id = o.InstructorId"
            )
            .ToList();

        foreach (var instructor in instructors)
        {
            Console.WriteLine($"Instructor Name: {instructor.FirstName} {instructor.LastName}, HireDate: {instructor.HireDate}, Office Location: {instructor.Location}");
        }
    }
}
