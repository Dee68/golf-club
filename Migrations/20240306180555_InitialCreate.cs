using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GolfClub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Golfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Handicap = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Player1GolferId = table.Column<int>(type: "int", nullable: false),
                    Player1Handicap = table.Column<int>(type: "int", nullable: false),
                    Player2GolferId = table.Column<int>(type: "int", nullable: false),
                    Player2Handicap = table.Column<int>(type: "int", nullable: false),
                    Player3GolferId = table.Column<int>(type: "int", nullable: false),
                    Player3Handicap = table.Column<int>(type: "int", nullable: false),
                    Player4GolferId = table.Column<int>(type: "int", nullable: false),
                    Player4Handicap = table.Column<int>(type: "int", nullable: false),
                    GolferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Golfer_GolferId",
                        column: x => x.GolferId,
                        principalTable: "Golfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Golfer_Player1GolferId",
                        column: x => x.Player1GolferId,
                        principalTable: "Golfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Golfer_Player2GolferId",
                        column: x => x.Player2GolferId,
                        principalTable: "Golfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Golfer_Player3GolferId",
                        column: x => x.Player3GolferId,
                        principalTable: "Golfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Golfer_Player4GolferId",
                        column: x => x.Player4GolferId,
                        principalTable: "Golfer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_GolferId",
                table: "Booking",
                column: "GolferId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Player1GolferId",
                table: "Booking",
                column: "Player1GolferId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Player2GolferId",
                table: "Booking",
                column: "Player2GolferId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Player3GolferId",
                table: "Booking",
                column: "Player3GolferId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Player4GolferId",
                table: "Booking",
                column: "Player4GolferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Golfer");
        }
    }
}
