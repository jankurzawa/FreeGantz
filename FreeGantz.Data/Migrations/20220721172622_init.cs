using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreeGantz.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationHour = table.Column<int>(type: "int", nullable: false),
                    NameOfClient = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "Email", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("92c293a4-3fbc-4b4a-9a83-0c2ff4687f8d"), "dupa", "dupa", "dupa" },
                    { new Guid("ab5034b7-dd76-4a08-a56e-5012d8b2c388"), "admin", "admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Description", "Size" },
                values: new object[,]
                {
                    { new Guid("32bdff0d-5f4f-4079-8486-aa8a21267abf"), "A slightly hidden table for noisy groups", 5 },
                    { new Guid("47ac1cde-36b6-456b-b76e-78133af83b94"), "charming table perfect for couples", 2 },
                    { new Guid("5518d460-a1c5-4013-a233-e8029c550e67"), "special table in the basement", 8 },
                    { new Guid("70ec1cae-e563-439c-86cc-db9d6c2e3774"), "a large table in the middle of the premises", 7 },
                    { new Guid("7c41d004-47e7-42a4-9e30-bb53da264c13"), "small table in front of the window", 1 },
                    { new Guid("83eb4b02-3050-4890-a351-c64edaad9b5d"), "A table at the entrance, provides an additional poking experience", 4 },
                    { new Guid("bfd3051a-06d1-4668-b8b8-49f3590a26f1"), "triangular table next to the toilet", 3 },
                    { new Guid("c3f7e0ea-3159-42f4-8088-562d181b664e"), "large outdoor table near the kitchen", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
