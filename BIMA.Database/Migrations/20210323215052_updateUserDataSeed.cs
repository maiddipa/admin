using Microsoft.EntityFrameworkCore.Migrations;

namespace BIMA.Database.Migrations
{
    public partial class updateUserDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3478806a-694d-4797-bfcd-69e01d961f6d", "AMIR@DIGITALBIM.ACADEMY", "AQAAAAEAACcQAAAAEJc6xurcAX/U6mpwBvPz0nVd9vbGIoxHnHLkS1Wm9ypvrfwaoZCENVDMB5WUnVe2Vw==", "DMX6IN2LBO4XQWH3TJDFNF7JHRKJFGYY", "amir@digitalbim.academy" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a5b45156-8e17-41d9-8a1e-a0b873e61d05", "edince@yopmail.com", "EDINCE@YOPMAIL.COM", "EDINCE@YOPMAIL.COM", "AQAAAAEAACcQAAAAEN2WKAeKr1ZcOfZu6fvZK9HZKny7m98AMaPocHSYrrsOMtE6bbhXTsqU2PJqGt6PAw==", "SHB5H7M27HEOFYXXR4OBYLK3UNQEXFEK", "edince@yopmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0fb1a022-2065-49d1-9669-c683628b8cca", "ANESSLJIVO@GMAIL.COM", "AQAAAAEAACcQAAAAEC3HvaDc3IXfP+Lsq/iX1exwUoBEAnESEL40NSe0YmmoCY/IQDoFS67q05iG/a4h8w==", "LSXORV2CHYZQI5US6JHEYB7IJALWABS3", "anessljivo@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d01ff263-43da-4d66-bb87-07a71d8cb145", "AMIRBIM", "AQAAAAEAACcQAAAAEAcNsS+l4iiakTOtxywYD7cgTRYE7Vi8fvailFsnJxfmLh/Wclt43ha/JYjYEtM9Hg==", "47a9e07e-d491-44d4-adb5-8f67f57b7dec", "amirBim" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5a78cd9d-b6be-4667-b7ef-ca7952338a8a", "cekic.edin@hotmail.com", "CEKIC.EDIN@HOTMAIL.COM", "EDINBIM", "AQAAAAEAACcQAAAAEAcNsS+l4iiakTOtxywYD7cgTRYE7Vi8fvailFsnJxfmLh/Wclt43ha/JYjYEtM9Hg==", "8aeae5f0-3d3a-4bdc-ae7b-ab938f2ce449", "edinBim" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "1b904309-2663-4c41-ab7e-3f4b86455bca", "ANESBIM", "AQAAAAEAACcQAAAAEAcNsS+l4iiakTOtxywYD7cgTRYE7Vi8fvailFsnJxfmLh/Wclt43ha/JYjYEtM9Hg==", "8cb5a859-cf06-46eb-b47c-0ca13532fed8", "AnesBim" });
        }
    }
}
