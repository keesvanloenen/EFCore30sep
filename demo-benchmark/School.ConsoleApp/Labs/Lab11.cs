using Microsoft.EntityFrameworkCore;
using School.Library.DAL;
using School.Library.Models;

namespace School.Library.Labs;

public class Lab11
{
    public static void Pagination(DbContextOptions<SchoolContext> options)
    {
        int pageSize = 5;
        int firstPersonId = 0;
        int lastPersonId = 0;

        var people = Next(lastPersonId, pageSize, options);
        
        ConsoleKeyInfo key;
        while (true)
        {
            firstPersonId = people.FirstOrDefault()?.Id ?? 0;
            lastPersonId = people.LastOrDefault()?.Id ?? 0;

            Console.Clear();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Id} - {person.FirstName} {person.LastName}");
            }
            Console.WriteLine("(P)revious  (N)ext  (Q)uit");

            key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case 'n' or 'N':
                    people = Next(lastPersonId, pageSize, options);
                    break;
                case 'p' or 'P':
                    people = Previous(firstPersonId, pageSize, options);
                    break;
                case 'q' or 'q':
                    return;
                default:
                    break;
            }
        }
    }

    public static List<Person> Previous(int firstPersonId, int pageSize, DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);
        return context.People
            .Where(p => p.Id < firstPersonId)
            .OrderByDescending(p => p.Id)
            .Take(pageSize)
            .OrderBy(p => p.Id)
            .ToList();
    }

    public static List<Person> Next(int lastPersonId, int pageSize, DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);
        return context.People
            .Where(p => p.Id > lastPersonId)
            .Take(pageSize)
            .ToList();
    }
}
