using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class removedforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AuthUsers_AuthId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AuthId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AuthId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthId",
                table: "Users",
                column: "AuthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AuthUsers_AuthId",
                table: "Users",
                column: "AuthId",
                principalTable: "AuthUsers",
                principalColumn: "AuthId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
