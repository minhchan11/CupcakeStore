using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GitTrio.Migrations
{
    public partial class JointTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CupcakesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CupcakeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CupcakesUsers", x => new { x.Id, x.UserId });
                    table.ForeignKey(
                        name: "FK_CupcakesUsers_Cupcakes_CupcakeId",
                        column: x => x.CupcakeId,
                        principalTable: "Cupcakes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CupcakesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CupcakesUsers_CupcakeId",
                table: "CupcakesUsers",
                column: "CupcakeId");

            migrationBuilder.CreateIndex(
                name: "IX_CupcakesUsers_UserId",
                table: "CupcakesUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CupcakesUsers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
