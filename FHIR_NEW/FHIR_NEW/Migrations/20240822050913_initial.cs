using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FHIR_NEW.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientsDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Telecom = table.Column<List<string>>(type: "text[]", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    DoB = table.Column<string>(type: "text", nullable: true),
                    Deceased = table.Column<List<string>>(type: "text[]", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    MaritalStatus = table.Column<List<string>>(type: "text[]", nullable: true),
                    MultipleBirth = table.Column<List<string>>(type: "text[]", nullable: true),
                    Family_ContactDetails = table.Column<List<string>>(type: "text[]", nullable: true),
                    Communication = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientsDetail");
        }
    }
}
