using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class TambahCreateUpdateAtProduk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3f0f3fe-fcc0-4045-a787-4493263a4d5e", new DateTime(2021, 12, 20, 18, 53, 49, 64, DateTimeKind.Local).AddTicks(7513), "AQAAAAEAACcQAAAAEBQiHjFeyRcSK+eXifN2dccnhQEJtQzj0gNDUX9TaD+q94BNE/kpD9qiZQiYMD8XBw==", "b7bd6226-d873-4d09-85ed-3640eae0cb6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b554eb81-8ee4-4ec4-a655-4ff9b7a4cc10", new DateTime(2021, 12, 20, 18, 53, 49, 119, DateTimeKind.Local).AddTicks(6573), "AQAAAAEAACcQAAAAEFEcAT/GAWjOTiBY5r0YIT/91SQKwGo1ASVQqAsfTLOmgFk3HThalMshHbdWuZlsxw==", "00be6a98-138e-4112-a847-8f24e9c0a999" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 165, DateTimeKind.Local).AddTicks(9043), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(1562) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4451), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4489) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4503), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4508) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4516), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4520) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4527), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4531) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4574), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4578) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4585), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4596), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4600) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4607), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4610) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4624), new DateTime(2021, 12, 20, 18, 53, 49, 166, DateTimeKind.Local).AddTicks(4628) });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(7007));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 20, 18, 53, 49, 168, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 20, 18, 53, 49, 159, DateTimeKind.Local).AddTicks(8180), new DateTime(2021, 12, 20, 18, 53, 49, 160, DateTimeKind.Local).AddTicks(188) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "238f4b49-3481-49ad-abb7-cae0ca9fc81c", new DateTime(2021, 11, 13, 14, 31, 53, 715, DateTimeKind.Local).AddTicks(5640), "AQAAAAEAACcQAAAAEKn/UEAwxDD0OlTibzBSu56bgy0aEvTTbMlMWer7D8/Iut42VsGUbtGFmQKkf4Smvg==", "3397da3f-c912-4968-a89b-acb2967c1343" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a581881b-b021-4301-aa7a-c16c98d4912f", new DateTime(2021, 11, 13, 14, 31, 53, 731, DateTimeKind.Local).AddTicks(3859), "AQAAAAEAACcQAAAAEInYnU4kE4vUUWz4qOv0bU5X6Zz/7gHzabUfoENrs2aVZqvDprLnWcn/nvc4aIbmhQ==", "65d9cf06-dd12-4238-b763-626ebc24dd8c" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 13, 14, 31, 53, 744, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 13, 14, 31, 53, 742, DateTimeKind.Local).AddTicks(6744), new DateTime(2021, 11, 13, 14, 31, 53, 742, DateTimeKind.Local).AddTicks(7214) });
        }
    }
}
