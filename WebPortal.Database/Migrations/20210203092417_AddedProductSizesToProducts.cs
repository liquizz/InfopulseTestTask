using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPortal.Database.Migrations
{
    public partial class AddedProductSizesToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSizesSizeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSizesSizeId",
                table: "Products",
                column: "ProductSizesSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSizes_ProductSizesSizeId",
                table: "Products",
                column: "ProductSizesSizeId",
                principalTable: "ProductSizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSizes_ProductSizesSizeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSizesSizeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductSizesSizeId",
                table: "Products");
        }
    }
}
