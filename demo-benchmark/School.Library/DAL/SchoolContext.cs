using Microsoft.EntityFrameworkCore;
using School.Library.DAL.EntityConfigurations;
using School.Library.Models;

namespace School.Library.DAL;

public class SchoolContext: DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<DepartmentAdministrator> DepartmentAdministrators { get; set; }

    public DbSet<Course> Courses { get; set; }
    public DbSet<OnlineCourse> OnlineCourses { get; set; }
    public DbSet<OnsiteCourse> OnSiteCourses { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    public SchoolContext(DbContextOptions<SchoolContext> contextOptions) : base(contextOptions)
    {
    }

    public SchoolContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolV3;ConnectRetryCount=0");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new OfficeAssignmentConfiguration());
        modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentAdministratorConfiguration());
        modelBuilder.ApplyConfiguration(new InstructorConfiguration());
        modelBuilder.ApplyConfiguration(new OnlineCourseConfiguration());
        modelBuilder.ApplyConfiguration(new OnsiteCourseConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());

        modelBuilder.HasDbFunction(() => GetEnrollmentsCountByDepartmentId(default));
        modelBuilder.HasDbFunction(() => GetDepartmentsWithMoreThanGivenNumberOfEnrollments(default));
    }

    public int GetEnrollmentsCountByDepartmentId(int numberOfEnrollments)
        => throw new NotImplementedException();

    public IQueryable<Department> GetDepartmentsWithMoreThanGivenNumberOfEnrollments(int departmentId)
        => FromExpression(() => GetDepartmentsWithMoreThanGivenNumberOfEnrollments(departmentId));

}