using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFood.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c3a70938-9e88-437d-a801-c166d2716341"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c65e2cec-bd44-446d-8ed3-a7045cd4876a"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("eaa76b46-2e6b-42eb-8f5d-b213f85f25ea"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("ec2fb26d-99a4-4eab-aa5c-7dd18d88a025"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("25b58f54-63bc-42da-8cf6-8162097e72c8"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("090d8eb0-f514-4248-8512-cf0d61a262f0"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("113daae6-f21f-4d38-a778-9364ac64f909"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2665c2ec-c537-4d95-9a0f-791bcd4cc938"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3249b4e4-11e5-41d9-9d55-e9b1d59bfb23"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3c9374f1-58e9-4b07-bdf6-73aa2f4757ff"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("44c61027-8e16-444d-9f4f-e332410cccaa"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4aeb3ad6-1e06-418e-8878-e66a4ba9337f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("55f32e65-c82f-4a10-981c-cdb7b0d2715a"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8620cf54-0d37-4aa1-832a-eb98e9b36863"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86c50c81-c46e-4e79-a591-3b68c75cefda"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a62dc225-416a-4e36-ba35-a2bd2bbb80f7"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("bf90f247-52cc-4bbb-b6e3-9c77b6ff546f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("de797d9f-c473-4bed-a560-e7036ca10ab1"),
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");
        }
    }
}
