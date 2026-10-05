namespace School.Library.Models;

public class OfficeAssignment
{
    public int InstructorId { get; set; }
    public string Location { get; set; } = null!;
    public byte[] Timestamp { get; set; } = null!;

    public Instructor Instructor { get; set; } = null!;
}
