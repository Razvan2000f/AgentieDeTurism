using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentieDeTurism.Migrations
{
    public partial class RemovedFieldsFromClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeInceput",
                table: "Clienti");

            migrationBuilder.DropColumn(
                name: "DataDeSfarsit",
                table: "Clienti");

            migrationBuilder.DropColumn(
                name: "StatiuneaDorita",
                table: "Clienti");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataDeInceput",
                table: "Clienti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataDeSfarsit",
                table: "Clienti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StatiuneaDorita",
                table: "Clienti",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
