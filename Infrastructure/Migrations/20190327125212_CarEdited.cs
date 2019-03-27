using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Infrastructure.Migrations
{
    public partial class CarEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samochody");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<int>(nullable: false),
                    Milage = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    Power = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PictureURL = table.Column<string>(nullable: true),
                    ThumbnailURL = table.Column<string>(nullable: true),
                    IsCarOfTheWeek = table.Column<bool>(nullable: false),
                    IsInACentral = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.CreateTable(
                name: "Samochody",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Cena = table.Column<decimal>(nullable: false),
                    JestSamochodemTygodnia = table.Column<bool>(nullable: false),
                    JestWCentrali = table.Column<bool>(nullable: false),
                    Marka = table.Column<string>(nullable: true),
                    MiniaturkaURL = table.Column<string>(nullable: true),
                    Moc = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Pojemność = table.Column<string>(nullable: true),
                    Przebieg = table.Column<string>(nullable: true),
                    RodzajPaliwa = table.Column<string>(nullable: true),
                    RokProdukcji = table.Column<int>(nullable: false),
                    ZdjecieURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samochody", x => x.ID);
                });
        }
    }
}
