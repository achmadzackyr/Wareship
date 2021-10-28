using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class perubahan_tipe_data_address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubdistrictId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CityId",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CityId", "ProvinceId", "SubdistrictId" },
                values: new object[] { "3207", "32", "3207150" });

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CityId", "ProvinceId", "SubdistrictId" },
                values: new object[] { "3278", "32", "3278080" });

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CityId", "ProvinceId", "SubdistrictId" },
                values: new object[] { "3207", "32", "3207150" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubdistrictId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CityId", "ProvinceId", "SubdistrictId" },
                values: new object[] { 3207, 32, 3207150 });

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CityId", "ProvinceId", "SubdistrictId" },
                values: new object[] { 3278, 32, 3278080 });

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CityId", "ProvinceId", "SubdistrictId" },
                values: new object[] { 3207, 32, 3207150 });

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
        }
    }
}
