using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNUnit.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssembliesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssembliesHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoadAssemblies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadAssemblies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IgnoreReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssemblyViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestViewModel_AssembliesHistory_AssemblyViewModelId",
                        column: x => x.AssemblyViewModelId,
                        principalTable: "AssembliesHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestViewModel_AssemblyViewModelId",
                table: "TestViewModel",
                column: "AssemblyViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadAssemblies");

            migrationBuilder.DropTable(
                name: "TestViewModel");

            migrationBuilder.DropTable(
                name: "AssembliesHistory");
        }
    }
}
