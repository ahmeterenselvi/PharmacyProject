using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class drugtips_changing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipDescription",
                table: "DrugTips");

            migrationBuilder.RenameColumn(
                name: "TipTitle",
                table: "DrugTips",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DrugTips",
                newName: "TipTitle");

            migrationBuilder.AddColumn<string>(
                name: "TipDescription",
                table: "DrugTips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
