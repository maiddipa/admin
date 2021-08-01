using Microsoft.EntityFrameworkCore.Migrations;

namespace BIMA.Database.Migrations
{
    public partial class addCourseIdToUserCourseContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseContents_CourseContents_CourseContentId",
                table: "UserCourseContents");

            migrationBuilder.DropIndex(
                name: "IX_UserCourseContents_CourseContentId",
                table: "UserCourseContents");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "UserCourseContents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserCourseContents");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseContents_CourseContentId",
                table: "UserCourseContents",
                column: "CourseContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseContents_CourseContents_CourseContentId",
                table: "UserCourseContents",
                column: "CourseContentId",
                principalTable: "CourseContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
