using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentieDeTurism.Migrations
{
    public partial class AddedRezervareModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sejururi_Statiuni_StatiuneID",
                table: "Sejururi");

            migrationBuilder.DropIndex(
                name: "IX_Sejururi_StatiuneID",
                table: "Sejururi");

            migrationBuilder.CreateTable(
                name: "Rezervari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    SejurID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervari", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervari");

            migrationBuilder.CreateIndex(
                name: "IX_Sejururi_StatiuneID",
                table: "Sejururi",
                column: "StatiuneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sejururi_Statiuni_StatiuneID",
                table: "Sejururi",
                column: "StatiuneID",
                principalTable: "Statiuni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
