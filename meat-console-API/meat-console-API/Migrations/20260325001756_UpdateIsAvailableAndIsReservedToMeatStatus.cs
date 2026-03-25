using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meat_console_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIsAvailableAndIsReservedToMeatStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Meats");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Meats");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Meats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Meats");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Meats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Meats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
