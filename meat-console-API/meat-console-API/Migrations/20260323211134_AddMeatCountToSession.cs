using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meat_console_API.Migrations
{
    /// <inheritdoc />
    public partial class AddMeatCountToSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeatCount",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeatCount",
                table: "Sessions");
        }
    }
}
