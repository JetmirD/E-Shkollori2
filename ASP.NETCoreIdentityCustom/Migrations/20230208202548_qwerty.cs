using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class qwerty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nxenesi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mbiemri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLindjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumriTelefonit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShkollaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nxenesi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nxenesi_Shkolla_ShkollaId",
                        column: x => x.ShkollaId,
                        principalTable: "Shkolla",
                        principalColumn: "ShkollaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nxenesi_ShkollaId",
                table: "Nxenesi",
                column: "ShkollaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nxenesi");
        }
    }
}
