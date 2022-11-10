using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddChiledCardTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualMeasurementResult_Individual_IndividualId",
                table: "IndividualMeasurementResult");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualMeasurementResult_Measurement_MeasurementId",
                table: "IndividualMeasurementResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualMeasurementResult",
                table: "IndividualMeasurementResult");

            migrationBuilder.RenameTable(
                name: "Measurement",
                newName: "measurements");

            migrationBuilder.RenameTable(
                name: "IndividualMeasurementResult",
                newName: "individualMeasurementResults");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualMeasurementResult_MeasurementId",
                table: "individualMeasurementResults",
                newName: "IX_individualMeasurementResults_MeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualMeasurementResult_IndividualId",
                table: "individualMeasurementResults",
                newName: "IX_individualMeasurementResults_IndividualId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_measurements",
                table: "measurements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_individualMeasurementResults",
                table: "individualMeasurementResults",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "childCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IndivisualId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_childCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_childCards_Individual_IndivisualId",
                        column: x => x.IndivisualId,
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_childCards_IndivisualId",
                table: "childCards",
                column: "IndivisualId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_individualMeasurementResults_Individual_IndividualId",
                table: "individualMeasurementResults",
                column: "IndividualId",
                principalTable: "Individual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_individualMeasurementResults_measurements_MeasurementId",
                table: "individualMeasurementResults",
                column: "MeasurementId",
                principalTable: "measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_individualMeasurementResults_Individual_IndividualId",
                table: "individualMeasurementResults");

            migrationBuilder.DropForeignKey(
                name: "FK_individualMeasurementResults_measurements_MeasurementId",
                table: "individualMeasurementResults");

            migrationBuilder.DropTable(
                name: "childCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_measurements",
                table: "measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_individualMeasurementResults",
                table: "individualMeasurementResults");

            migrationBuilder.RenameTable(
                name: "measurements",
                newName: "Measurement");

            migrationBuilder.RenameTable(
                name: "individualMeasurementResults",
                newName: "IndividualMeasurementResult");

            migrationBuilder.RenameIndex(
                name: "IX_individualMeasurementResults_MeasurementId",
                table: "IndividualMeasurementResult",
                newName: "IX_IndividualMeasurementResult_MeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_individualMeasurementResults_IndividualId",
                table: "IndividualMeasurementResult",
                newName: "IX_IndividualMeasurementResult_IndividualId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurement",
                table: "Measurement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualMeasurementResult",
                table: "IndividualMeasurementResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualMeasurementResult_Individual_IndividualId",
                table: "IndividualMeasurementResult",
                column: "IndividualId",
                principalTable: "Individual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualMeasurementResult_Measurement_MeasurementId",
                table: "IndividualMeasurementResult",
                column: "MeasurementId",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
