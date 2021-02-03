using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPortal.Database.Migrations
{
    public partial class AddedProductCategoriesToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoriesCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoriesCategoryId",
                table: "Products",
                column: "ProductCategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoriesCategoryId",
                table: "Products",
                column: "ProductCategoriesCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoriesCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoriesCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoriesCategoryId",
                table: "Products");
        }
    }
}
