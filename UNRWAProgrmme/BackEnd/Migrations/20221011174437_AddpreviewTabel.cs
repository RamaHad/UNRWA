using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddpreviewTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "previews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    IndividialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_previews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_previews_employees_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_previews_Individual_IndividialId",
                        column: x => x.IndividialId,
                        principalTable: "Individual",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_previews_DoctorId",
                table: "previews",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_previews_IndividialId",
                table: "previews",
                column: "IndividialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "previews");
        }
    }
}
