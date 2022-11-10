using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class AddPreviewIllnessTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "previewIllnesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviewId = table.Column<int>(type: "int", nullable: false),
                    IllnessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_previewIllnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_previewIllnesses_illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_previewIllnesses_previews_PreviewId",
                        column: x => x.PreviewId,
                        principalTable: "previews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_previewIllnesses_IllnessId",
                table: "previewIllnesses",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_previewIllnesses_PreviewId",
                table: "previewIllnesses",
                column: "PreviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "previewIllnesses");
        }
    }
}
