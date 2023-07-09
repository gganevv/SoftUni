using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class idkwtfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ad22104-c34f-495c-9d00-d5694373bcc9", "AQAAAAEAACcQAAAAEEqL/sv2n/RL7L9uFeR/DlfK8ZOeiQMtVJb+DG2bnoiK3yRojqYpBijo++ln9x/HTQ==", "014bc656-eabd-4467-bb5e-63ed3a9d6705" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecf46292-ebaf-48b0-92b5-b65a888c2e32", "AQAAAAEAACcQAAAAEPJNB7y1BNO7N401gbzn8C2eXYq3zdOrdz1w2Co0OWCDHaXglKoPTIAWwrd8R8vg9Q==", "6a63311f-e8f6-4bdc-bcb4-a1fbac1a31c2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
