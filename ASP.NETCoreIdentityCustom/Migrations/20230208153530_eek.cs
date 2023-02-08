using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class eek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orari",
                columns: table => new
                {
                    OrariId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LendaId = table.Column<int>(type: "int", nullable: false),
                    Koha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Klasa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orari", x => x.OrariId);
                    table.ForeignKey(
                        name: "FK_Orari_Lenda2_LendaId",
                        column: x => x.LendaId,
                        principalTable: "Lenda2",
                        principalColumn: "LendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orari_LendaId",
                table: "Orari",
                column: "LendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orari");
        }
    }
}
