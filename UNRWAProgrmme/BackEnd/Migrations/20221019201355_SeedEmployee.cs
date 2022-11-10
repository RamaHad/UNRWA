using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class SeedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[employees] ([Salary]  ,[IndividualId] ,[TeamId]   ,[WorkId] ,[HealthCenterId]) VALUES   (500.0 ,14  ,1 ,1 ,6),(500.0 ,17  ,1 ,5 ,6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[employees]");
        }
    }
}
