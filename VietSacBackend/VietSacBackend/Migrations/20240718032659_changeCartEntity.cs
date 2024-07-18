using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VietSacBackend.Migrations
{
    public partial class changeCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category_id",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_description",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "product_discount",
                table: "Cart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_image",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "product_name",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "product_price",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "product_description",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "product_discount",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "product_image",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "product_name",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "product_price",
                table: "Cart");
        }
    }
}
