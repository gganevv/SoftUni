using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e9cfa9f6-c80a-4525-838c-5b3cacb45aa7", 0, "ae24ed1d-ae53-46c8-9f5c-416c33fb36ae", null, false, false, null, null, "TEST@ABV.BG", "AQAAAAEAACcQAAAAEJwJ3KLEEkGlF2vB0+Q8MEGBatSJAuTOX6PdmwnyOYJRii10Z9UlCj8kq/+ByLr1IQ==", null, false, "32b4584d-900c-475c-be32-50cbd5b85a82", false, "test@abv.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 22, 22, 58, 28, 512, DateTimeKind.Local).AddTicks(4918), "Implenet better styling for all public pages", "e9cfa9f6-c80a-4525-838c-5b3cacb45aa7", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 1, 10, 22, 58, 28, 512, DateTimeKind.Local).AddTicks(5021), "Create Android client app for the TaskBoard RESTful API", "e9cfa9f6-c80a-4525-838c-5b3cacb45aa7", "Android Client App" },
                    { 3, 2, new DateTime(2023, 5, 10, 22, 58, 28, 512, DateTimeKind.Local).AddTicks(5045), "Create Windows Forms desktop client app for the TaskBoard RESTful API", "e9cfa9f6-c80a-4525-838c-5b3cacb45aa7", "Desktop Client App" },
                    { 4, 3, new DateTime(2022, 6, 10, 22, 58, 28, 512, DateTimeKind.Local).AddTicks(5060), "Implenet [Create Task] page for adding new tasks", "e9cfa9f6-c80a-4525-838c-5b3cacb45aa7", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9cfa9f6-c80a-4525-838c-5b3cacb45aa7");
        }
    }
}
