namespace School.Library.ViewModels;

public class InstructorWithOffice
{
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public DateOnly HireDate { get; set; }
    public string Location { get; set; } = null!;
}
