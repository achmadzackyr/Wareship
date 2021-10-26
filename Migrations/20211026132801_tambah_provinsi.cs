using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class tambah_provinsi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c4c6134-702b-4a84-a0f4-ab9fe91fde9a", new DateTime(2021, 10, 26, 20, 28, 0, 416, DateTimeKind.Local).AddTicks(6363), "AQAAAAEAACcQAAAAEJ2SduSjC1ISYWV+oa7ZdlubTyePDn2mRfArxJabcvJBqc8+nKdkycFJuULfUJC5gA==", "515c1e9e-41d9-4b8e-93fc-4745ec41e1e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33deb652-3876-43fd-83c8-d41fe2a30fb9", new DateTime(2021, 10, 26, 20, 28, 0, 430, DateTimeKind.Local).AddTicks(814), "AQAAAAEAACcQAAAAEFekyeSBrEEOKXEc2cTaSvL72R+7YlKqCvl35pFByzEwMT8IvvlSuelX7tEhYR6QKw==", "6dc74936-9df2-4bc6-bff5-18961eeafc48" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1441));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 26, 20, 28, 0, 442, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 26, 20, 28, 0, 440, DateTimeKind.Local).AddTicks(2891), new DateTime(2021, 10, 26, 20, 28, 0, 440, DateTimeKind.Local).AddTicks(3330) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2727395b-359a-4403-8f29-0411b28948ff", new DateTime(2021, 10, 18, 20, 18, 24, 67, DateTimeKind.Local).AddTicks(7257), "AQAAAAEAACcQAAAAEMiwMwhqT9zMMWB57EPU6BDrZ3vzblKOzF/R7vJUgEMP7sZgPfHXujbnoPsZVFD8VQ==", "384f4c44-a6b8-4a4d-87ff-3b2de5b6dece" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "046df212-b9e1-4c37-b8ea-b42ec5512ee8", new DateTime(2021, 10, 18, 20, 18, 24, 81, DateTimeKind.Local).AddTicks(298), "AQAAAAEAACcQAAAAEIsYZOIz2aTblCMxOCbl6jFIxCNWPTqcbemH180Rqtw9xhqXz+pYM9Z0repzs5rW9w==", "26fbf675-246d-4c73-9102-8b081ed255aa" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 92, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 18, 20, 18, 24, 93, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 18, 20, 18, 24, 91, DateTimeKind.Local).AddTicks(1480), new DateTime(2021, 10, 18, 20, 18, 24, 91, DateTimeKind.Local).AddTicks(1914) });
        }
    }
}
