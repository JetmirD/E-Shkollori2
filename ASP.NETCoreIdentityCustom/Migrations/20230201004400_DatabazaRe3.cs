    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class DatabazaRe3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lenda2",
                columns: table => new
                {
                    LendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmriLendes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenda2", x => x.LendaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lenda2");
        }
    }
}
