using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentieDeTurism.Migrations
{
    public partial class AddedUsernameAndPasswordToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clienti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Clienti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clienti");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Clienti");
        }
    }
}
