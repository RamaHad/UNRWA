using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddIndividualSelfJoinRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Individual_FatherId",
                table: "Individual",
                column: "FatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_Individual_FatherId",
                table: "Individual",
                column: "FatherId",
                principalTable: "Individual",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Individual_Individual_FatherId",
                table: "Individual");

            migrationBuilder.DropIndex(
                name: "IX_Individual_FatherId",
                table: "Individual");
        }
    }
}
