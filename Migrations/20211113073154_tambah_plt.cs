using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class tambah_plt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "892edbd6-64dd-4eaa-a33c-6d3ea0f35b0e", new DateTime(2021, 10, 27, 22, 41, 54, 667, DateTimeKind.Local).AddTicks(8502), "AQAAAAEAACcQAAAAEHe8Rxv++FPxeSR3OSVSYPPugBqJjbqMYIcZT7Qrq7ETDshQ1tCZPNkIvkdw5c8bFA==", "1c3366ad-97ec-43ba-9ff4-37d8b39d4c35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edcc3c43-5342-4964-b982-0e5da2363669", new DateTime(2021, 10, 27, 22, 41, 54, 704, DateTimeKind.Local).AddTicks(1684), "AQAAAAEAACcQAAAAEK7mBkwFQH0KtwSHzxaHaMtKmQ25/9QH8lNDbYTaGpB/N/z0kR6ftNWfEj9dQ0HpoQ==", "f40f566c-a1d4-4a27-8656-bf496b69b178" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 27, 22, 41, 54, 716, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 27, 22, 41, 54, 714, DateTimeKind.Local).AddTicks(4150), new DateTime(2021, 10, 27, 22, 41, 54, 714, DateTimeKind.Local).AddTicks(4575) });
        }
    }
}
