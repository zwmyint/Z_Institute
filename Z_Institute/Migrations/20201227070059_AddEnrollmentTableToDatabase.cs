using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Z_Institute.Migrations
{
    public partial class AddEnrollmentTableToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_Student",
                newName: "StudentId");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "tbl_Student",
                nullable: false,
                defaultValue: 0);

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
                name: "tbl_Enrollment");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "tbl_Student");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "tbl_Student",
                newName: "Id");
        }
    }
}
