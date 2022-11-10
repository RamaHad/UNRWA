using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    public partial class SeedIndvidual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Individual] ([FirstName],[LastName] ,[Gender],[DateOfBirthday] ,[FatherId],[RelationShipId],[FamilyRegestrationCardId] ,[ResidentialAddressId] ,[OriginalPlaceId] ,[NationalityId])  VALUES ('Aya','Al Mohammad'  ,1 ,'02-02-2002'  ,14 ,6,4 ,1 ,7 ,5), ('Nour','Al Ali'  ,1 ,'03-03-2003'  ,14 ,8,4 ,1 ,7 ,5), ('Majed','Al Ali'  ,0 ,'04-04-2004'  ,14 ,7,4 ,1 ,7 ,5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
