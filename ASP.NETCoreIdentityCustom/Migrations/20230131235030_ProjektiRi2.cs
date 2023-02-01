using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class ProjektiRi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "testi",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testi", x => x.FirstName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "testi");
        }
    }
}
