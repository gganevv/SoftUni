using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class idkwtf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15a6636d-674a-4ffa-8b25-6d0add515d73", "AQAAAAEAACcQAAAAENev14Sa+PQxze7AsCmIDLbURPBex6uA7Db3xszCECdGvbiCs5CswjJXVSazpvAhoQ==", "919f6663-01ae-4cae-95a4-268ce643748b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b3a1ca6-1418-4797-96fb-e7ba4886686e", "AQAAAAEAACcQAAAAEBK2ndXSKvzY8KEn3ZRmt3/ksGTlHy7B4R5p2i5oRXarSzbcRXU49PtfijOPSJfDbw==", "2938cfab-cfb5-4dde-85e1-722ee2c6b087" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
