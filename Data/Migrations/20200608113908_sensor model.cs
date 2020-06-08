using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LazyLoading.Data.Migrations
{
    public partial class sensormodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loops");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Sensors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 8, 17, 24, 7, 733, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 8, 17, 24, 7, 731, DateTimeKind.Local).AddTicks(7176));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Sensors");

            migrationBuilder.CreateTable(
                name: "Loops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loops", x => x.Id);
                });
        }
    }
}
