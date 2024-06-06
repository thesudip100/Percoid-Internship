using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PercoidCRUD.Migrations
{
    public partial class newmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyWorkDescription",
                table: "Intern");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DailyWorkDescription",
                table: "Intern",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
