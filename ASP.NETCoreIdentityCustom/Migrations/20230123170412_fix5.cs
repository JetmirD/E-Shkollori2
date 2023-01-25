using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class fix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transkripta_AspNetUsers_ApplicationUserId",
                table: "Transkripta");

            migrationBuilder.DropIndex(
                name: "IX_Transkripta_ApplicationUserId",
                table: "Transkripta");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Transkripta");

            migrationBuilder.AddColumn<int>(
                name: "TranskriptaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TranskriptaId",
                table: "AspNetUsers",
                column: "TranskriptaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Transkripta_TranskriptaId",
                table: "AspNetUsers",
                column: "TranskriptaId",
                principalTable: "Transkripta",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Transkripta_TranskriptaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TranskriptaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TranskriptaId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Transkripta",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transkripta_ApplicationUserId",
                table: "Transkripta",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transkripta_AspNetUsers_ApplicationUserId",
                table: "Transkripta",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
