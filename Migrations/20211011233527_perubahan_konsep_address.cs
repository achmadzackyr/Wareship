using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class perubahan_konsep_address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "City",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "Subdistrict",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "Subdistrict",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "Subdistrict",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Subdistrict",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Warehouse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Shipper",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Consignee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubdistrictId = table.Column<int>(type: "int", nullable: false),
                    Subdistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddress_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "CityId", "Name", "Phone", "Province", "ProvinceId", "Street", "Subdistrict", "SubdistrictId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Kabupaten Ciamis", 3207, "Admin Suradmin", "085223670378", "Jawa Barat", 32, "Dusun Desa, Desa Cijeungjing", "Cijeungjing", 3207150, "46271" },
                    { 2, "Kota Tasikmalaya", 3278, "Warehouse JNE Tasikmalaya", "", "Jawa Barat", 32, "Jl. Ir. H. Juanda No.21, RW.1, Cipedes", "Cipedes", 3278080, "46151" }
                });

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

            migrationBuilder.InsertData(
                table: "UserAddress",
                columns: new[] { "Id", "AddressId", "Role", "UserId" },
                values: new object[] { 1, 1, "Rumah", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "UserAddress",
                columns: new[] { "Id", "AddressId", "Role", "UserId" },
                values: new object[] { 2, 1, "Kantor", "supplier-6340-4840-95c2-db12554843e5" });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_AddressId",
                table: "Warehouse",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipper_AddressId",
                table: "Shipper",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consignee_AddressId",
                table: "Consignee",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_AddressId",
                table: "UserAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserId",
                table: "UserAddress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consignee_Address_AddressId",
                table: "Consignee",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipper_Address_AddressId",
                table: "Shipper",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Address_AddressId",
                table: "Warehouse",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consignee_Address_AddressId",
                table: "Consignee");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipper_Address_AddressId",
                table: "Shipper");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Address_AddressId",
                table: "Warehouse");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_AddressId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Shipper_AddressId",
                table: "Shipper");

            migrationBuilder.DropIndex(
                name: "IX_Consignee_AddressId",
                table: "Consignee");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Shipper");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Consignee");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subdistrict",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Shipper",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shipper",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Shipper",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Shipper",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Shipper",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subdistrict",
                table: "Shipper",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Shipper",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Consignee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Consignee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Consignee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Consignee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Consignee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subdistrict",
                table: "Consignee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Consignee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subdistrict",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "City", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Province", "SecurityStamp", "Street", "Subdistrict" },
                values: new object[] { "Kabupaten Ciamis", "84b3f356-5d46-461e-9fd9-633f1fbe3709", new DateTime(2021, 9, 22, 20, 50, 53, 233, DateTimeKind.Local).AddTicks(5547), "AQAAAAEAACcQAAAAEESZcg8OlknXEKfZOoWX0xowJh2bCO8gYrxJvUq5dWYgn2GTWKub+kke+SZkCQ8coQ==", "Jawa Barat", "fefed367-7a94-4475-a22e-847c3dcb7561", "Dusun Desa, Desa Cijeungjing", "Cijeungjing" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "City", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "Province", "SecurityStamp", "Street", "Subdistrict" },
                values: new object[] { "Kabupaten Ciamis", "c093e816-a80f-49be-91ef-0929aff9d597", new DateTime(2021, 9, 22, 20, 50, 53, 275, DateTimeKind.Local).AddTicks(1521), "AQAAAAEAACcQAAAAEMSowM6iZbmzPj5ioV6tkNfdVyDqeWFIJFMeNF69LqC6oJVLVwCRHwXRWHG07nygmQ==", "Jawa Barat", "7359160e-aefc-4121-b6fa-c9736a42d6ec", "Dusun Desa, Desa Cijeungjing", "Cijeungjing" });

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

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "City", "Name", "Phone", "Province", "Street", "Subdistrict", "ZipCode" },
                values: new object[] { 1, "Kota Tasikmalaya", "Warehouse JNE Tasikmalaya", "", "Jawa Barat", "Jl. Ir. H. Juanda No.21, RW.1, Cipedes", "Cipedes", "46151" });
        }
    }
}
