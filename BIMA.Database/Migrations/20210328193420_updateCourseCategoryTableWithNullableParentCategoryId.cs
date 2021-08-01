using Microsoft.EntityFrameworkCore.Migrations;

namespace BIMA.Database.Migrations
{
    public partial class updateCourseCategoryTableWithNullableParentCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubCategory",
                table: "CourseCategories");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "CourseCategories");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "CourseCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "CourseCategories");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubCategory",
                table: "CourseCategories",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "CourseCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
