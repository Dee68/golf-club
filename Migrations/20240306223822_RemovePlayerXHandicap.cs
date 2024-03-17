using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfClub.Migrations
{
    /// <inheritdoc />
    public partial class RemovePlayerXHandicap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Player1Handicap",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Player2Handicap",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Player3Handicap",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "Player4Handicap",
                table: "Booking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Player1Handicap",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2Handicap",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player3Handicap",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player4Handicap",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
