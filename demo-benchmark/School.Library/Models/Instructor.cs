using Microsoft.EntityFrameworkCore.Infrastructure;

namespace School.Library.Models;

public class Instructor : Person
{
    private OfficeAssignment _officeAssignment = null!;
    private List<Course> _courses = [];
    
    private ILazyLoader LazyLoader { get; set; } = null!;

    public Instructor()  {}
    private Instructor(ILazyLoader lazyLoader)
    {
        LazyLoader = lazyLoader;
    }

    public DateOnly HireDate { get; set; }
    public OfficeAssignment OfficeAssignment 
    {
        get => LazyLoader?.Load(this, ref _officeAssignment!) ?? _officeAssignment;
        set => _officeAssignment = value;
    }
    
    public List<Course> Courses
    {
        get => LazyLoader?.Load(this, ref _courses!) ?? _courses;
        set => _courses = value;
    }
}
