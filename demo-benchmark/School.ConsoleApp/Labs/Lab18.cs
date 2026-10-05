using Microsoft.EntityFrameworkCore;
using School.Library.DAL;

namespace School.Library.Labs;

public class Lab18
{
    internal static void ShowCourseGradeStandardDeviations(DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);

        var courseGradeStandardDeviations = context.Enrollments
            .Where(e => e.Grade.HasValue)
            .GroupBy(e => e.CourseId)
            .Select(g => new 
            { 
                CourseId = g.Key, 
                StandardDeviationPopulation = EF.Functions.StandardDeviationPopulation(g.Select(e => e.Grade!.Value))
            })
            .ToList();

        Console.WriteLine("Show Course Grade Standard Deviations:");

        foreach(var item in courseGradeStandardDeviations)
        {
            Console.WriteLine($"CourseId: {item.CourseId} => {item.StandardDeviationPopulation:N4}");
            
        }
    }
}
