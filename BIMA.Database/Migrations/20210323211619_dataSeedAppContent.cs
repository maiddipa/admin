using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BIMA.Database.Migrations
{
    public partial class dataSeedAppContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "DE", "German" },
                    { 2, "ENG", "English" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "CityId", "CompanyName", "CompanyUniqueStamp", "ConcurrencyStamp", "CountryCode", "CreatedDate", "Email", "EmailConfirmed", "Employment", "FirstName", "Gender", "LanguageId", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Paid", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, 0, 201, null, null, "d01ff263-43da-4d66-bb87-07a71d8cb145", "BIH", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "amir@digitalbim.academy", true, "Founder", "Amir", 0, 1, "Sivic", false, null, null, "AMIR@DIGITALBIM.ACADEMY", "AMIRBIM", false, "AQAAAAEAACcQAAAAEGN6v4MkGaM0HGLN3YVuWHtr/ZyGTscvWtLDLY3o4kHjmcq7RUg5b4hiZ/malTcBfw==", null, false, "47a9e07e-d491-44d4-adb5-8f67f57b7dec", false, "amirBim" },
                    { 2L, 0, 0, 201, null, null, "5a78cd9d-b6be-4667-b7ef-ca7952338a8a", "BIH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019), "cekic.edin@hotmail.com", true, "Developer", "Edin", 0, 1, "Cekic", false, null, null, "CEKIC.EDIN@HOTMAIL.COM", "EDINBIM", false, "AQAAAAEAACcQAAAAEGN6v4MkGaM0HGLN3YVuWHtr/ZyGTscvWtLDLY3o4kHjmcq7RUg5b4hiZ/malTcBfw==", null, false, "8aeae5f0-3d3a-4bdc-ae7b-ab938f2ce449", false, "edinBim" },
                    { 3L, 0, 0, 201, null, null, "1b904309-2663-4c41-ab7e-3f4b86455bca", "BIH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019), "anessljivo@gmail.com", true, "Developer", "Anes", 0, 1, "Sjivo", false, null, null, "ANESSLJIVO@GMAIL.COM", "ANESBIM", false, "AQAAAAEAACcQAAAAEGN6v4MkGaM0HGLN3YVuWHtr/ZyGTscvWtLDLY3o4kHjmcq7RUg5b4hiZ/malTcBfw==", null, false, "8cb5a859-cf06-46eb-b47c-0ca13532fed8", false, "AnesBim" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "df811e72-95fa-4d06-9c3d-0fa7016b1dde", "admin", "ADMIN" },
                    { 2L, "7d575d43-f590-475a-8785-5b88e1776944", "teacher", "TEACHER" },
                    { 3L, "6236fa2c-c5cd-46ed-905f-ced532e5d0de", "company", "COMPANY" },
                    { 4L, "72d2f4e3-08e7-4d26-9c62-0f52b0a8fa63", "member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator" },
                values: new object[,]
                {
                    { 1L, 1L, "IdentityUserRole<long>" },
                    { 1L, 2L, "IdentityUserRole<long>" },
                    { 2L, 1L, "IdentityUserRole<long>" },
                    { 2L, 2L, "IdentityUserRole<long>" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "LanguageId", "PageContent" },
                values: new object[] { 1, 1, @"{
                                                                      ""introTitle"": ""Erfahren Sie mehr über die digitale BIM Academy"",
                                                                      ""introContent"": ""Unsere Mission ist es mit Hilfe von modernen Bildungsansätzen wie Online Education und begleitetem Coaching das komplexe Thema BIM so einfach wie möglich unseren Studenten beizubringen./Wir sind ein Team aus digitalen Enthusiasten,  Dozenten und Experten für BIM. "",
                                                                      ""getEBookBoxContentTitle"": ""Holen Sie sich ein kostenloses eBook 'What is BIM' per E-Mail mit Registrierung!"",
                                                                      ""getEbookButtonLabel"": """",
                    ""aboutBimTitle"": ""Vorteile der digitalen BIM Academy"",
                    ""firstAboutTitle"": ""Effektives, leicht zugängliches und einzigartiges Training"",
                    ""firstAboutContent"": ""Alle unsere Kurse sind rund um die Uhr zugänglich, leicht verständlich und auf dem Markt sehr gefragt.E - Books sind nach jedem Kursmodul enthalten."",
                    ""secondAboutTitle"": ""Wählen Sie zwischen verschiedenen Feldern in der Konstruktion"",
                    ""secondAboutContent"": ""Es gibt verschiedene Kurse zur digitalen BIM - Plattform, die Ihnen alle Fähigkeiten vermitteln, die auf dem Markt dringend benötigt werden."",
                    ""thirdAboutTitle"": ""The most versatile course experience"",
                    ""thirdAboutContent"": ""Engage learners with video interactions, note - taking, interactive ebooks, self - assessment, certificates, SCORM and much more"",
                    ""fourthAboutTitle"": ""Promote the social talk"",
                    ""fourthAboutContent"": ""Engage learners with video interactions, note - taking, interactive ebooks, self - assessment, certificates, SCORM and much more"",
                    ""popularCourseTitle"": ""Die beliebtesten Kurse auf dem Bahnsteig"",
                    ""firstPopularCourseTitle"": ""Revit"",
                    ""firstPopularcourseContent"": """",
                    ""secondPopularCourseTitle"": ""What is BIM ? "",
                                                                      ""secondPopularcourseContent"": """",
                    ""thirdPopularCourseTitle"": ""ArchiCAD"",
                    ""thirdPopularcourseContent"": """",
                    ""investingSectionTitle"": ""It’s time to start investing in yourself!"",
                    ""investingSectionButton"": ""Jetzt starten!"",
                    ""PricingPageTitle"": ""Pricing plans"",
                    ""priceBoxes"": [
                                                                        {
                ""boxTitle"": ""MEMBERSHIP"",
                                                                          ""price"": ""980 CHF"",
                                                                          ""courseContent"": ""Im Preis enthalten: "",
                                                                          ""courseContentListed"": ""Onlinekurse unbegrenzt schauen / Prüfung inkl.Zertifikat zu Onlinekursen / Zugang zur Community Education Plattform/ Möglichkeit an BIM Live - Events teilzunehmen / Rabatt auf Online-Coaching mit unseren Experten""
                                                                        },
                                                                        {
                ""boxTitle"": ""ENTERPRISE"",
                                                                          ""price"": ""8‘900 CHF"",
                                                                          ""courseContent"": ""Im Preis enthalten: "",
                                                                          ""courseContentListed"": ""Das komplette Membership - Paket / Firmeninterner Bereich für Dateien und Firmenlernvideos(bis 100 GB inkl.) / Floating - Lizenz - Modell, bezahlt wird nur die Anzahl die gebraucht wird/ Exklusiver Zugang zum Bereich 'BIM - Jobs' für die Talentsuche / Möglichkeit Lernvideos durch das Team DBA produzieren zu lassen""
                                                                        },
                                                                        {
                ""boxTitle"": ""BIM 5D MASTER"",
                                                                          ""price"": ""9‘800 CHF"",
                                                                          ""courseContent"": ""Im Preis enthalten: "",
                                                                          ""courseContentListed"": ""Das komplette Membership - Paket / Onlinevorlesungen / Begleitetes Coaching durch unsere Experten/ BIM 5D Live Event/ Master - Diplom BIM 5D der digital BIM academy""
                                                                        }
                                                                      ],
                                                                      ""academyMembersTitle"": ""Unsere Academy members arbeiten bei: "",
                                                                      ""aboutUsPageTitle"": ""Unsere Mission"",
                                                                      ""aboutUsStory"": ""Lorem ipsum dolor sit amet, consectetur adipiscing elit.Nunc tincidunt augue non lacus porta, quis aliquam ipsum aliquet.Pellentesque fermentum ex at aliquam pretium. Vestibulum nec elit vitae magna ultricies interdum.Aenean et interdum dolor, vitae elementum mi. Nulla facilisi. Proin pellentesque fermentum velit non rhoncus. Suspendisse in augue ipsum. Fusce tempus scelerisque consequat. Sed iaculis pretium nibh, sit amet mattis nibh blandit at. "",
                                                                      ""teamTitle"": ""Unsere team"",
                                                                      ""teamMemberCard"": """",
                                                                      ""ourValues"": ""Unsere Werte"",
                                                                      ""valueOneTitle"": ""Wir kümmern uns um die Qualität unserer Ausbildung"",
                                                                      ""valueOneContent"": ""Wir haben das wertvollste Wissen gesammelt, um es an Sie weiterzugeben. Nur Fachleute in dieser Branche haben daran gearbeitet, das wichtigste Wissen von BIM zu kombinieren."",
                                                                      ""valueTwoTitle"": ""Wir wollen Ihre Probleme lösen!"",
                                                                      ""valueTwoContent"": ""Die Kurse richten sich speziell an die am meisten benötigten Baufelder auf dem Markt. Dies ist die perfekte Lernplattform, um alle Probleme beim Bauen zu lösen.Die Lehrer sind offen für Fragen."",
                                                                      ""valueThreeTitle"": ""Wir möchten Sie mit Menschen mit ähnlichen Interessen verbinden"",
                                                                      ""valueOneContent"": ""Wenn Sie ein Netzwerk von Menschen mit ähnlichen Interessen und in derselben Branche wie Sie haben möchten, können Sie auf unserer Community-Seite und in unseren Seminaren wertvolle Kontakte und Kunden knüpfen."",
                                                                      ""loginTitle"": ""Anmeldung"",
                                                                      ""rememberMe"": ""Behalte mihc in Erinnerung"",
                                                                      ""resetPassword"": ""Setze mein Passwort zurück"",
                                                                      ""freeRegistration"": ""Noch kein Mitglied? Kostenlos registrieren"",
                                                                      ""registrationTitle"": ""Registrieren Sie sich und starten Sie Ihre digitale BIM - Reise"",
                                                                      """": """",
                                                                      ""occupation"": ""Besetzung: "",
                                                                      ""birthDate"": ""Geburtsdatum: "",
                                                                      ""gender"": ""Geschlecht: "",
                                                                      ""country"": ""Land"",
                                                                      ""password"": ""Passwort: "",
                                                                      ""confirmPassword"": ""Kennwort bestätigen:"",
                                                                      ""registratonButton"": ""Registrieren"",
                                                                      ""userHasAccountMsg"": ""Sie haben bereits ein Konto? Hier anmelden."",
                                                                      ""coursePageTitle"": ""Kurse""
                                                                    }" });

            migrationBuilder.InsertData(
                table: "PlanPrices",
                columns: new[] { "Id", "Currency", "Label", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "chf", "MEMBERSHIP", "membership", 98000 },
                    { 2, "chf", "ENTERPRISE", "enterprise", 890000 },
                    { 3, "chf", "BIM 5D MASTER", "bimMaster", 980000 }
                });

            migrationBuilder.InsertData(
                table: "Navbars",
                columns: new[] { "Id", "Label", "LanguageId", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "Home", 1, "home", 1 },
                    { 2, "Kurse", 1, "courses", 2 },
                    { 3, "Preise", 1, "prices", 3 },
                    { 4, "Gemeinschaft", 1, "community", 4 },
                    { 5, "Team", 1, "about", 5 },
                    { 6, "Kontakt", 1, "contact", 6 }
                });

            migrationBuilder.InsertData(
                table: "UserQuestionTypes",
                columns: new[] { "Id", "QuestionType", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1L },
                    { 2, 1, 1L },
                    { 3, 2, 1L },
                    { 4, 3, 1L },
                    { 5, 0, 2L },
                    { 6, 1, 2L },
                    { 7, 2, 2L },
                    { 8, 3, 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Navbars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Navbars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Navbars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Navbars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Navbars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Navbars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlanPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlanPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlanPrices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserQuestionTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
