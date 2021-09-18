using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class seeddangantibahasawarehouseprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Provinsi",
                table: "Warehouse",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Kecamatan",
                table: "Warehouse",
                newName: "Subdistrict");

            migrationBuilder.RenameColumn(
                name: "KabupatenKota",
                table: "Warehouse",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Jalan",
                table: "Warehouse",
                newName: "Province");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Warehouse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ChargeableWeight",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsTrash", "Name", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 10, 0, "Handphone & Tablet", null },
                    { 9, 0, "Gaming", null },
                    { 8, 0, "Film & Musik", null },
                    { 7, 0, "Fashion Wanita", null },
                    { 1, 0, "Buku", null },
                    { 5, 0, "Fashion Muslim", null },
                    { 4, 0, "Fashion Anak & Bayi", null },
                    { 3, 0, "Elektronik", null },
                    { 6, 0, "Fashion Pria", null },
                    { 2, 0, "Dapur", null }
                });

            migrationBuilder.InsertData(
                table: "Courier",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "JNE" });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bank Transfer" },
                    { 2, "Cash on Delivery" },
                    { 3, "Paylater" }
                });

            migrationBuilder.InsertData(
                table: "ProductStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Banned" },
                    { 1, "Active" },
                    { 3, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "TransactionStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Processed" },
                    { 4, "Delivered" },
                    { 5, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Variation",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Warna" },
                    { 1, "Ukuran" }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "City", "Name", "Phone", "Province", "Street", "Subdistrict", "ZipCode" },
                values: new object[] { 1, "Kota Tasikmalaya", "Warehouse JNE Tasikmalaya", "", "Jawa Barat", "Jl. Ir. H. Juanda No.21, RW.1, Cipedes", "Cipedes", "46151" });

            migrationBuilder.InsertData(
                table: "DeliveryService",
                columns: new[] { "Id", "CourierId", "Name" },
                values: new object[,]
                {
                    { 4, 1, "JTR" },
                    { 1, 1, "REG" },
                    { 3, 1, "OKE" },
                    { 2, 1, "YES" }
                });

            migrationBuilder.InsertData(
                table: "Option",
                columns: new[] { "Id", "Name", "VariationId" },
                values: new object[,]
                {
                    { 12, "Kuning", 2 },
                    { 11, "Pink", 2 },
                    { 10, "Biru", 2 },
                    { 9, "Merah", 2 },
                    { 8, "Putih", 2 },
                    { 6, "43", 1 },
                    { 5, "42", 1 },
                    { 4, "41", 1 },
                    { 3, "40", 1 },
                    { 2, "39", 1 },
                    { 1, "38", 1 },
                    { 7, "Hitam", 2 }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "CategoryId", "IsTrash", "Name", "ThumbnailUrl" },
                values: new object[,]
                {
                    { 19, 10, 0, "Handphone", null },
                    { 20, 10, 0, "Tablet", null },
                    { 18, 9, 0, "Game Console", null },
                    { 16, 8, 0, "Gitar & Bass", null },
                    { 2, 1, 0, "Religi & Spiritual", null },
                    { 3, 2, 0, "Peralatan Makan & Minum", null },
                    { 4, 2, 0, "Peralatan Masak", null },
                    { 5, 3, 0, "Alat Pendingin Ruangan", null },
                    { 6, 3, 0, "TV & Aksesoris", null },
                    { 7, 4, 0, "Pakaian Anak Laki-Laki", null },
                    { 17, 9, 0, "CD Game", null },
                    { 8, 4, 0, "Pakaian Anak Perempuan", null },
                    { 10, 5, 0, "Perlengkapan Ibadah", null },
                    { 11, 6, 0, "Batik Pria", null },
                    { 12, 6, 0, "Celana Pria", null },
                    { 13, 7, 0, "Batik Wanita", null },
                    { 14, 7, 0, "Bawahan Wanita", null },
                    { 15, 8, 0, "Film & Serial", null },
                    { 9, 5, 0, "Jilbab", null },
                    { 1, 1, 0, "Kamus", null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "ChargeableWeight", "Description", "Name", "Price", "ProductStatusId", "Sku", "SubCategoryId", "UserId", "Volume", "Weight" },
                values: new object[,]
                {
                    { 1, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A001", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 2, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A002", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 3, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A003", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 4, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A004", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 5, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A005", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 6, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A006", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 7, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A007", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 8, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A008", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 9, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A009", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 },
                    { 10, 1.0, "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya", "Kamus Bahasa Inggris 1 Juta Kata", 100000.0, 1, "A0010", 1, "supplier-6340-4840-95c2-db12554843e5", 1.0, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(6842), 1, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 2, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9516), 2, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 3, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9534), 3, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 4, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9537), 4, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 5, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9539), 5, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 6, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9549), 6, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 7, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9552), 7, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 8, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9554), 8, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 9, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9557), 9, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" },
                    { 10, new DateTime(2021, 9, 14, 21, 31, 1, 40, DateTimeKind.Local).AddTicks(9561), 10, "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryService",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryService",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryService",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryService",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Option",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Variation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Variation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "City",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "ChargeableWeight",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Warehouse",
                newName: "Provinsi");

            migrationBuilder.RenameColumn(
                name: "Subdistrict",
                table: "Warehouse",
                newName: "Kecamatan");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Warehouse",
                newName: "KabupatenKota");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Warehouse",
                newName: "Jalan");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d7c9c24-2291-4855-aed0-9ad2b8129ea7", new DateTime(2021, 9, 12, 17, 59, 18, 83, DateTimeKind.Local).AddTicks(6688), "AQAAAAEAACcQAAAAEP+NbK9rdwrM8a7oG1hKlUqso9gCEf7R+g+lrwVTxPTJAIb/PuhF3nwqySoY7XyVmg==", "bca923cb-bcc2-422b-a197-ba8db30aa006" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "362594e5-7ae2-43aa-9073-97517bd72879", new DateTime(2021, 9, 12, 17, 59, 18, 97, DateTimeKind.Local).AddTicks(878), "AQAAAAEAACcQAAAAEDq+Z1Hp+XXw2eYsey3Bc5Gjn3XIUqTNYnQ4PB5Zxyz1EdkuYgO7qnVUhWYCZtM7BQ==", "e8154c6c-b7c5-4235-a3c4-a16d876567cb" });
        }
    }
}
