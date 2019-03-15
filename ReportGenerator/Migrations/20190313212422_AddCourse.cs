using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportGenerator.Migrations
{
    public partial class AddCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
