using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Infrastructure.Migrations
{
    public partial class OpiniaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NazwaUztykownika",
                table: "Opinie",
                newName: "NazwaUzytkownika");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NazwaUzytkownika",
                table: "Opinie",
                newName: "NazwaUztykownika");
        }
    }
}
