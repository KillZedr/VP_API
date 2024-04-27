using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapeShop.Application.Migrations
{
    /// <inheritdoc />
    public partial class Fix2ConfigurationsOnVSProductAndIdentitiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceChange_Product_ProductId1",
                table: "PriceChange");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Manufacturer_ManufacturerId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_PriceChange_ProductId1",
                table: "PriceChange");

            migrationBuilder.RenameColumn(
                name: "ProductId1",
                table: "PriceChange",
                newName: "ProductManufacturerId");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "PriceChange",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                columns: new[] { "CategoryId", "ManufacturerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceChange_ProductCategoryId_ProductManufacturerId",
                table: "PriceChange",
                columns: new[] { "ProductCategoryId", "ProductManufacturerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PriceChange_Product_ProductCategoryId_ProductManufacturerId",
                table: "PriceChange",
                columns: new[] { "ProductCategoryId", "ProductManufacturerId" },
                principalTable: "Product",
                principalColumns: new[] { "CategoryId", "ManufacturerId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceChange_Product_ProductCategoryId_ProductManufacturerId",
                table: "PriceChange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_Id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_PriceChange_ProductCategoryId_ProductManufacturerId",
                table: "PriceChange");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "PriceChange");

            migrationBuilder.RenameColumn(
                name: "ProductManufacturerId",
                table: "PriceChange",
                newName: "ProductId1");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerId",
                table: "Product",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceChange_ProductId1",
                table: "PriceChange",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceChange_Product_ProductId1",
                table: "PriceChange",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Manufacturer_ManufacturerId",
                table: "Product",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id");
        }
    }
}
