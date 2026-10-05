using Microsoft.EntityFrameworkCore;
using School.Library.Models;

namespace School.Library.DAL;

public class SchoolInitializer
{
    public static void Seed(DbContextOptions<SchoolContext> options)
    {
        using var context = new SchoolContext(options);

        List<Instructor> instructors =
        [
            new Instructor { LastName = "Fakhouri", FirstName = "Fadi", HireDate = new DateOnly(2002, 8, 6) },
            new Instructor { LastName = "Serrano", FirstName = "Stacy", HireDate = new DateOnly(1999, 6, 1) },
            new Instructor { LastName = "Stewart", FirstName = "Jasmine", HireDate = new DateOnly(1997, 10, 12) },
            new Instructor { LastName = "Xu", FirstName = "Kristen", HireDate = new DateOnly(2001, 7, 23) },
            new Instructor { LastName = "Van Houten", FirstName = "Roger", HireDate = new DateOnly(2000, 12, 7) },
        ];
        context.AddRange(instructors);
        context.SaveChanges();

        List<Student> students =
        [
            new Student { LastName = "Barzdukas", FirstName = "Gytis", EnrollmentDate = new DateOnly(2005, 9, 1) },
            new Student { LastName = "Justice", FirstName = "Peggy", EnrollmentDate = new DateOnly(2001, 9, 1) },
            new Student { LastName = "Li", FirstName = "Yan", EnrollmentDate = new DateOnly(2002, 9, 1) },
            new Student { LastName = "Norman", FirstName = "Laura", EnrollmentDate = new DateOnly(2003, 9, 1) },
            new Student { LastName = "Olivotto", FirstName = "Nino", EnrollmentDate = new DateOnly(2005, 9, 1) },
            new Student { LastName = "Tang", FirstName = "Wayne", EnrollmentDate = new DateOnly(2005, 9, 1) },
            new Student { LastName = "Alonso", FirstName = "Meredith", EnrollmentDate = new DateOnly(2002, 9, 1) },
            new Student { LastName = "Lopez", FirstName = "Sophia", EnrollmentDate = new DateOnly(2004, 9, 1) },
            new Student { LastName = "Browning", FirstName = "Meredith", EnrollmentDate = new DateOnly(2000, 9, 1) },
            new Student { LastName = "Anand", FirstName = "Arturo", EnrollmentDate = new DateOnly(2003, 9, 1) },
            new Student { LastName = "Walker", FirstName = "Alexandra", EnrollmentDate = new DateOnly(2000, 9, 1) },
            new Student { LastName = "Powell", FirstName = "Carson", EnrollmentDate = new DateOnly(2004, 9, 1) },
            new Student { LastName = "Jai", FirstName = "Damien", EnrollmentDate = new DateOnly(2001, 9, 1) },
            new Student { LastName = "Carlson", FirstName = "Robyn", EnrollmentDate = new DateOnly(2005, 9, 1) },
            new Student { LastName = "Bryant", FirstName = "Carson", EnrollmentDate = new DateOnly(2001, 9, 1) },
            new Student { LastName = "Suarez", FirstName = "Robyn", EnrollmentDate = new DateOnly(2004, 9, 1) },
            new Student { LastName = "Holt", FirstName = "Roger", EnrollmentDate = new DateOnly(2004, 9, 1) },
            new Student { LastName = "Alexander", FirstName = "Carson", EnrollmentDate = new DateOnly(2005, 9, 1) },
            new Student { LastName = "Morgan", FirstName = "Isaiah", EnrollmentDate = new DateOnly(2001, 9, 1) },
            new Student { LastName = "Martin", FirstName = "Randall", EnrollmentDate = new DateOnly(2005, 9, 1) },
            new Student { LastName = "Rogers", FirstName = "Cody", EnrollmentDate = new DateOnly(2002, 9, 1) },
            new Student { LastName = "White", FirstName = "Anthony", EnrollmentDate = new DateOnly(2001, 9, 1) },
            new Student { LastName = "Griffin", FirstName = "Rachel", EnrollmentDate = new DateOnly(2004, 9, 1) },
            new Student { LastName = "Shan", FirstName = "Alicia", EnrollmentDate = new DateOnly(2003, 9, 1) },
            new Student { LastName = "Gao", FirstName = "Erica", EnrollmentDate = new DateOnly(2003, 1, 30) },
        ];
        context.AddRange(students);
        context.SaveChanges();

        List<DepartmentAdministrator> departmentAdministrators =
        [
            new DepartmentAdministrator { LastName = "Abercrombie", FirstName = "Kim", HireDate = new DateOnly(1995, 3, 11) },
            new DepartmentAdministrator { LastName = "Harui", FirstName = "Roger", HireDate = new DateOnly(1998, 7, 1) },
            new DepartmentAdministrator { LastName = "Zheng", FirstName = "Roger", HireDate = new DateOnly(2004, 2, 12) },
            new DepartmentAdministrator { LastName = "Kapoor", FirstName = "Candace", HireDate = new DateOnly(2001, 1, 15) },
        ];
        context.AddRange(departmentAdministrators);
        context.SaveChanges();

        List<Department> departments =
        [
            new Department { Name = "Engineering", Budget = 350000.0m, StartDate = new DateOnly(2007, 9, 1), AdministratorId = 31 },
            new Department { Name = "English", Budget = 120000.0m, StartDate = new DateOnly(2007, 9, 1), AdministratorId = 34 },
            new Department { Name = "Economics", Budget = 200000.0m, StartDate = new DateOnly(2007, 9, 1), AdministratorId = 33 },
            new Department { Name = "Mathematics", Budget = 250000.0m, StartDate = new DateOnly(2007, 9, 1), AdministratorId = 32 },
        ];
        context.AddRange(departments);
        context.SaveChanges();

        List<OnlineCourse> onlineCourses =
        [
            new OnlineCourse { Id = 2021, Title = "Composition", Credits = 3, Url = "http://www.fineartschool.net/Composition", DepartmentId = 2 },
            new OnlineCourse { Id = 2030, Title = "Poetry", Credits = 2, Url = "", DepartmentId = 2 },
            new OnlineCourse { Id = 3141, Title = "Trigonometry", Credits = 4, Url = "http://www.fineartschool.net/Trigonometry", DepartmentId = 4 },
            new OnlineCourse { Id = 4041, Title = "Macroeconomics", Credits = 3, Url = "http://www.fineartschool.net/Macroeconomics", DepartmentId = 3  },
        ];
        context.AddRange(onlineCourses);
        context.SaveChanges();

        List<OnsiteCourse> onsiteCourses =
        [
            new OnsiteCourse { Id = 1045, Title = "Calculus", Credits = 4, Location = "121 Smith", Time = new TimeOnly(15, 30, 0), DepartmentId = 4 },
            new OnsiteCourse { Id = 1050, Title = "Chemistry", Credits = 4, Location = "123 Smith", Time = new TimeOnly(11, 30, 0), DepartmentId = 1 },
            new OnsiteCourse { Id = 1061, Title = "Physics", Credits = 4, Location = "234 Smith", Time = new TimeOnly(13, 15, 0), DepartmentId = 1 },
            new OnsiteCourse { Id = 2042, Title = "Literature", Credits = 4, Location = "225 Adams", Time = new TimeOnly(11, 0, 0), DepartmentId = 2 },
            new OnsiteCourse { Id = 4022, Title = "Microeconomics", Credits = 3, Location = "23 Williams", Time = new TimeOnly(9, 0, 0), DepartmentId = 3 },
            new OnsiteCourse { Id = 4061, Title = "Quantitative", Credits = 2, Location = "22 Williams", Time = new TimeOnly(11, 15, 0), DepartmentId = 3 },
        ];
        context.AddRange(onsiteCourses);
        context.SaveChanges();

        List<OfficeAssignment> assignments =
        [
            new OfficeAssignment { InstructorId = 1, Location = "29 Adams" },
            new OfficeAssignment { InstructorId = 2, Location = "271 Williams" },
            new OfficeAssignment { InstructorId = 3, Location = "131 Smith" },
            new OfficeAssignment { InstructorId = 4, Location = "203 Williams" },
            new OfficeAssignment { InstructorId = 5, Location = "213 Smith" },
            new OfficeAssignment { InstructorId = 31, Location = "17 Smith" },
            new OfficeAssignment { InstructorId = 32, Location = "37 Williams" },
            new OfficeAssignment { InstructorId = 33, Location = "143 Smith" },
            new OfficeAssignment { InstructorId = 34, Location = "57 Adams" },
        ];
        context.AddRange(assignments);
        context.SaveChanges();

        context.Courses.Find(2030)!.Instructors.Add(context.Instructors.Find(1)!);
        context.Courses.Find(2021)!.Instructors.Add(context.Instructors.Find(2)!);
        context.Courses.Find(1061)!.Instructors.Add(context.Instructors.Find(3)!);
        context.Courses.Find(4041)!.Instructors.Add(context.Instructors.Find(4)!);
        context.Courses.Find(4061)!.Instructors.Add(context.Instructors.Find(5)!);
        context.Courses.Find(1050)!.Instructors.Add(context.Instructors.Find(31)!);
        context.Courses.Find(1045)!.Instructors.Add(context.Instructors.Find(32)!);
        context.Courses.Find(4022)!.Instructors.Add(context.Instructors.Find(33)!);
        context.Courses.Find(2042)!.Instructors.Add(context.Instructors.Find(34)!);
        context.SaveChanges();

        List<Enrollment> enrollments =
        [
            new Enrollment { CourseId = 1045, StudentId = 24, Grade = 1.5m },
            new Enrollment { CourseId = 1045, StudentId = 27, Grade = 2.5m },
            new Enrollment { CourseId = 1050, StudentId = 26, Grade = 3.5m },
            new Enrollment { CourseId = 1050, StudentId = 27, Grade = 3.5m },
            new Enrollment { CourseId = 1050, StudentId = 29, Grade = 3.5m },
            new Enrollment { CourseId = 1061, StudentId = 25, Grade = 4.0m },
            new Enrollment { CourseId = 1061, StudentId = 26, Grade = 3.0m },
            new Enrollment { CourseId = 1061, StudentId = 28, Grade = 4.0m },
            new Enrollment { CourseId = 1061, StudentId = 29, Grade = 4.0m },
            new Enrollment { CourseId = 2021, StudentId = 6, Grade = 4.0m },
            new Enrollment { CourseId = 2021, StudentId = 7, Grade = 3.0m },
            new Enrollment { CourseId = 2021, StudentId = 8, Grade = 2.5m },
            new Enrollment { CourseId = 2021, StudentId = 9, Grade = 3.5m },
            new Enrollment { CourseId = 2021, StudentId = 10, Grade = 3.0m },
            new Enrollment { CourseId = 2030, StudentId = 6, Grade = 3.5m },
            new Enrollment { CourseId = 2030, StudentId = 7, Grade = 4.0m },
            new Enrollment { CourseId = 2042, StudentId = 8, Grade = 3.5m },
            new Enrollment { CourseId = 2042, StudentId = 9, Grade = 4.0m },
            new Enrollment { CourseId = 2042, StudentId = 10, Grade = 3.0m },
            new Enrollment { CourseId = 4022, StudentId = 15, Grade = 4.0m },
            new Enrollment { CourseId = 4022, StudentId = 16, Grade = 3.0m },
            new Enrollment { CourseId = 4022, StudentId = 17, Grade = 2.5m },
            new Enrollment { CourseId = 4022, StudentId = 18, Grade = 2.0m },
            new Enrollment { CourseId = 4022, StudentId = 19, Grade = null },
            new Enrollment { CourseId = 4022, StudentId = 20, Grade = 3.5m },
            new Enrollment { CourseId = 4022, StudentId = 23, Grade = 3.0m },
            new Enrollment { CourseId = 4022, StudentId = 24, Grade = 3.0m },
            new Enrollment { CourseId = 4041, StudentId = 11, Grade = 3.5m },
            new Enrollment { CourseId = 4041, StudentId = 12, Grade = null },
            new Enrollment { CourseId = 4041, StudentId = 13, Grade = 2.5m },
            new Enrollment { CourseId = 4041, StudentId = 14, Grade = null },
            new Enrollment { CourseId = 4041, StudentId = 16, Grade = 3.0m },
            new Enrollment { CourseId = 4041, StudentId = 23, Grade = 3.5m },
            new Enrollment { CourseId = 4061, StudentId = 14, Grade = null },
            new Enrollment { CourseId = 4061, StudentId = 15, Grade = 4.0m },
            new Enrollment { CourseId = 4061, StudentId = 21, Grade = 4.0m },
            new Enrollment { CourseId = 4061, StudentId = 22, Grade = 2.0m },
            new Enrollment { CourseId = 4061, StudentId = 23, Grade = 2.5m }
        ];
        context.AddRange(enrollments);
        context.SaveChanges();

        context.Database.ExecuteSql(
            @$"CREATE PROCEDURE GetDepartmentsWithMostEnrollments
               @NumberOfEnrollments INT
               AS
               BEGIN
                 SELECT d.Id, d.Name, d.StartDate, d.Budget, d.AdministratorId, COUNT(e.CourseId) AS EnrollmentsCount
                 FROM Departments d
                 INNER JOIN Courses c ON d.Id = c.DepartmentId
                 INNER JOIN Enrollments e ON c.Id = e.CourseId
                 GROUP BY d.Id, d.Name, d.StartDate, d.Budget, d.AdministratorId
                 HAVING COUNT(e.CourseId) > @NumberOfEnrollments
                 ORDER BY EnrollmentsCount DESC
               END"
        );

        context.Database.ExecuteSql(
            $@"CREATE FUNCTION dbo.GetEnrollmentsCountByDepartmentId(@DepartmentId INT)
               RETURNS INT
               AS
               BEGIN
                 DECLARE @EnrollmentsCount INT

                 SELECT @EnrollmentsCount = COUNT(e.CourseId)
                 FROM Departments d
                 INNER JOIN Courses c ON d.Id = c.DepartmentId
                 INNER JOIN Enrollments e ON c.Id = e.CourseId
                 WHERE d.Id = @DepartmentId
                 GROUP BY d.Id

                 RETURN @EnrollmentsCount
               END"
        );

        context.Database.ExecuteSql(
            $@"CREATE FUNCTION dbo.GetDepartmentsWithMoreThanGivenNumberOfEnrollments(@NumberOfEnrollments INT)
               RETURNS TABLE
               AS
               RETURN
               (
               SELECT d.Id, d.Name, d.Budget, d.StartDate, d.AdministratorId
               FROM Departments d
               INNER JOIN Courses c ON d.Id = c.DepartmentId
               INNER JOIN Enrollments e ON c.Id = e.CourseId
               GROUP BY d.Id, d.Name, d.Budget, d.StartDate, d.AdministratorId
               HAVING COUNT(e.CourseId) > @NumberOfEnrollments
               )"
        );
        context.SaveChanges();
    }
}
