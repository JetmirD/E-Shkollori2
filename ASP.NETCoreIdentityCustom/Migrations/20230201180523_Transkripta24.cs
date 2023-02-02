using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class Transkripta24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transkripta2",
                columns: table => new
                {
                    TranskriptaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LendaId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentiId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transkripta2", x => x.TranskriptaId);
                    table.ForeignKey(
                        name: "FK_Transkripta2_AspNetUsers_StudentiId",
                        column: x => x.StudentiId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transkripta2_Lenda2_LendaId",
                        column: x => x.LendaId,
                        principalTable: "Lenda2",
                        principalColumn: "LendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transkripta2_LendaId",
                table: "Transkripta2",
                column: "LendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transkripta2_StudentiId",
                table: "Transkripta2",
                column: "StudentiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transkripta2");
        }
    }
}
