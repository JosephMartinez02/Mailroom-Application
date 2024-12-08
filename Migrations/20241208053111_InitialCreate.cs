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
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    unitNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.residentID);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    packageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    postalService = table.Column<string>(type: "TEXT", nullable: false),
                    checkInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    checkOutDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    residentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.packageID);
                    table.ForeignKey(
                        name: "FK_Package_Resident_residentID",
                        column: x => x.residentID,
                        principalTable: "Resident",
                        principalColumn: "residentID");
                });

            migrationBuilder.CreateTable(
                name: "ResidentPackage",
                columns: table => new
                {
                    residentID = table.Column<int>(type: "INTEGER", nullable: false),
                    packageID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentPackage", x => new { x.residentID, x.packageID });
                    table.ForeignKey(
                        name: "FK_ResidentPackage_Package_packageID",
                        column: x => x.packageID,
                        principalTable: "Package",
                        principalColumn: "packageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentPackage_Resident_residentID",
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
                name: "IX_ResidentPackage_packageID",
                table: "ResidentPackage",
                column: "packageID");

            migrationBuilder.CreateIndex(
                name: "IX_Unknown_packageID",
                table: "Unknown",
                column: "packageID");

            migrationBuilder.Sql(@" 
            
INSERT INTO Resident VALUES
(1,'Kittie Mousdall','jamartinez15@buffs.wtamu.edu',101),
(2,'Claudette Rait','jamartinez15@buffs.wtamu.edu',102),
(3,'Eliza Himsworth','jamartinez15@buffs.wtamu.edu',103),
(4,'Emmit Gann','jamartinez15@buffs.wtamu.edu',104),
(5,'Aurlie Pedycan','jamartinez15@buffs.wtamu.edu',105),
(6,'Keriann Kettlesting','jamartinez15@buffs.wtamu.edu',106),
(7,'Fiorenze Iacovuzzi','jamartinez15@buffs.wtamu.edu',107),
(8,'Darlene Gravie','jamartinez15@buffs.wtamu.edu',108),
(9,'Tomasine Challener','jamartinez15@buffs.wtamu.edu',109),
(10,'Dotti Marple','jamartinez15@buffs.wtamu.edu',110),
(11,'Gabriel Tofanelli','jamartinez15@buffs.wtamu.edu',201),
(12,'Aldo Welldrake','jamartinez15@buffs.wtamu.edu',202),
(13,'Ezmeralda Laydon','jamartinez15@buffs.wtamu.edu',203),
(14,'Kale Lendrem','jamartinez15@buffs.wtamu.edu',204),
(15,'Lenard Cubbit','jamartinez15@buffs.wtamu.edu',205),
(16,'Dedie Caddies','jamartinez15@buffs.wtamu.edu',206),
(17,'Nancy Janosevic','jamartinez15@buffs.wtamu.edu',207),
(18,'Layne Whiterod','jamartinez15@buffs.wtamu.edu',208),
(19,'Averell Labusch','jamartinez15@buffs.wtamu.edu',209),
(20,'Gordan Raddon','jamartinez15@buffs.wtamu.edu',210),
(21,'Deloria Johnes','jamartinez15@buffs.wtamu.edu',301),
(22,'Emmett MacIllrick','jamartinez15@buffs.wtamu.edu',302),
(23,'Sanderson Simoncelli','jamartinez15@buffs.wtamu.edu',303),
(24,'Had Hapke','jamartinez15@buffs.wtamu.edu',304),
(25,'Bellina Rodenburgh','jamartinez15@buffs.wtamu.edu',305),
(26,'Portie Searle','jamartinez15@buffs.wtamu.edu',306),
(27,'Ellsworth Richichi','jamartinez15@buffs.wtamu.edu',307),
(28,'Orlando Mattholie','jamartinez15@buffs.wtamu.edu',308),
(29,'Noby Phelp','jamartinez15@buffs.wtamu.edu',309),
(30,'Wilow Caush','jamartinez15@buffs.wtamu.edu',310),
(31,'Hesther Wincom','jamartinez15@buffs.wtamu.edu',401),
(32,'Ferdie Jzhakov','jamartinez15@buffs.wtamu.edu',402),
(33,'Cornelia Burlingham','jamartinez15@buffs.wtamu.edu',403),
(34,'Rochella Childers','jamartinez15@buffs.wtamu.edu',404),
(35,'Jennie Christensen','jamartinez15@buffs.wtamu.edu',405),
(36,'Kalie Cropper','jamartinez15@buffs.wtamu.edu',406),
(37,'Corinne Garrison','jamartinez15@buffs.wtamu.edu',407),
(38,'Maybelle Pigne','jamartinez15@buffs.wtamu.edu',408),
(39,'Wald Kuddyhy','jamartinez15@buffs.wtamu.edu',409),
(40,'Blancha Ambrosoni','jamartinez15@buffs.wtamu.edu',410),
(41,'Gussy Moiser','jamartinez15@buffs.wtamu.edu',501),
(42,'Margette Symcock','jamartinez15@buffs.wtamu.edu',502),
(43,'Cad Stearnes','jamartinez15@buffs.wtamu.edu',503),
(44,'Juliann Sumner','jamartinez15@buffs.wtamu.edu',504),
(45,'Esdras Bresland','jamartinez15@buffs.wtamu.edu',505),
(46,'Alisha Laspee','jamartinez15@buffs.wtamu.edu',506),
(47,'Yvon Jirusek','jamartinez15@buffs.wtamu.edu',507),
(48,'Parrnell Halbeard','jamartinez15@buffs.wtamu.edu',508),
(49,'Korrie Milesap','jamartinez15@buffs.wtamu.edu',509),
(50,'Vivyan Petzold','jamartinez15@buffs.wtamu.edu',510),
(51,'Angie Darben','jamartinez15@buffs.wtamu.edu',101),
(52,'Eachelle Texton','jamartinez15@buffs.wtamu.edu',102),
(53,'Lion Imlaw','jamartinez15@buffs.wtamu.edu',103),
(54,'Delmore Cowhig','jamartinez15@buffs.wtamu.edu',104),
(55,'Shaine Van Kruis','jamartinez15@buffs.wtamu.edu',105),
(56,'Yehudi Jones','jamartinez15@buffs.wtamu.edu',106),
(57,'Hamlen Gerrad','jamartinez15@buffs.wtamu.edu',107),
(58,'Elisabetta Francescozzi','jamartinez15@buffs.wtamu.edu',108),
(59,'Gusti Chinn','jamartinez15@buffs.wtamu.edu',109),
(60,'Candace Hurlston','jamartinez15@buffs.wtamu.edu',110),
(61,'Odey Butter','jamartinez15@buffs.wtamu.edu',201),
(62,'Viva Bolletti','jamartinez15@buffs.wtamu.edu',202),
(63,'Tallie Jubert','jamartinez15@buffs.wtamu.edu',203),
(64,'Mary Vearnals','jamartinez15@buffs.wtamu.edu',204),
(65,'Lona Dunbavin','jamartinez15@buffs.wtamu.edu',205),
(66,'Osmond Bamlett','jamartinez15@buffs.wtamu.edu',206),
(67,'Nomi Sollom','jamartinez15@buffs.wtamu.edu',207),
(68,'Hildy Campana','jamartinez15@buffs.wtamu.edu',208),
(69,'Emmanuel Getcliffe','jamartinez15@buffs.wtamu.edu',209),
(70,'Danette Danieli','jamartinez15@buffs.wtamu.edu',210),
(71,'Jan Witt','jamartinez15@buffs.wtamu.edu',301),
(72,'Woodie Kertess','jamartinez15@buffs.wtamu.edu',302),
(73,'Corine Cleevely','jamartinez15@buffs.wtamu.edu',303),
(74,'Inez Mew','jamartinez15@buffs.wtamu.edu',304),
(75,'Kathie Odd','jamartinez15@buffs.wtamu.edu',305),
(76,'Mitch Friedlos','jamartinez15@buffs.wtamu.edu',306),
(77,'Bambi Gostick','jamartinez15@buffs.wtamu.edu',307),
(78,'Mellicent Roiz','jamartinez15@buffs.wtamu.edu',308),
(79,'Sukey Avon','jamartinez15@buffs.wtamu.edu',309),
(80,'Janina Kernan','jamartinez15@buffs.wtamu.edu',310),
(81,'Jaynell Pitfield','jamartinez15@buffs.wtamu.edu',401),
(82,'Ricki Hoppner','jamartinez15@buffs.wtamu.edu',402),
(83,'Rinaldo Stable','jamartinez15@buffs.wtamu.edu',403),
(84,'Tessy Tabour','jamartinez15@buffs.wtamu.edu',404),
(85,'Helen Ferencz','jamartinez15@buffs.wtamu.edu',405),
(86,'Korney Shakelade','jamartinez15@buffs.wtamu.edu',406),
(87,'Tulley Reiner','jamartinez15@buffs.wtamu.edu',407),
(88,'Myrle Mersh','jamartinez15@buffs.wtamu.edu',408),
(89,'Carina Nelthorp','jamartinez15@buffs.wtamu.edu',409),
(90,'Monte Trahmel','jamartinez15@buffs.wtamu.edu',410),
(91,'Nate Zavattero','jamartinez15@buffs.wtamu.edu',501),
(92,'Neddy Bucky','jamartinez15@buffs.wtamu.edu',502),
(93,'Allissa Collyns','jamartinez15@buffs.wtamu.edu',503),
(94,'Brianna Ruberry','jamartinez15@buffs.wtamu.edu',504),
(95,'Roxane Wellen','jamartinez15@buffs.wtamu.edu',505),
(96,'Ashbey Keddy','jamartinez15@buffs.wtamu.edu',506),
(97,'Elvin Mico','jamartinez15@buffs.wtamu.edu',507),
(98,'Nicolas Hanratty','jamartinez15@buffs.wtamu.edu',508),
(99,'Gary Jochens','jamartinez15@buffs.wtamu.edu',509),
(100,'Alexina Tarbard','jamartinez15@buffs.wtamu.edu',510);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentPackage");

            migrationBuilder.DropTable(
                name: "Unknown");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Resident");

            migrationBuilder.Sql("DELETE FROM Resident;");
        }
    }
}
