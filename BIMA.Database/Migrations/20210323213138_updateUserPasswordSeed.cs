using Microsoft.EntityFrameworkCore.Migrations;

namespace BIMA.Database.Migrations
{
    public partial class updateUserPasswordSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJc6xurcAX/U6mpwBvPz0nVd9vbGIoxHnHLkS1Wm9ypvrfwaoZCENVDMB5WUnVe2Vw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAcNsS+l4iiakTOtxywYD7cgTRYE7Vi8fvailFsnJxfmLh/Wclt43ha/JYjYEtM9Hg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEAcNsS+l4iiakTOtxywYD7cgTRYE7Vi8fvailFsnJxfmLh/Wclt43ha/JYjYEtM9Hg==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGN6v4MkGaM0HGLN3YVuWHtr/ZyGTscvWtLDLY3o4kHjmcq7RUg5b4hiZ/malTcBfw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGN6v4MkGaM0HGLN3YVuWHtr/ZyGTscvWtLDLY3o4kHjmcq7RUg5b4hiZ/malTcBfw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGN6v4MkGaM0HGLN3YVuWHtr/ZyGTscvWtLDLY3o4kHjmcq7RUg5b4hiZ/malTcBfw==");
        }
    }
}
