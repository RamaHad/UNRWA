using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddReservationTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClerickId = table.Column<int>(type: "int", nullable: false),
                    EmployeeForServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    IndevisualId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservations_employees_ClerickId",
                        column: x => x.ClerickId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_employees_EmployeeForServiceId",
                        column: x => x.EmployeeForServiceId,
                        principalTable: "employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reservations_Individual_IndevisualId",
                        column: x => x.IndevisualId,
                        principalTable: "Individual",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reservations_services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requiredLabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfRequired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    LabTestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requiredLabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requiredLabTests_labTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "labTests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_requiredLabTests_reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requiredLabTests_LabTestId",
                table: "requiredLabTests",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_requiredLabTests_ReservationId",
                table: "requiredLabTests",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_ClerickId",
                table: "reservations",
                column: "ClerickId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_EmployeeForServiceId",
                table: "reservations",
                column: "EmployeeForServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_IndevisualId",
                table: "reservations",
                column: "IndevisualId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_ServiceId",
                table: "reservations",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requiredLabTests");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
