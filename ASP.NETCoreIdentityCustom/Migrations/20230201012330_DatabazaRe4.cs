using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class DatabazaRe4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedLlojiLendes",
                table: "Lenda2",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedLlojiLendes",
                table: "Lenda2");
        }
    }
}
