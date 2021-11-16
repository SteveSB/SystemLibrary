using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Infrastructure.Migrations
{
    public partial class spGetAllAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetAllAuthors]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Authors
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
