using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class City : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Hotel");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Hotel",
                type: "decimal(18,10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Hotel",
                type: "decimal(18,10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Hotel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CityId",
                table: "Hotel",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_City_CityId",
                table: "Hotel",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_City_CityId",
                table: "Hotel");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_CityId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Hotel");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Hotel",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Hotel",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,10)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hotel",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
