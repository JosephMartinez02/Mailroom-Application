using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailroomApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resident",
                columns: table => new
                {
                    residentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    residentName = table.Column<string>(type: "TEXT", nullable: false),
                    unitNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.residentID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    staffID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.staffID);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    packageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    postalService = table.Column<string>(type: "TEXT", nullable: true),
                    checkInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    checkOutDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true),
                    residentName = table.Column<string>(type: "TEXT", nullable: true),
                    unitNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    residentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.packageID);
                    table.ForeignKey(
                        name: "FK_Package_Resident_residentID",
                        column: x => x.residentID,
                        principalTable: "Resident",
                        principalColumn: "residentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unknown",
                columns: table => new
                {
                    unknownID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    packageID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unknown", x => x.unknownID);
                    table.ForeignKey(
                        name: "FK_Unknown_Package_packageID",
                        column: x => x.packageID,
                        principalTable: "Package",
                        principalColumn: "packageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_residentID",
                table: "Package",
                column: "residentID");

            migrationBuilder.CreateIndex(
                name: "IX_Unknown_packageID",
                table: "Unknown",
                column: "packageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Unknown");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Resident");
        }
    }
}
