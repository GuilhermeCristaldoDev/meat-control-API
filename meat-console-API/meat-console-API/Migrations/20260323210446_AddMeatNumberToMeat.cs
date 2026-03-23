using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meat_console_API.Migrations
{
    /// <inheritdoc />
    public partial class AddMeatNumberToMeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeatNumber",
                table: "Meats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeatNumber",
                table: "Meats");
        }
    }
}
