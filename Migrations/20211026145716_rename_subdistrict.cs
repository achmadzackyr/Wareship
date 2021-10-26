using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class rename_subdistrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubDistrict");

            migrationBuilder.CreateTable(
                name: "SubDistricts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegencyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDistricts_Regencies_RegencyId",
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
                values: new object[] { "80430a79-e234-41aa-88ce-097a49f318e1", new DateTime(2021, 10, 26, 21, 57, 14, 904, DateTimeKind.Local).AddTicks(9294), "AQAAAAEAACcQAAAAEPndYLUfWuYWWNKRReyr7h/5ns8Oyq7QqXMqPWOPK7DawmnKtFwjFDmYnhrIYhxezA==", "8aee49ff-4682-4836-b696-a6675536f051" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4315a720-a821-4490-942a-d245656cf4af", new DateTime(2021, 10, 26, 21, 57, 14, 937, DateTimeKind.Local).AddTicks(6594), "AQAAAAEAACcQAAAAEIQDuBKHNTwd8wCmc6TYfe2chhaWlGuBUbh/1oSaEyRRLJQSAbnyEMc6u5eCKWnFfA==", "6c4b5501-4b1a-41e5-b47b-0f1e58ce2882" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 949, DateTimeKind.Local).AddTicks(9572));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(757));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 21, 57, 14, 950, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 26, 21, 57, 14, 948, DateTimeKind.Local).AddTicks(97), new DateTime(2021, 10, 26, 21, 57, 14, 948, DateTimeKind.Local).AddTicks(554) });

            migrationBuilder.CreateIndex(
                name: "IX_SubDistricts_RegencyId",
                table: "SubDistricts",
                column: "RegencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubDistricts");

            migrationBuilder.CreateTable(
                name: "SubDistrict",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegencyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
    }
}
