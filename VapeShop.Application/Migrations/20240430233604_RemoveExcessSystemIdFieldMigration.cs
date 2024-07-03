using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapeShop.Application.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExcessSystemIdFieldMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "SystemSetting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "SystemSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
