using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class tambah_subdistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubDistrict",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegencyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDistrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDistrict_Regencies_RegencyId",
                        column: x => x.RegencyId,
                        principalTable: "Regencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e81f2ce4-2463-453d-bf4b-0adfccd3f14d", new DateTime(2021, 10, 26, 21, 50, 23, 920, DateTimeKind.Local).AddTicks(6448), "AQAAAAEAACcQAAAAEODP8v2y2pePlbS4GJj96UxgXJkHKwIEHUlnmJFSAlV1MRSi0Zt6EcxNuVMOQAWcVA==", "6b1b1d2c-8302-4d8c-a48f-9e4eb692d544" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e02f2998-1b20-401f-951f-105393567ccd", new DateTime(2021, 10, 26, 21, 50, 23, 938, DateTimeKind.Local).AddTicks(4055), "AQAAAAEAACcQAAAAEGor3tFfMAqRpOr3dV2jJwyt7eZAQyFWxefXGuWWre2Zhl+FpvR1YiXTCPwSfhDAsQ==", "0bdd7b29-b52e-445d-9e84-549f0fc9f0cc" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 951, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(489));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 50, 23, 952, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 26, 21, 50, 23, 949, DateTimeKind.Local).AddTicks(5505), new DateTime(2021, 10, 26, 21, 50, 23, 949, DateTimeKind.Local).AddTicks(5952) });

            migrationBuilder.CreateIndex(
                name: "IX_SubDistrict_RegencyId",
                table: "SubDistrict",
                column: "RegencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubDistrict");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c96e877f-36bd-45ad-b80e-2c303436fbe9", new DateTime(2021, 10, 26, 21, 18, 17, 281, DateTimeKind.Local).AddTicks(5114), "AQAAAAEAACcQAAAAEL7zTQSJPP1NcLLkSvz7fgCT9i1jDkeXqWtU0Dcmr6+jvdoK0FBY0MjKL7ygfLRj4Q==", "c4e3078a-3c5a-43c6-9c8c-20848c67fe07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae1cb205-07bd-4935-b538-bedba4d927b5", new DateTime(2021, 10, 26, 21, 18, 17, 297, DateTimeKind.Local).AddTicks(1947), "AQAAAAEAACcQAAAAEHhK5d65wPnIQeBjSTi0PSqoaduj98fmFdSgxXuMEZ7nooyvSBRqWTxpg3YZixt5rQ==", "2d94e469-1a36-4771-85a7-fb633de1dffb" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 310, DateTimeKind.Local).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 18, 17, 311, DateTimeKind.Local).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 26, 21, 18, 17, 308, DateTimeKind.Local).AddTicks(7585), new DateTime(2021, 10, 26, 21, 18, 17, 308, DateTimeKind.Local).AddTicks(8036) });
        }
    }
}
