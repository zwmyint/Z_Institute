using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Z_Institute.Migrations
{
    public partial class AddothertableToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "tbl_Department",
                nullable: true);

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
                name: "tbl_CourseAssignment",
                columns: table => new
                {
                    CourseAssignmentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CourseAssignment", x => new { x.CourseId, x.CourseAssignmentId });
                    table.ForeignKey(
                        name: "FK_tbl_CourseAssignment_tbl_Instructor_CourseAssignmentId",
                        column: x => x.CourseAssignmentId,
                        principalTable: "tbl_Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_CourseAssignment_tbl_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OfficeAssignment",
                columns: table => new
                {
                    OfficeAssignmentId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OfficeAssignment", x => x.OfficeAssignmentId);
                    table.ForeignKey(
                        name: "FK_tbl_OfficeAssignment_tbl_Instructor_OfficeAssignmentId",
                        column: x => x.OfficeAssignmentId,
                        principalTable: "tbl_Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Department_InstructorId",
                table: "tbl_Department",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CourseAssignment_CourseAssignmentId",
                table: "tbl_CourseAssignment",
                column: "CourseAssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Department_tbl_Instructor_InstructorId",
                table: "tbl_Department",
                column: "InstructorId",
                principalTable: "tbl_Instructor",
                principalColumn: "InstructorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Department_tbl_Instructor_InstructorId",
                table: "tbl_Department");

            migrationBuilder.DropTable(
                name: "tbl_CourseAssignment");

            migrationBuilder.DropTable(
                name: "tbl_OfficeAssignment");

            migrationBuilder.DropTable(
                name: "tbl_Instructor");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Department_InstructorId",
                table: "tbl_Department");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "tbl_Department");
        }
    }
}
