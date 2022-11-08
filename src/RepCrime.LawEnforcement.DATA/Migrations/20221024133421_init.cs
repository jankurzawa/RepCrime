using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepCrime.LawEnforcement.DATA.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LawEnforcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawEnforcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignCrimes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LawEnforcementEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignCrimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignCrimes_LawEnforcements_LawEnforcementEntityId",
                        column: x => x.LawEnforcementEntityId,
                        principalTable: "LawEnforcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LawEnforcements",
                columns: new[] { "Id", "Rank" },
                values: new object[] { new Guid("18d9ee8a-ff1b-4e26-b0df-e621c12a6334"), 0 });

            migrationBuilder.InsertData(
                table: "LawEnforcements",
                columns: new[] { "Id", "Rank" },
                values: new object[] { new Guid("220029c5-c7ed-4d9d-b173-5e846a06b9dd"), 2 });

            migrationBuilder.InsertData(
                table: "LawEnforcements",
                columns: new[] { "Id", "Rank" },
                values: new object[] { new Guid("ef031c7f-b012-4af6-bb0b-8a456accc226"), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AssignCrimes_LawEnforcementEntityId",
                table: "AssignCrimes",
                column: "LawEnforcementEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignCrimes");

            migrationBuilder.DropTable(
                name: "LawEnforcements");
        }
    }
}
