using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MariaWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eintrag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EintragInhalt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eintrag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PLZ = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    eMail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Beschreibung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrganCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vorname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Strasse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PLZ = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eMail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Bemerkung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PersonCategory = table.Column<int>(type: "int", nullable: false),
                    OrganId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Organ_OrganId",
                        column: x => x.OrganId,
                        principalTable: "Organ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person_Eintrag",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    EintragId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Eintrag", x => new { x.PersonId, x.EintragId });
                    table.ForeignKey(
                        name: "FK_Person_Eintrag_Eintrag_EintragId",
                        column: x => x.EintragId,
                        principalTable: "Eintrag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Eintrag_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_OrganId",
                table: "Person",
                column: "OrganId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Eintrag_EintragId",
                table: "Person_Eintrag",
                column: "EintragId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person_Eintrag");

            migrationBuilder.DropTable(
                name: "Eintrag");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Organ");
        }
    }
}
