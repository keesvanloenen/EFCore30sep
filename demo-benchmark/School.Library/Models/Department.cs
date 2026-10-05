namespace School.Library.Models;

public class Department
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;

    public decimal Budget { get; set; }

    public DateOnly StartDate { get; set; }

    public int? AdministratorId { get; set; }

    public DepartmentAdministrator? Administrator { get; set; }

    public List<Course> Courses { get; } = [];
}
