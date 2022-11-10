using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddImmunizationTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoseOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sideEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sideEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "immunizationProgrammes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeOfChild = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccieId = table.Column<int>(type: "int", nullable: false),
                    DoseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_immunizationProgrammes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_immunizationProgrammes_doses_DoseId",
                        column: x => x.DoseId,
                        principalTable: "doses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_immunizationProgrammes_vaccines_VaccieId",
                        column: x => x.VaccieId,
                        principalTable: "vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "immunizationDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfImmunization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChildCardId = table.Column<int>(type: "int", nullable: false),
                    ImmunizationProgrammeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_immunizationDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_immunizationDates_childCards_ChildCardId",
                        column: x => x.ChildCardId,
                        principalTable: "childCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_immunizationDates_immunizationProgrammes_ImmunizationProgrammeId",
                        column: x => x.ImmunizationProgrammeId,
                        principalTable: "immunizationProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "immunizationDateSideEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImmunizationDateId = table.Column<int>(type: "int", nullable: false),
                    SideEffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_immunizationDateSideEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_immunizationDateSideEffects_immunizationDates_ImmunizationDateId",
                        column: x => x.ImmunizationDateId,
                        principalTable: "immunizationDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_immunizationDateSideEffects_sideEffects_SideEffectId",
                        column: x => x.SideEffectId,
                        principalTable: "sideEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_immunizationDates_ChildCardId",
                table: "immunizationDates",
                column: "ChildCardId");

            migrationBuilder.CreateIndex(
                name: "IX_immunizationDates_ImmunizationProgrammeId",
                table: "immunizationDates",
                column: "ImmunizationProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_immunizationDateSideEffects_ImmunizationDateId",
                table: "immunizationDateSideEffects",
                column: "ImmunizationDateId");

            migrationBuilder.CreateIndex(
                name: "IX_immunizationDateSideEffects_SideEffectId",
                table: "immunizationDateSideEffects",
                column: "SideEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_immunizationProgrammes_DoseId",
                table: "immunizationProgrammes",
                column: "DoseId");

            migrationBuilder.CreateIndex(
                name: "IX_immunizationProgrammes_VaccieId",
                table: "immunizationProgrammes",
                column: "VaccieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "immunizationDateSideEffects");

            migrationBuilder.DropTable(
                name: "immunizationDates");

            migrationBuilder.DropTable(
                name: "sideEffects");

            migrationBuilder.DropTable(
                name: "immunizationProgrammes");

            migrationBuilder.DropTable(
                name: "doses");

            migrationBuilder.DropTable(
                name: "vaccines");
        }
    }
}
