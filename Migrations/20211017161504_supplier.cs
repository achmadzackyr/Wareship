using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductStatus_ProductStatusId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_SubCategory_SubCategoryId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Markup = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_UserStatus_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "CityId", "Name", "Phone", "Province", "ProvinceId", "Street", "Subdistrict", "SubdistrictId", "ZipCode" },
                values: new object[] { 8, "Kabupaten Ciamis", 3207, "Amazaki", "085223670378", "Jawa Barat", 32, "Dusun Desa, Desa Cijeungjing", "Cijeungjing", 3207150, "46271" });

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

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "AddressId", "Brand", "CreatedAt", "CreatedById", "Markup", "SubCategoryId", "UpdatedAt", "UserStatusId" },
                values: new object[] { 1, 8, "Amazaki", new DateTime(2021, 10, 17, 23, 15, 3, 509, DateTimeKind.Local).AddTicks(3065), "b74ddd14-6340-4840-95c2-db12554843e5", 20.0, 1, new DateTime(2021, 10, 17, 23, 15, 3, 509, DateTimeKind.Local).AddTicks(3606), 1 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "SupplierId", "UserId" },
                values: new object[] { 1, "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CreatedById",
                table: "Supplier",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SubCategoryId",
                table: "Supplier",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_UserStatusId",
                table: "Supplier",
                column: "UserStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductStatus_ProductStatusId",
                table: "Product",
                column: "ProductStatusId",
                principalTable: "ProductStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SubCategory_SubCategoryId",
                table: "Product",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductStatus_ProductStatusId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_SubCategory_SubCategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Product_SupplierId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e6d7bce-b7d3-4cba-9a4b-bc6d9dbeecb6", new DateTime(2021, 10, 12, 11, 19, 46, 902, DateTimeKind.Local).AddTicks(107), "AQAAAAEAACcQAAAAEBo4Wd+VkXMdUmuwrknyeGpZ7I6Sj7me19QjH+kbKe5sRlPfCpX4U9Z6eqDq5G1Jyw==", "0fc0c778-436d-42ed-83af-6729d22c235f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be4d8cf5-dd58-4582-b24a-4038dfcecd9b", new DateTime(2021, 10, 12, 11, 19, 46, 915, DateTimeKind.Local).AddTicks(5232), "AQAAAAEAACcQAAAAEKZYCVusooDmofTBaCx4c+mKsH9wvMmd+a4Q+uvFee1rRyHbJ4cEDb1QJiLMfhSdfA==", "e5e331f3-d26f-4cde-9b7e-a3be8dd3eb4e" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: "supplier-6340-4840-95c2-db12554843e5");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2021, 10, 12, 11, 19, 46, 925, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductStatus_ProductStatusId",
                table: "Product",
                column: "ProductStatusId",
                principalTable: "ProductStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SubCategory_SubCategoryId",
                table: "Product",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
