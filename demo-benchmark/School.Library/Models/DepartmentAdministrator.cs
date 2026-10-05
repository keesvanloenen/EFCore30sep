namespace School.Library.Models;

public class DepartmentAdministrator : Instructor
{
    public ICollection<Department> Departments { get; } = [];
}
