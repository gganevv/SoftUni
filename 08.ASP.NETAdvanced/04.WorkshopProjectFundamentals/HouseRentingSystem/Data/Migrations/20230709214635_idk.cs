using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dabc36ae-0e44-4f90-affb-50927193f74d", "AQAAAAEAACcQAAAAEH97cSBDL7EpVmD2xsT5tgdyKVBwwoiG6Qmaw6BsPUeY810/qZY7iq/Zr3HDpBooPQ==", "b6fbda28-d45c-4042-a9a6-3cd3e8f5a522" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edd44cf5-898f-48be-8d50-05e6348087e0", "AQAAAAEAACcQAAAAEJ4IyI+MehMSmLUadYVxPhruR5DiPDslQBKDYN/2kcNKzM0mSfFRccj+PywLnIO4mg==", "aaf266df-1f5e-4cd6-88f9-05be20df774a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86c2fb7e-2020-463c-b7b7-3a3e3a6600c1", "AQAAAAEAACcQAAAAEC4sncDLnFCMCvf6D8l4p9QZ1BZEGVLIvPWgFYmsTyHZPoORwyzP/ShuQKaUOJlxUw==", "7be04655-1120-42c9-8d9b-594afc75422d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "241a39d4-9873-45f9-bd51-8eabb25a3cd7", "AQAAAAEAACcQAAAAEAfryu1LCEmehxF+Btl/elhGsTAh6/Oll/R5wAbqwKbwu/phkpMdd5IwxQ8g/0VgTA==", "dee9e6c4-eac7-4f01-a22f-f5fb72d55e2a" });
        }
    }
}
