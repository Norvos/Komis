using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Infrastructure.Migrations
{
    public partial class DodanieOponii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opinie",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NazwaUztykownika = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Wiadomosc = table.Column<string>(nullable: true),
                    OczekujeOdpowiedzi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinie", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opinie");
        }
    }
}
