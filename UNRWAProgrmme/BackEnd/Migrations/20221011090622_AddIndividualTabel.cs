using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddIndividualTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "originalPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_originalPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Individual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherId = table.Column<int>(type: "int", nullable: true),
                    RelationShipId = table.Column<int>(type: "int", nullable: false),
                    FamilyRegestrationCardId = table.Column<int>(type: "int", nullable: false),
                    ResidentialAddressId = table.Column<int>(type: "int", nullable: false),
                    OriginalPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individual_familyRegestrationCards_FamilyRegestrationCardId",
                        column: x => x.FamilyRegestrationCardId,
                        principalTable: "familyRegestrationCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Individual_originalPlaces_OriginalPlaceId",
                        column: x => x.OriginalPlaceId,
                        principalTable: "originalPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Individual_relationships_RelationShipId",
                        column: x => x.RelationShipId,
                        principalTable: "relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Individual_residentialAddresses_ResidentialAddressId",
                        column: x => x.ResidentialAddressId,
                        principalTable: "residentialAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Individual_FamilyRegestrationCardId",
                table: "Individual",
                column: "FamilyRegestrationCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_OriginalPlaceId",
                table: "Individual",
                column: "OriginalPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_RelationShipId",
                table: "Individual",
                column: "RelationShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_ResidentialAddressId",
                table: "Individual",
                column: "ResidentialAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Individual");

            migrationBuilder.DropTable(
                name: "originalPlaces");
        }
    }
}
