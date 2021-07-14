using Microsoft.EntityFrameworkCore.Migrations;

namespace MobilesShop.Data.Migrations
{
    public partial class MergeDisplayTypeAndDisplaySizeIntoDisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobilePhones_DisplaySizes_DisplaySizeId",
                table: "MobilePhones");

            migrationBuilder.DropForeignKey(
                name: "FK_MobilePhones_DisplayTypes_DisplayTypeId",
                table: "MobilePhones");

            migrationBuilder.DropTable(
                name: "DisplaySizes");

            migrationBuilder.DropTable(
                name: "DisplayTypes");

            migrationBuilder.DropIndex(
                name: "IX_MobilePhones_DisplaySizeId",
                table: "MobilePhones");

            migrationBuilder.DropColumn(
                name: "DisplaySizeId",
                table: "MobilePhones");

            migrationBuilder.RenameColumn(
                name: "DisplayTypeId",
                table: "MobilePhones",
                newName: "DisplayId");

            migrationBuilder.RenameIndex(
                name: "IX_MobilePhones_DisplayTypeId",
                table: "MobilePhones",
                newName: "IX_MobilePhones_DisplayId");

            migrationBuilder.CreateTable(
                name: "Displays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Protection = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Displays", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MobilePhones_Displays_DisplayId",
                table: "MobilePhones",
                column: "DisplayId",
                principalTable: "Displays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobilePhones_Displays_DisplayId",
                table: "MobilePhones");

            migrationBuilder.DropTable(
                name: "Displays");

            migrationBuilder.RenameColumn(
                name: "DisplayId",
                table: "MobilePhones",
                newName: "DisplayTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MobilePhones_DisplayId",
                table: "MobilePhones",
                newName: "IX_MobilePhones_DisplayTypeId");

            migrationBuilder.AddColumn<int>(
                name: "DisplaySizeId",
                table: "MobilePhones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DisplaySizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplaySizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisplayTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhones_DisplaySizeId",
                table: "MobilePhones",
                column: "DisplaySizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobilePhones_DisplaySizes_DisplaySizeId",
                table: "MobilePhones",
                column: "DisplaySizeId",
                principalTable: "DisplaySizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MobilePhones_DisplayTypes_DisplayTypeId",
                table: "MobilePhones",
                column: "DisplayTypeId",
                principalTable: "DisplayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
