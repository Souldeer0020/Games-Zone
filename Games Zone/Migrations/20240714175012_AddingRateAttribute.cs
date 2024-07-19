using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games_Zone.Migrations
{
    /// <inheritdoc />
    public partial class AddingRateAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "userGames",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Games",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "userGames");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Games");
        }
    }
}
