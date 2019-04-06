using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Migrations
{
    public partial class sadassadsad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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
          
        }
    }
}
