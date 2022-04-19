using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class elemenkatana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Elemens",
                columns: table => new
                {
                    ElemenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemens", x => x.ElemenId);
                });

            migrationBuilder.CreateTable(
                name: "Katanas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForgedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katanas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Katanas_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElemenKatanas",
                columns: table => new
                {
                    ElemenId = table.Column<int>(type: "int", nullable: false),
                    KatanaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElemenKatanas", x => new { x.ElemenId, x.KatanaId });
                    table.ForeignKey(
                        name: "FK_ElemenKatanas_Elemens_ElemenId",
                        column: x => x.ElemenId,
                        principalTable: "Elemens",
                        principalColumn: "ElemenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElemenKatanas_Katanas_KatanaId",
                        column: x => x.KatanaId,
                        principalTable: "Katanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElemenKatanas_KatanaId",
                table: "ElemenKatanas",
                column: "KatanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Katanas_SamuraiId",
                table: "Katanas",
                column: "SamuraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElemenKatanas");

            migrationBuilder.DropTable(
                name: "Elemens");

            migrationBuilder.DropTable(
                name: "Katanas");

        }
    }
}
