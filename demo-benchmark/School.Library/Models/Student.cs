namespace School.Library.Models;

public class Student : Person
{
    public DateOnly EnrollmentDate { get; set; }

    public List<Enrollment> Enrollments { get; } = [];
    public List<Course> Courses { get; } = [];
}
