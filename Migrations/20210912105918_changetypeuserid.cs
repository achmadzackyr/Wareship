using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wareship.Migrations
{
    public partial class changetypeuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_UserId1",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId1",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_UserId1",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_UserId",
                table: "Product",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_UserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Product_UserId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecfd7440-6d4a-4db0-bb1d-eed4dcbab1b8", new DateTime(2021, 9, 12, 17, 54, 46, 777, DateTimeKind.Local).AddTicks(7991), "AQAAAAEAACcQAAAAEAj1PSJEQB54eAWH/u3sinECvzcXw/Xd20FLpXrTy/6Pc1S6XxNrkiGik71VKo3hiQ==", "5578cd5c-68b0-43ef-bb81-aea2b4501a5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "supplier-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc1c6155-7b10-4c85-9ab2-8529aaabedc1", new DateTime(2021, 9, 12, 17, 54, 46, 791, DateTimeKind.Local).AddTicks(3290), "AQAAAAEAACcQAAAAEL9WfTlgjAxIAJiYUQP2tLfPTwOkT5EXgKncrRxipyL3474LNN3icurYoPo83tQB/g==", "554ec529-f862-4058-bd50-e5bcb823dfda" });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId1",
                table: "Transaction",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId1",
                table: "Product",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_UserId1",
                table: "Product",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId1",
                table: "Transaction",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
