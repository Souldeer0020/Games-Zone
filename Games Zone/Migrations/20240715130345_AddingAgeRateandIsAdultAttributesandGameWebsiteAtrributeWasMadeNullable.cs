using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games_Zone.Migrations
{
    /// <inheritdoc />
    public partial class AddingAgeRateandIsAdultAttributesandGameWebsiteAtrributeWasMadeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GameWebsite",
                table: "userGames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AgeRate",
                table: "userGames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isAdult",
                table: "userGames",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AgeRate",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isAdult",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRate",
                table: "userGames");

            migrationBuilder.DropColumn(
                name: "isAdult",
                table: "userGames");

            migrationBuilder.DropColumn(
                name: "AgeRate",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "isAdult",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "GameWebsite",
                table: "userGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
