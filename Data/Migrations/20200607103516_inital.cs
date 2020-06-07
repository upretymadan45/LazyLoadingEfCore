using Microsoft.EntityFrameworkCore.Migrations;

namespace LazyLoading.Data.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SensorName = table.Column<string>(nullable: true),
                    SensorType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true),
                    SensorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readings_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "SensorName", "SensorType" },
                values: new object[] { -1, "LM35", "Temperature" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "SensorName", "SensorType" },
                values: new object[] { -2, "Smoke", "Smoke" });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "SensorId", "Value" },
                values: new object[] { -1, -1, "20" });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "SensorId", "Value" },
                values: new object[] { -2, -1, "30" });

            migrationBuilder.InsertData(
                table: "Readings",
                columns: new[] { "Id", "SensorId", "Value" },
                values: new object[] { -3, -2, "100" });

            migrationBuilder.CreateIndex(
                name: "IX_Readings_SensorId",
                table: "Readings",
                column: "SensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
