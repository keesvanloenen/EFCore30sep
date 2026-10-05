using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab01
{
    public static void DisplayPeople(DbContextOptions<SchoolContext> options)
    {
        Console.WriteLine("People:");

        using var context = new SchoolContext(options);
        var people = context.People;

        foreach (var person in people)
        {
            Console.WriteLine($"{person.Id} - {person.FirstName} {person.LastName}");
        }
    }
}
