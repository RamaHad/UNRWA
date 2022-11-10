using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddLabTestTypeLabTestLabTestResultTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labTestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labTestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "labTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinNormalResult = table.Column<int>(type: "int", nullable: false),
                    MaxNormalResult = table.Column<int>(type: "int", nullable: false),
                    LabTestTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labTests_labTestTypes_LabTestTypeId",
                        column: x => x.LabTestTypeId,
                        principalTable: "labTestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "labTestResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<int>(type: "int", nullable: false),
                    DateOfLabTest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndividualId = table.Column<int>(type: "int", nullable: false),
                    LabTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labTestResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labTestResults_Individual_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_labTestResults_labTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "labTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_labTestResults_IndividualId",
                table: "labTestResults",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_labTestResults_LabTestId",
                table: "labTestResults",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_labTests_LabTestTypeId",
                table: "labTests",
                column: "LabTestTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labTestResults");

            migrationBuilder.DropTable(
                name: "labTests");

            migrationBuilder.DropTable(
                name: "labTestTypes");
        }
    }
}
