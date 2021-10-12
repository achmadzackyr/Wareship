using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class tambah_price_di_stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Stock",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21781933-522d-4550-bb08-158ff70a1719", new DateTime(2021, 10, 12, 6, 41, 17, 744, DateTimeKind.Local).AddTicks(6190), "AQAAAAEAACcQAAAAEBifXO0mcyiLCSMWUOR7sOYVvbfGM4uQZzoqVvZU5ZFPItug3C4Kdcj9VrhBlGbcdA==", "f34b917d-fc78-4fa3-9190-203c656d414c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f629f9e2-9595-4fb9-8932-fe2a31f26c28", new DateTime(2021, 10, 12, 6, 41, 17, 757, DateTimeKind.Local).AddTicks(7947), "AQAAAAEAACcQAAAAECwbuPI7+BTMBbrggeqGzdLC4eUZlX045U+YxAhQq8GwUHngK/1ho32UG/Mdx4mi6w==", "90452c11-daa0-4471-bdf3-98da7ed8e573" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3982));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3993));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 41, 17, 767, DateTimeKind.Local).AddTicks(3995));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Stock");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d691597-9e30-44ab-952b-2edf8a3575e0", new DateTime(2021, 10, 12, 6, 35, 25, 920, DateTimeKind.Local).AddTicks(1380), "AQAAAAEAACcQAAAAEOj1J9p0l7ns1JPmFZQxZXCEM/EvqXr4osuuFyVSdLvkXZjq9gvJs5iyMW62O7Sqlw==", "0e892ddc-637b-4629-8205-e5eff52d053d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66bc6fa3-3f61-408f-9c71-c4349b2405bf", new DateTime(2021, 10, 12, 6, 35, 25, 936, DateTimeKind.Local).AddTicks(5658), "AQAAAAEAACcQAAAAEOKUI32FMdOVt4gw2wOY8yNeNqFGTjOUBdTDqaqFiQ0eY1a/euP/zgY6zg+De8AtLA==", "5f5497e4-ee52-4dfc-a4de-d2df0aae0b01" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3191));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 6, 35, 25, 946, DateTimeKind.Local).AddTicks(3202));
        }
    }
}
