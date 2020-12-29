using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Z_Institute.Migrations
{
    public partial class DbInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    HireDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Instructor", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    Budget = table.Column<decimal>(nullable: false),
                    InstructorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_tbl_Department_tbl_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "tbl_Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OfficeAssignment",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OfficeAssignment", x => x.InstructorId);
                    table.ForeignKey(
                        name: "FK_tbl_OfficeAssignment_tbl_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "tbl_Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: false),
                    Credits = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_tbl_Course_tbl_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tbl_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CourseAssignment",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CourseAssignment", x => new { x.CourseId, x.InstructorId });
                    table.ForeignKey(
                        name: "FK_tbl_CourseAssignment_tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_CourseAssignment_tbl_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "tbl_Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Enrollment",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Enrollment", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_tbl_Enrollment_tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Enrollment_tbl_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tbl_Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Course_DepartmentId",
                table: "tbl_Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CourseAssignment_InstructorId",
                table: "tbl_CourseAssignment",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Department_InstructorId",
                table: "tbl_Department",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Enrollment_CourseId",
                table: "tbl_Enrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Enrollment_StudentId",
                table: "tbl_Enrollment",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_CourseAssignment");

            migrationBuilder.DropTable(
                name: "tbl_Enrollment");

            migrationBuilder.DropTable(
                name: "tbl_OfficeAssignment");

            migrationBuilder.DropTable(
                name: "tbl_Course");

            migrationBuilder.DropTable(
                name: "tbl_Student");

            migrationBuilder.DropTable(
                name: "tbl_Department");

            migrationBuilder.DropTable(
                name: "tbl_Instructor");
        }
    }
}
