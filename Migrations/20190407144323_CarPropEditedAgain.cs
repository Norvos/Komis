using Microsoft.EntityFrameworkCore.Migrations;

namespace Komis.Migrations
{
    public partial class CarPropEditedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailURL",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailURL",
                table: "Cars",
                nullable: true);
        }
    }
}
