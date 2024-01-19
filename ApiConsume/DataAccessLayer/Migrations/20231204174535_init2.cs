using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacys",
                table: "Pharmacys");

            migrationBuilder.RenameTable(
                name: "Pharmacys",
                newName: "Pharmacies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies",
                column: "PharmacyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pharmacies",
                table: "Pharmacies");

            migrationBuilder.RenameTable(
                name: "Pharmacies",
                newName: "Pharmacys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pharmacys",
                table: "Pharmacys",
                column: "PharmacyId");
        }
    }
}
