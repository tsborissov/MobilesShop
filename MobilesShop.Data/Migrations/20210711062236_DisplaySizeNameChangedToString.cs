using Microsoft.EntityFrameworkCore.Migrations;

namespace MobilesShop.Data.Migrations
{
    public partial class DisplaySizeNameChangedToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "DisplaySizes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DisplaySizes",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DisplaySizes");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "DisplaySizes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
