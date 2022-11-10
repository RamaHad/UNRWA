using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddFollwUpNCDDiagnosisTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "follwUpNCDDiagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    NCDDiagnosisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follwUpNCDDiagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_follwUpNCDDiagnoses_ncdDiagnoses_NCDDiagnosisId",
                        column: x => x.NCDDiagnosisId,
                        principalTable: "ncdDiagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_follwUpNCDDiagnoses_NCDDiagnosisId",
                table: "follwUpNCDDiagnoses",
                column: "NCDDiagnosisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "follwUpNCDDiagnoses");
        }
    }
}
