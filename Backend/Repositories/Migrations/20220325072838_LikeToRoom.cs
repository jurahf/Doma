using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class LikeToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Hotel_HotelId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_HotelId",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Like");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Like",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Like_RoomId",
                table: "Like",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Room_RoomId",
                table: "Like",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Room_RoomId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_RoomId",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Like");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Like",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Like_HotelId",
                table: "Like",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Hotel_HotelId",
                table: "Like",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
