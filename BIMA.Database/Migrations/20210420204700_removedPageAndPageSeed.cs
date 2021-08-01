using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace BIMA.Database.Migrations
{
    public partial class removedPageAndPageSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    PageContent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
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
        }
    }
}
