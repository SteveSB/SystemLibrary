using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Infrastructure.Migrations
{
    public partial class spGetAllCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetAllCategories]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Categories
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
