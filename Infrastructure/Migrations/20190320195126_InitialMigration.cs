using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samochody",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Marka = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    RokProdukcji = table.Column<int>(nullable: false),
                    Przebieg = table.Column<string>(nullable: true),
                    Pojemność = table.Column<string>(nullable: true),
                    RodzajPaliwa = table.Column<string>(nullable: true),
                    Moc = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Cena = table.Column<decimal>(nullable: false),
                    ZdjecieURL = table.Column<string>(nullable: true),
                    MiniaturkaURL = table.Column<string>(nullable: true),
                    JestSamochodemTygodnia = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samochody", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samochody");
        }
    }
}
