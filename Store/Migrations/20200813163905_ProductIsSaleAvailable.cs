using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ProductIsSaleAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSaleAvailable",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSaleAvailable",
                table: "Products");
        }
    }
}
