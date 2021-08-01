using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace BIMA.Database.Migrations
{
    public partial class tableRelationRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseCategories_Courses_CourseId",
                table: "CourseCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseContents_Courses_CourseId",
                table: "CourseContents");

            migrationBuilder.DropIndex(
                name: "IX_CourseContents_CourseId",
                table: "CourseContents");

            migrationBuilder.DropIndex(
                name: "IX_CourseCategories_CourseId",
                table: "CourseCategories");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseContents");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseCategories");

            migrationBuilder.AddColumn<int>(
                name: "CoursesCount",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionsCount",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCourseTime",
                table: "Courses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<double>(
                name: "Duration",
                table: "CourseContents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CourseSectionId",
                table: "CourseContents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSection_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseContents_CourseSectionId",
                table: "CourseContents",
                column: "CourseSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_CourseId",
                table: "CourseSection",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseContents_CourseSection_CourseSectionId",
                table: "CourseContents",
                column: "CourseSectionId",
                principalTable: "CourseSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseContents_CourseSection_CourseSectionId",
                table: "CourseContents");

            migrationBuilder.DropTable(
                name: "CourseSection");

            migrationBuilder.DropIndex(
                name: "IX_CourseContents_CourseSectionId",
                table: "CourseContents");

            migrationBuilder.DropColumn(
                name: "CoursesCount",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SectionsCount",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TotalCourseTime",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseSectionId",
                table: "CourseContents");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "CourseContents",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseContents_CourseId",
                table: "CourseContents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCategories_CourseId",
                table: "CourseCategories",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseCategories_Courses_CourseId",
                table: "CourseCategories",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseContents_Courses_CourseId",
                table: "CourseContents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
