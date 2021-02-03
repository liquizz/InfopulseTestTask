using Microsoft.EntityFrameworkCore.Migrations;

namespace WebPortal.Database.Migrations
{
    public partial class AddedOrderStatusesForeignKeyToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderStatusesStatusId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusesStatusId",
                table: "Orders",
                column: "OrderStatusesStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersStatuses_OrderStatusesStatusId",
                table: "Orders",
                column: "OrderStatusesStatusId",
                principalTable: "OrdersStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersStatuses_OrderStatusesStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusesStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusesStatusId",
                table: "Orders");
        }
    }
}
