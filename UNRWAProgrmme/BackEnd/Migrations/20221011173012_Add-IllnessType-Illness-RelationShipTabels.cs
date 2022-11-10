using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddIllnessTypeIllnessRelationShipTabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IllnessTypeId",
                table: "illnesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_illnesses_IllnessTypeId",
                table: "illnesses",
                column: "IllnessTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_illnesses_illnessTypes_IllnessTypeId",
                table: "illnesses",
                column: "IllnessTypeId",
                principalTable: "illnessTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_illnesses_illnessTypes_IllnessTypeId",
                table: "illnesses");

            migrationBuilder.DropIndex(
                name: "IX_illnesses_IllnessTypeId",
                table: "illnesses");

            migrationBuilder.DropColumn(
                name: "IllnessTypeId",
                table: "illnesses");
        }
    }
}
