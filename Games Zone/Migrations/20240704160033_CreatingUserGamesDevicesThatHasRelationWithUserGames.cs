using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games_Zone.Migrations
{
    /// <inheritdoc />
    public partial class CreatingUserGamesDevicesThatHasRelationWithUserGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevices_userGames_userGameId",
                table: "GameDevices");

            migrationBuilder.DropIndex(
                name: "IX_GameDevices_userGameId",
                table: "GameDevices");

            migrationBuilder.DropColumn(
                name: "userGameId",
                table: "GameDevices");

            migrationBuilder.CreateTable(
                name: "userGameDevices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    userGameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userGameDevices", x => new { x.DeviceId, x.userGameId });
                    table.ForeignKey(
                        name: "FK_userGameDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userGameDevices_userGames_userGameId",
                        column: x => x.userGameId,
                        principalTable: "userGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Horro" });

            migrationBuilder.CreateIndex(
                name: "IX_userGameDevices_userGameId",
                table: "userGameDevices",
                column: "userGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userGameDevices");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AddColumn<int>(
                name: "userGameId",
                table: "GameDevices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameDevices_userGameId",
                table: "GameDevices",
                column: "userGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevices_userGames_userGameId",
                table: "GameDevices",
                column: "userGameId",
                principalTable: "userGames",
                principalColumn: "Id");
        }
    }
}
