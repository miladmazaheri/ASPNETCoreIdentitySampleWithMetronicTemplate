using Microsoft.EntityFrameworkCore.Migrations;

namespace Pars.DataLayer.MSSQL.Migrations
{
    public partial class WarehouseAddressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouses_Products_ProductId",
                table: "ProductWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouses_Warehouses_WarehouseId",
                table: "ProductWarehouses");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Warehouses",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouses_Products_ProductId",
                table: "ProductWarehouses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouses_Warehouses_WarehouseId",
                table: "ProductWarehouses",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouses_Products_ProductId",
                table: "ProductWarehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWarehouses_Warehouses_WarehouseId",
                table: "ProductWarehouses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Warehouses");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouses_Products_ProductId",
                table: "ProductWarehouses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWarehouses_Warehouses_WarehouseId",
                table: "ProductWarehouses",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
