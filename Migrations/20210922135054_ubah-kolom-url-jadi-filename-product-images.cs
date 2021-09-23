using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class ubahkolomurljadifilenameproductimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ProductImage",
                newName: "Filename");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84b3f356-5d46-461e-9fd9-633f1fbe3709", new DateTime(2021, 9, 22, 20, 50, 53, 233, DateTimeKind.Local).AddTicks(5547), "AQAAAAEAACcQAAAAEESZcg8OlknXEKfZOoWX0xowJh2bCO8gYrxJvUq5dWYgn2GTWKub+kke+SZkCQ8coQ==", "fefed367-7a94-4475-a22e-847c3dcb7561" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c093e816-a80f-49be-91ef-0929aff9d597", new DateTime(2021, 9, 22, 20, 50, 53, 275, DateTimeKind.Local).AddTicks(1521), "AQAAAAEAACcQAAAAEMSowM6iZbmzPj5ioV6tkNfdVyDqeWFIJFMeNF69LqC6oJVLVwCRHwXRWHG07nygmQ==", "7359160e-aefc-4121-b6fa-c9736a42d6ec" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7292));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 22, 20, 50, 53, 284, DateTimeKind.Local).AddTicks(7303));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Filename",
                table: "ProductImage",
                newName: "Url");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cb7ecdb-826b-4523-a30d-237d8aa93f5f", new DateTime(2021, 9, 14, 21, 31, 0, 993, DateTimeKind.Local).AddTicks(1823), "AQAAAAEAACcQAAAAEBPDYtnPrGDW7n6CgTTwKsWhjQ2Fyq6AGGFn4o0nBQjk4dwQAAdLsaV74hFhN1jBPg==", "c7cd069e-9e90-46f5-b324-81ab099ce9c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41da727f-050c-4e3a-b499-456a8191b570", new DateTime(2021, 9, 14, 21, 31, 1, 21, DateTimeKind.Local).AddTicks(4818), "AQAAAAEAACcQAAAAEGJiq2W1E37gGMbJIHAXxhjRmRMJQLHs8M8X/YFhAbqK7rZUYDozHQUPYMxzypi3nA==", "1d5ae92e-ec53-49e3-bc98-78cf76611ac1" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9561));
        }
    }
}
