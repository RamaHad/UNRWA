using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddNCDMedicineTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "follwUpNCDDiagnoses",
                newName: "Status");

            migrationBuilder.CreateTable(
                name: "ncdMedicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfPrescription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false),
                    NCDCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncdMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncdMedicines_medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "medicines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ncdMedicines_ncdCards_NCDCardId",
                        column: x => x.NCDCardId,
                        principalTable: "ncdCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ncdMedicines_MedicineId",
                table: "ncdMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_ncdMedicines_NCDCardId",
                table: "ncdMedicines",
                column: "NCDCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ncdMedicines");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "follwUpNCDDiagnoses",
                newName: "State");
        }
    }
}
