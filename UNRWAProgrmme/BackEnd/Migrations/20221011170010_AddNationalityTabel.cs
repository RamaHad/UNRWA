using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddNationalityTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Individual",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Individual_NationalityId",
                table: "Individual",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_nationalities_NationalityId",
                table: "Individual",
                column: "NationalityId",
                principalTable: "nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Individual_nationalities_NationalityId",
                table: "Individual");

            migrationBuilder.DropTable(
                name: "nationalities");

            migrationBuilder.DropIndex(
                name: "IX_Individual_NationalityId",
                table: "Individual");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Individual");
        }
    }
}
