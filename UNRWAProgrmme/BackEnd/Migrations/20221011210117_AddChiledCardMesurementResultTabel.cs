using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddChiledCardMesurementResultTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "childCardMeasurementResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<float>(type: "real", nullable: false),
                    DateOfMeasurement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChiledCardId = table.Column<int>(type: "int", nullable: false),
                    MeasurementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_childCardMeasurementResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_childCardMeasurementResults_childCards_ChiledCardId",
                        column: x => x.ChiledCardId,
                        principalTable: "childCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_childCardMeasurementResults_measurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "measurements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_childCardMeasurementResults_ChiledCardId",
                table: "childCardMeasurementResults",
                column: "ChiledCardId");

            migrationBuilder.CreateIndex(
                name: "IX_childCardMeasurementResults_MeasurementId",
                table: "childCardMeasurementResults",
                column: "MeasurementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "childCardMeasurementResults");
        }
    }
}
