using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelebioBackend.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    username = table.Column<string>(maxLength: 50, nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    surname = table.Column<string>(maxLength: 255, nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<int>(nullable: false),
                    bio = table.Column<string>(maxLength: 255, nullable: true),
                    gender = table.Column<string>(maxLength: 10, nullable: true),
                    age = table.Column<int>(nullable: false),
                    nationality = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    tripID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    from = table.Column<string>(maxLength: 255, nullable: false),
                    to = table.Column<string>(maxLength: 255, nullable: false),
                    vehicle = table.Column<string>(maxLength: 10, nullable: false),
                    time = table.Column<DateTime>(nullable: false),
                    isOpen = table.Column<bool>(nullable: false),
                    creatorID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip", x => x.tripID);
                    table.ForeignKey(
                        name: "FK_trip_user_creatorID",
                        column: x => x.creatorID,
                        principalTable: "user",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "traveller",
                columns: table => new
                {
                    travellerID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    isAccepted = table.Column<bool>(nullable: false),
                    appliedUser = table.Column<string>(nullable: true),
                    appliedTripID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traveller", x => x.travellerID);
                    table.ForeignKey(
                        name: "FK_traveller_trip_appliedTripID",
                        column: x => x.appliedTripID,
                        principalTable: "trip",
                        principalColumn: "tripID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_traveller_user_appliedUser",
                        column: x => x.appliedUser,
                        principalTable: "user",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "username", "age", "bio", "email", "gender", "name", "nationality", "password", "surname" },
                values: new object[] { "mrtmr", 0, null, "murat@gmail.com", null, "murat emir", null, 123456, "cabarolu" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "username", "age", "bio", "email", "gender", "name", "nationality", "password", "surname" },
                values: new object[] { "edac", 0, null, "murat@gmail.com", null, "eda", null, 123456, "cicekli" });

            migrationBuilder.InsertData(
                table: "trip",
                columns: new[] { "tripID", "creatorID", "from", "isOpen", "time", "to", "vehicle" },
                values: new object[] { 1, "mrtmr", "istanbul", false, new DateTime(2019, 1, 13, 0, 47, 31, 935, DateTimeKind.Local).AddTicks(9873), "izmir", "otostop" });

            migrationBuilder.InsertData(
                table: "traveller",
                columns: new[] { "travellerID", "appliedTripID", "appliedUser", "isAccepted" },
                values: new object[] { 1, 1, "mrtmr", false });

            migrationBuilder.CreateIndex(
                name: "IX_traveller_appliedTripID",
                table: "traveller",
                column: "appliedTripID");

            migrationBuilder.CreateIndex(
                name: "IX_traveller_appliedUser",
                table: "traveller",
                column: "appliedUser");

            migrationBuilder.CreateIndex(
                name: "IX_trip_creatorID",
                table: "trip",
                column: "creatorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "traveller");

            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
