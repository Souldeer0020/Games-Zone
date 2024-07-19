using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games_Zone.Migrations
{
    /// <inheritdoc />
    public partial class AddingGameWebsiteColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameWebsite",
                table: "userGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GameWebsite",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameWebsite",
                table: "userGames");

            migrationBuilder.DropColumn(
                name: "GameWebsite",
                table: "Games");
        }
    }
}
