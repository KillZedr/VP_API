using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapeShop.Application.Migrations
{
    /// <inheritdoc />
    public partial class FixConfigurationsOnVSProductAndIdentitiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceChange_Product_ProductId",
                table: "PriceChange");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId1",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Manufacturer_ManufacturerId1",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ManufacturerId1",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ManufacturerId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PriceChange",
                newName: "ProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_PriceChange_ProductId",
                table: "PriceChange",
                newName: "IX_PriceChange_ProductId1");

            migrationBuilder.AlterColumn<decimal>(
                name: "NewPrice",
                table: "PriceChange",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceChange_Product_ProductId1",
                table: "PriceChange",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_Id",
                table: "Product",
                column: "Id",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Manufacturer_Id",
                table: "Product",
                column: "Id",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceChange_Product_ProductId1",
                table: "PriceChange");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Manufacturer_Id",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductId1",
                table: "PriceChange",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceChange_ProductId1",
                table: "PriceChange",
                newName: "IX_PriceChange_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId1",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NewPrice",
                table: "PriceChange",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProductCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId1",
                table: "Product",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerId1",
                table: "Product",
                column: "ManufacturerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceChange_Product_ProductId",
                table: "PriceChange",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId1",
                table: "Product",
                column: "CategoryId1",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Manufacturer_ManufacturerId1",
                table: "Product",
                column: "ManufacturerId1",
                principalTable: "Manufacturer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
