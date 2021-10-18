using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class tambah_email_supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

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
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 18, 20, 18, 24, 91, DateTimeKind.Local).AddTicks(1480), "digisolutionasia@gmail.com", new DateTime(2021, 10, 18, 20, 18, 24, 91, DateTimeKind.Local).AddTicks(1914) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Supplier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e229c151-81a1-4dc8-9c0f-359b267ab535", new DateTime(2021, 10, 17, 23, 15, 3, 482, DateTimeKind.Local).AddTicks(1962), "AQAAAAEAACcQAAAAEMxvAXLY2/CLt0ajJKp0z9w3t9UnTXYnyy0YFBD7mvXTPIH5BCD/uTgeTamRTyTsQA==", "c469ab1c-c93e-4739-b691-071161b84f56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6258dd05-21d8-43ad-ac65-c5862725fc92", new DateTime(2021, 10, 17, 23, 15, 3, 498, DateTimeKind.Local).AddTicks(3962), "AQAAAAEAACcQAAAAEFoC/Jt7fV02V+NuBQBJOsz1k1EwuBJOBjxZFfciZ/HnTVEgJnAZkehnUe6Jxp3O2g==", "6639ec4f-f1d4-44ba-9817-5273e02e69ac" });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5498));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5507));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5509));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 17, 23, 15, 3, 511, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 17, 23, 15, 3, 509, DateTimeKind.Local).AddTicks(3065), new DateTime(2021, 10, 17, 23, 15, 3, 509, DateTimeKind.Local).AddTicks(3606) });
        }
    }
}
