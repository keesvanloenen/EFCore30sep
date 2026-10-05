using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Library.Migrations
{
    /// <inheritdoc />
    public partial class SqlCustomization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE PROCEDURE GetDepartmentsWithMostEnrollments
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
               END
            ");

            migrationBuilder.Sql(@"
               CREATE FUNCTION dbo.GetEnrollmentsCountByDepartmentId(@DepartmentId INT)
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
               END
            ");

            migrationBuilder.Sql(@"
               CREATE FUNCTION dbo.GetDepartmentsWithMoreThanGivenNumberOfEnrollments(@NumberOfEnrollments INT)
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
               )
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetDepartmentsWithMostEnrollments");
            migrationBuilder.Sql("DROP FUNCTION GetEnrollmentsCountByDepartmentId");
            migrationBuilder.Sql("DROP FUNCTION GetDepartmentsWithMoreThanGivenNumberOfEnrollments");
        }
    }
}
