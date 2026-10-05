using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Library.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Discriminator", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 1, "Instructor", "Fadi", new DateOnly(2002, 8, 6), "Fakhouri" },
                    { 2, "Instructor", "Stacy", new DateOnly(1999, 6, 1), "Serrano" },
                    { 3, "Instructor", "Jasmine", new DateOnly(1997, 10, 12), "Stewart" },
                    { 4, "Instructor", "Kristen", new DateOnly(2001, 7, 23), "Xu" },
                    { 5, "Instructor", "Roger", new DateOnly(2000, 12, 7), "Van Houten" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Discriminator", "EnrollmentDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 6, "Student", new DateOnly(2005, 9, 1), "Gytis", "Barzdukas" },
                    { 7, "Student", new DateOnly(2001, 9, 1), "Peggy", "Justice" },
                    { 8, "Student", new DateOnly(2002, 9, 1), "Yan", "Li" },
                    { 9, "Student", new DateOnly(2003, 9, 1), "Laura", "Norman" },
                    { 10, "Student", new DateOnly(2005, 9, 1), "Nino", "Olivotto" },
                    { 11, "Student", new DateOnly(2005, 9, 1), "Wayne", "Tang" },
                    { 12, "Student", new DateOnly(2002, 9, 1), "Meredith", "Alonso" },
                    { 13, "Student", new DateOnly(2004, 9, 1), "Sophia", "Lopez" },
                    { 14, "Student", new DateOnly(2000, 9, 1), "Meredith", "Browning" },
                    { 15, "Student", new DateOnly(2003, 9, 1), "Arturo", "Anand" },
                    { 16, "Student", new DateOnly(2000, 9, 1), "Alexandra", "Walker" },
                    { 17, "Student", new DateOnly(2004, 9, 1), "Carson", "Powell" },
                    { 18, "Student", new DateOnly(2001, 9, 1), "Damien", "Jai" },
                    { 19, "Student", new DateOnly(2005, 9, 1), "Robyn", "Carlson" },
                    { 20, "Student", new DateOnly(2001, 9, 1), "Carson", "Bryant" },
                    { 21, "Student", new DateOnly(2004, 9, 1), "Robyn", "Suarez" },
                    { 22, "Student", new DateOnly(2004, 9, 1), "Roger", "Holt" },
                    { 23, "Student", new DateOnly(2005, 9, 1), "Carson", "Alexander" },
                    { 24, "Student", new DateOnly(2001, 9, 1), "Isaiah", "Morgan" },
                    { 25, "Student", new DateOnly(2005, 9, 1), "Randall", "Martin" },
                    { 26, "Student", new DateOnly(2002, 9, 1), "Cody", "Rogers" },
                    { 27, "Student", new DateOnly(2001, 9, 1), "Anthony", "White" },
                    { 28, "Student", new DateOnly(2004, 9, 1), "Rachel", "Griffin" },
                    { 29, "Student", new DateOnly(2003, 9, 1), "Alicia", "Shan" },
                    { 30, "Student", new DateOnly(2003, 1, 30), "Erica", "Gao" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Discriminator", "FirstName", "HireDate", "LastName" },
                values: new object[,]
                {
                    { 31, "DepartmentAdministrator", "Kim", new DateOnly(1995, 3, 11), "Abercrombie" },
                    { 32, "DepartmentAdministrator", "Roger", new DateOnly(1998, 7, 1), "Harui" },
                    { 33, "DepartmentAdministrator", "Roger", new DateOnly(2004, 2, 12), "Zheng" },
                    { 34, "DepartmentAdministrator", "Candace", new DateOnly(2001, 1, 15), "Kapoor" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "AdministratorId", "Budget", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 31, 350000.0000m, "Engineering", new DateOnly(2007, 1, 9) },
                    { 2, 34, 120000.0000m, "English", new DateOnly(2007, 1, 9) },
                    { 3, 33, 200000.0000m, "Economics", new DateOnly(2007, 1, 9) },
                    { 4, 32, 250000.0000m, "Mathematics", new DateOnly(2007, 1, 9) }
                });

            migrationBuilder.InsertData(
                table: "OfficeAssignments",
                columns: new[] { "InstructorId", "Location" },
                values: new object[,]
                {
                    { 1, "29 Adams" },
                    { 2, "271 Williams" },
                    { 3, "131 Smith" },
                    { 4, "203 Williams" },
                    { 5, "213 Smith" },
                    { 31, "17 Smith" },
                    { 32, "37 Williams" },
                    { 33, "143 Smith" },
                    { 34, "57 Adams" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "DepartmentId", "Title" },
                values: new object[,]
                {
                    { 1045, 4, 4, "Calculus" },
                    { 1050, 4, 1, "Chemistry" },
                    { 1061, 4, 1, "Physics" },
                    { 2021, 3, 2, "Composition" },
                    { 2030, 2, 2, "Poetry" },
                    { 2042, 4, 2, "Literature" },
                    { 3141, 4, 4, "Trigonometry" },
                    { 4022, 3, 3, "Microeconomics" },
                    { 4041, 3, 3, "Macroeconomics" },
                    { 4061, 2, 3, "Quantitative" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "Grade" },
                values: new object[,]
                {
                    { 2021, 6, 4.00m },
                    { 2030, 6, 3.50m },
                    { 2021, 7, 3.00m },
                    { 2030, 7, 4.00m },
                    { 2021, 8, 2.50m },
                    { 2042, 8, 3.50m },
                    { 2021, 9, 3.50m },
                    { 2042, 9, 4.00m },
                    { 2021, 10, 3.00m },
                    { 2042, 10, 3.00m },
                    { 4041, 11, 3.50m },
                    { 4041, 12, null },
                    { 4041, 13, 2.50m },
                    { 4041, 14, null },
                    { 4061, 14, null },
                    { 4022, 15, 4.00m },
                    { 4061, 15, 4.00m },
                    { 4022, 16, 3.00m },
                    { 4041, 16, 3.00m },
                    { 4022, 17, 2.50m },
                    { 4022, 18, 2.00m },
                    { 4022, 19, null },
                    { 4022, 20, 3.50m },
                    { 4061, 21, 4.00m },
                    { 4061, 22, 2.00m },
                    { 4022, 23, 3.00m },
                    { 4041, 23, 3.50m },
                    { 4061, 23, 2.50m },
                    { 1045, 24, 1.50m },
                    { 4022, 24, 3.00m },
                    { 1061, 25, 4.00m },
                    { 1050, 26, 3.50m },
                    { 1061, 26, 3.00m },
                    { 1045, 27, 2.50m },
                    { 1050, 27, 3.50m },
                    { 1061, 28, 4.00m },
                    { 1050, 29, 3.50m },
                    { 1061, 29, 4.00m }
                });

            migrationBuilder.InsertData(
                table: "OnSiteCourses",
                columns: new[] { "Id", "Location", "Time" },
                values: new object[,]
                {
                    { 1045, "121 Smith", new TimeOnly(15, 30, 0) },
                    { 1050, "123 Smith", new TimeOnly(11, 30, 0) },
                    { 1061, "234 Smith", new TimeOnly(13, 15, 0) },
                    { 2042, "225 Adams", new TimeOnly(11, 0, 0) },
                    { 4022, "23 Williams", new TimeOnly(9, 0, 0) },
                    { 4061, "22 Williams", new TimeOnly(11, 15, 0) }
                });

            migrationBuilder.InsertData(
                table: "OnlineCourses",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 2021, "http://www.fineartschool.net/Composition" },
                    { 2030, "http://www.fineartschool.net/Poetry" },
                    { 3141, "http://www.fineartschool.net/Trigonometry" },
                    { 4041, "http://www.fineartschool.net/Macroeconomics" }
                });

            migrationBuilder.InsertData(
                table: "CoursesInstructors",
                columns: new[] { "CourseId", "InstructorId" },
                values: new object[,]
                {
                    {2030, 1},
                    {2021, 2},
                    {1061, 3},
                    {4041, 4},
                    {4061, 5},
                    {1050, 31},
                    {1045, 32},
                    {4022, 33},
                    {2042, 34}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
    table: "CoursesInstructors",
    keyColumns: new[] { "CourseId", "InstructorId" },
    keyValues: new object[] { 2030, 1 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 2021, 2 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 1061, 3 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 4041, 4 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 4061, 5 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 1050, 31 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 1045, 32 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 4022, 33 });

            migrationBuilder.DeleteData(
                table: "CoursesInstructors",
                keyColumns: new[] { "CourseId", "InstructorId" },
                keyValues: new object[] { 2042, 34 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2021, 6 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2030, 6 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2021, 7 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2030, 7 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2021, 8 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2042, 8 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2021, 9 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2042, 9 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2021, 10 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2042, 10 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4041, 11 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4041, 12 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4041, 13 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4041, 14 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4061, 14 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 15 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4061, 15 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 16 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4041, 16 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 17 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 18 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 19 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 20 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4061, 21 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4061, 22 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 23 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4041, 23 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4061, 23 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1045, 24 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4022, 24 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1061, 25 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1050, 26 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1061, 26 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1045, 27 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1050, 27 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1061, 28 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1050, 29 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1061, 29 });

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OfficeAssignments",
                keyColumn: "InstructorId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OnSiteCourses",
                keyColumn: "Id",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "OnSiteCourses",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "OnSiteCourses",
                keyColumn: "Id",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "OnSiteCourses",
                keyColumn: "Id",
                keyValue: 2042);

            migrationBuilder.DeleteData(
                table: "OnSiteCourses",
                keyColumn: "Id",
                keyValue: 4022);

            migrationBuilder.DeleteData(
                table: "OnSiteCourses",
                keyColumn: "Id",
                keyValue: 4061);

            migrationBuilder.DeleteData(
                table: "OnlineCourses",
                keyColumn: "Id",
                keyValue: 2021);

            migrationBuilder.DeleteData(
                table: "OnlineCourses",
                keyColumn: "Id",
                keyValue: 2030);

            migrationBuilder.DeleteData(
                table: "OnlineCourses",
                keyColumn: "Id",
                keyValue: 3141);

            migrationBuilder.DeleteData(
                table: "OnlineCourses",
                keyColumn: "Id",
                keyValue: 4041);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2021);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2030);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2042);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3141);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4022);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4041);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4061);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}
