using Microsoft.EntityFrameworkCore.Migrations;

namespace BIMA.Database.Migrations
{
    public partial class addCourseSectionIdToUsercourseContentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseSectionId",
                table: "UserCourseContents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseContents_CourseContentId",
                table: "UserCourseContents",
                column: "CourseContentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseContents_CourseContents_CourseContentId",
                table: "UserCourseContents",
                column: "CourseContentId",
                principalTable: "CourseContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseContents_CourseContents_CourseContentId",
                table: "UserCourseContents");

            migrationBuilder.DropIndex(
                name: "IX_UserCourseContents_CourseContentId",
                table: "UserCourseContents");

            migrationBuilder.DropColumn(
                name: "CourseSectionId",
                table: "UserCourseContents");
        }
    }
}
