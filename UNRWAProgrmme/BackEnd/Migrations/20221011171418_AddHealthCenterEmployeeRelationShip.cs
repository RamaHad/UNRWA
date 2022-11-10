using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddHealthCenterEmployeeRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HealthCenterId",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_employees_HealthCenterId",
                table: "employees",
                column: "HealthCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_healthCenters_HealthCenterId",
                table: "employees",
                column: "HealthCenterId",
                principalTable: "healthCenters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_healthCenters_HealthCenterId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_HealthCenterId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "HealthCenterId",
                table: "employees");
        }
    }
}
