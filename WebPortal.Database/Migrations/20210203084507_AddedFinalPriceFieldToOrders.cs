using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPortal.Database.Migrations
{
    public partial class AddedFinalPriceFieldToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FinalPrice",
                table: "Orders",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Orders");
        }
    }
}
