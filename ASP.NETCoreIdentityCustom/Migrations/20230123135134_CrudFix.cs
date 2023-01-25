using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class CrudFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transkripta_Lenda_LendaId",
                table: "Transkripta");

            migrationBuilder.DropIndex(
                name: "IX_Transkripta_LendaId",
                table: "Transkripta");

            migrationBuilder.DropColumn(
                name: "LendaId",
                table: "Transkripta");

            migrationBuilder.AddColumn<int>(
                name: "TranskriptaId",
                table: "Lenda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lenda_TranskriptaId",
                table: "Lenda",
                column: "TranskriptaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lenda_Transkripta_TranskriptaId",
                table: "Lenda",
                column: "TranskriptaId",
                principalTable: "Transkripta",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lenda_Transkripta_TranskriptaId",
                table: "Lenda");

            migrationBuilder.DropIndex(
                name: "IX_Lenda_TranskriptaId",
                table: "Lenda");

            migrationBuilder.DropColumn(
                name: "TranskriptaId",
                table: "Lenda");

            migrationBuilder.AddColumn<int>(
                name: "LendaId",
                table: "Transkripta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transkripta_LendaId",
                table: "Transkripta",
                column: "LendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transkripta_Lenda_LendaId",
                table: "Transkripta",
                column: "LendaId",
                principalTable: "Lenda",
                principalColumn: "Id");
        }
    }
}
