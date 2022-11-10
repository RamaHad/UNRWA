using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddNCDCardFollwUpVisitTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ncdCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diabetes = table.Column<int>(type: "int", nullable: false),
                    Pressure = table.Column<bool>(type: "bit", nullable: false),
                    Sensitive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndividualId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncdCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ncdCards_Individual_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "follwUpVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfFollwUp = table.Column<bool>(type: "bit", nullable: false),
                    NCDCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follwUpVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_follwUpVisits_ncdCards_NCDCardId",
                        column: x => x.NCDCardId,
                        principalTable: "ncdCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_follwUpVisits_NCDCardId",
                table: "follwUpVisits",
                column: "NCDCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ncdCards_IndividualId",
                table: "ncdCards",
                column: "IndividualId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "follwUpVisits");

            migrationBuilder.DropTable(
                name: "ncdCards");
        }
    }
}
