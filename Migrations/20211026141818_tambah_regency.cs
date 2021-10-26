using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class tambah_regency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Provinces",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Provinces",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Regencies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regencies_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Regencies_ProvinceId",
                table: "Regencies",
                column: "ProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regencies");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Provinces",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Provinces",
                newName: "id");

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
    }
}
