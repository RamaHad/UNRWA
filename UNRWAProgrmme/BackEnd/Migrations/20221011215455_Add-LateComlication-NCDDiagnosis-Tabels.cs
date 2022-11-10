using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddLateComlicationNCDDiagnosisTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lateComplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lateComplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ncdDiagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfDiagnosis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NCDCardId = table.Column<int>(type: "int", nullable: false),
                    LateComplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncdDiagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncdDiagnoses_lateComplications_LateComplicationId",
                        column: x => x.LateComplicationId,
                        principalTable: "lateComplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ncdDiagnoses_ncdCards_NCDCardId",
                        column: x => x.NCDCardId,
                        principalTable: "ncdCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ncdDiagnoses_LateComplicationId",
                table: "ncdDiagnoses",
                column: "LateComplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ncdDiagnoses_NCDCardId",
                table: "ncdDiagnoses",
                column: "NCDCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ncdDiagnoses");

            migrationBuilder.DropTable(
                name: "lateComplications");
        }
    }
}
