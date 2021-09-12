using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class usertransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecfd7440-6d4a-4db0-bb1d-eed4dcbab1b8", new DateTime(2021, 9, 12, 17, 54, 46, 777, DateTimeKind.Local).AddTicks(7991), "AQAAAAEAACcQAAAAEAj1PSJEQB54eAWH/u3sinECvzcXw/Xd20FLpXrTy/6Pc1S6XxNrkiGik71VKo3hiQ==", "5578cd5c-68b0-43ef-bb81-aea2b4501a5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc1c6155-7b10-4c85-9ab2-8529aaabedc1", new DateTime(2021, 9, 12, 17, 54, 46, 791, DateTimeKind.Local).AddTicks(3290), "AQAAAAEAACcQAAAAEL9WfTlgjAxIAJiYUQP2tLfPTwOkT5EXgKncrRxipyL3474LNN3icurYoPo83tQB/g==", "554ec529-f862-4058-bd50-e5bcb823dfda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f23afef9-6bfb-4cd8-a641-7e32de513c38", new DateTime(2021, 9, 12, 17, 48, 41, 333, DateTimeKind.Local).AddTicks(8161), "AQAAAAEAACcQAAAAEDS0g0pwh0j32D4FC4exUPwdut7jdcUiV7wwGfwA/03ObokzEWRI2SsqXZuGqaZcwg==", "69cd6fa0-7614-4837-9ba2-552ee567d019" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db1b54ce-6ce7-44fc-8135-c62bbdb16467", new DateTime(2021, 9, 12, 17, 48, 41, 347, DateTimeKind.Local).AddTicks(3139), "AQAAAAEAACcQAAAAEN+GLsO4fvzESyWk0PX7bb3OATeuUmnoOnqiDNdNic+5KyiuemRZ7cHnyZWnE1UxZQ==", "8094b38c-fa3b-4191-95d9-1a87abb40fbc" });
        }
    }
}
