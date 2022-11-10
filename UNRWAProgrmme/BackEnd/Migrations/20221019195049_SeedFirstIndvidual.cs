using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class SeedFirstIndvidual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Individual] ([FirstName],[LastName] ,[Gender],[DateOfBirthday] ,[FatherId],[RelationShipId],[FamilyRegestrationCardId] ,[ResidentialAddressId] ,[OriginalPlaceId] ,[NationalityId])  VALUES ('Ahmad',' Al Ali'  ,0 ,'01-01-2001'  ,Null ,5,4 ,1 ,7 ,5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Individual]");
        }
    }
}
