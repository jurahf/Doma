using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class DateTimeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SupportRequest");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "SupportRequest",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SupportRequest",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Notification",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Feedback",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "ChatMessage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "SupportRequest");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SupportRequest");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "ChatMessage");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SupportRequest",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
