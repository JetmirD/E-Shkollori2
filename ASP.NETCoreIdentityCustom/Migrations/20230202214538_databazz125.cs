using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class databazz125 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentiId",
                table: "Transkripta2",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transkripta2_StudentiId",
                table: "Transkripta2",
                column: "StudentiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transkripta2_AspNetUsers_StudentiId",
                table: "Transkripta2",
                column: "StudentiId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transkripta2_AspNetUsers_StudentiId",
                table: "Transkripta2");

            migrationBuilder.DropIndex(
                name: "IX_Transkripta2_StudentiId",
                table: "Transkripta2");

            migrationBuilder.DropColumn(
                name: "StudentiId",
                table: "Transkripta2");
        }
    }
}
