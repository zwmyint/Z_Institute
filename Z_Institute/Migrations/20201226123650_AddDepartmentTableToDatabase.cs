using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Z_Institute.Migrations
{
    public partial class AddDepartmentTableToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "tbl_Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "Nvarchar(50)", nullable: false),
                    Budget = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Course_DepartmentId",
                table: "tbl_Course",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Course_tbl_Department_DepartmentId",
                table: "tbl_Course",
                column: "DepartmentId",
                principalTable: "tbl_Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Course_tbl_Department_DepartmentId",
                table: "tbl_Course");

            migrationBuilder.DropTable(
                name: "tbl_Department");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Course_DepartmentId",
                table: "tbl_Course");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "tbl_Course");
        }
    }
}
