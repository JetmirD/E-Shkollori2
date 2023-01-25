using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class ShtimiICrudave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ECTS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transkripta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LendaId = table.Column<int>(type: "int", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transkripta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transkripta_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transkripta_Lenda_LendaId",
                        column: x => x.LendaId,
                        principalTable: "Lenda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transkripta_ApplicationUserId",
                table: "Transkripta",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transkripta_LendaId",
                table: "Transkripta",
                column: "LendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transkripta");

            migrationBuilder.DropTable(
                name: "Lenda");
        }
    }
}
