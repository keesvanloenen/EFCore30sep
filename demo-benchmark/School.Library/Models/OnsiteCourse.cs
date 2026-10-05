namespace School.Library.Models;

public class OnsiteCourse : Course
{
    public string Location { get; set; } = null!;
    public TimeOnly Time { get; set; }
}
