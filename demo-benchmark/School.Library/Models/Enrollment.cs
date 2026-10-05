namespace School.Library.Models;

public class Enrollment
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public Course Course { get; set; } = null!;
    public Student Student { get; set; } = null!;

    public decimal? Grade { get; set; }
}
