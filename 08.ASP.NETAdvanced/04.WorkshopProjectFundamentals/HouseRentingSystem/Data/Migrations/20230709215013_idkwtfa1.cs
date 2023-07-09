using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class idkwtfa1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ba83b8d-2ddc-4a32-8322-36b63a3e70d2", "AQAAAAEAACcQAAAAEJtL1OljGYZlpAJQfScXKNJCT58gU9XqmHMSKZR3CLXnvZ+FFemvbef5g5QdEgdnJw==", "dea7ba85-1148-4e00-960d-b015825ea994" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbf5b51c-4af7-419c-b640-543716e4c2cf", "AQAAAAEAACcQAAAAELQz3T327ZZlDoqsagotbO+2N/9mFqZRskaSr7W6RS46Qd4ECAsqMYlJiyPNQurw2A==", "a5b4e446-0857-478b-bc51-e086151d303a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
