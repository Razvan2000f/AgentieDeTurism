using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentieDeTurism.Migrations
{
    public partial class AddedSejurModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeInceput",
                table: "Statiuni");

            migrationBuilder.DropColumn(
                name: "DataDeSfarsit",
                table: "Statiuni");

            migrationBuilder.CreateTable(
                name: "Sejururi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeInceput = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeSfarsit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatiuneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sejururi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sejururi_Statiuni_StatiuneID",
                        column: x => x.StatiuneID,
                        principalTable: "Statiuni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sejururi_StatiuneID",
                table: "Sejururi",
                column: "StatiuneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sejururi");

            migrationBuilder.AddColumn<string>(
                name: "DataDeInceput",
                table: "Statiuni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataDeSfarsit",
                table: "Statiuni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
