using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class addstudyLevelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyLevelId",
                table: "Individual",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "studyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studyLevels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Individual_StudyLevelId",
                table: "Individual",
                column: "StudyLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_studyLevels_StudyLevelId",
                table: "Individual",
                column: "StudyLevelId",
                principalTable: "studyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Individual_studyLevels_StudyLevelId",
                table: "Individual");

            migrationBuilder.DropTable(
                name: "studyLevels");

            migrationBuilder.DropIndex(
                name: "IX_Individual_StudyLevelId",
                table: "Individual");

            migrationBuilder.DropColumn(
                name: "StudyLevelId",
                table: "Individual");
        }
    }
}
