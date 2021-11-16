using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrarySystem.Infrastructure.Migrations
{
    public partial class addSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                newName: "IX_Books_SubCategoryId");

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_SubCategory_SubCategoryId",
                table: "Books",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            var sp = @"CREATE PROCEDURE [dbo].[GetAllSubCategories]
                    @CategoryId int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from SubCategories where CategoryId = @CategoryId
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_SubCategory_SubCategoryId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_SubCategoryId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
