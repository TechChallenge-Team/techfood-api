using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechFood.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategorySortOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c3a70938-9e88-437d-a801-c166d2716341"),
                column: "SortOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c65e2cec-bd44-446d-8ed3-a7045cd4876a"),
                column: "SortOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("eaa76b46-2e6b-42eb-8f5d-b213f85f25ea"),
                column: "SortOrder",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("ec2fb26d-99a4-4eab-aa5c-7dd18d88a025"),
                column: "SortOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("090d8eb0-f514-4248-8512-cf0d61a262f0"),
                column: "ImageFileName",
                value: "x-burguer.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("55f32e65-c82f-4a10-981c-cdb7b0d2715a"),
                column: "ImageFileName",
                value: "batata.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86c50c81-c46e-4e79-a591-3b68c75cefda"),
                columns: new[] { "Description", "ImageFileName", "Name" },
                values: new object[] { "Coca-Cola", "coca-cola.png", "Coca-Cola" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("de797d9f-c473-4bed-a560-e7036ca10ab1"),
                columns: new[] { "Description", "ImageFileName", "Name" },
                values: new object[] { "Milk Shake de Morango", "milk-shake-morango.png", "Milk Shake de Morango" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFileName", "Name", "OutOfStock", "Price" },
                values: new object[,]
                {
                    { new Guid("113daae6-f21f-4d38-a778-9364ac64f909"), new Guid("ec2fb26d-99a4-4eab-aa5c-7dd18d88a025"), "Milk Shake de Chocolate", "milk-shake-chocolate.png", "Milk Shake de Chocolate", false, 7.99m },
                    { new Guid("2665c2ec-c537-4d95-9a0f-791bcd4cc938"), new Guid("ec2fb26d-99a4-4eab-aa5c-7dd18d88a025"), "Milk Shake de Baunilha", "milk-shake-baunilha.png", "Milk Shake de Baunilha", false, 7.99m },
                    { new Guid("3249b4e4-11e5-41d9-9d55-e9b1d59bfb23"), new Guid("c65e2cec-bd44-446d-8ed3-a7045cd4876a"), "Crocante Batata Frita", "batata-grande.png", "Batata Frita Grande", false, 12.99m },
                    { new Guid("3c9374f1-58e9-4b07-bdf6-73aa2f4757ff"), new Guid("eaa76b46-2e6b-42eb-8f5d-b213f85f25ea"), "Delicioso X-Bacon", "x-bacon.png", "X-Bacon", false, 22.99m },
                    { new Guid("44c61027-8e16-444d-9f4f-e332410cccaa"), new Guid("c3a70938-9e88-437d-a801-c166d2716341"), "Guaraná", "guarana.png", "Guaraná", false, 4.99m },
                    { new Guid("4aeb3ad6-1e06-418e-8878-e66a4ba9337f"), new Guid("c65e2cec-bd44-446d-8ed3-a7045cd4876a"), "Delicioso Nuggets de Frango", "nuggets.png", "Nuggets de Frango", false, 13.99m },
                    { new Guid("8620cf54-0d37-4aa1-832a-eb98e9b36863"), new Guid("c3a70938-9e88-437d-a801-c166d2716341"), "Sprite", "sprite.png", "Sprite", false, 4.99m },
                    { new Guid("a62dc225-416a-4e36-ba35-a2bd2bbb80f7"), new Guid("eaa76b46-2e6b-42eb-8f5d-b213f85f25ea"), "Delicioso X-Salada", "x-salada.png", "X-Salada", false, 21.99m },
                    { new Guid("bf90f247-52cc-4bbb-b6e3-9c77b6ff546f"), new Guid("c3a70938-9e88-437d-a801-c166d2716341"), "Fanta", "fanta.png", "Fanta", false, 4.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("113daae6-f21f-4d38-a778-9364ac64f909"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2665c2ec-c537-4d95-9a0f-791bcd4cc938"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3249b4e4-11e5-41d9-9d55-e9b1d59bfb23"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3c9374f1-58e9-4b07-bdf6-73aa2f4757ff"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("44c61027-8e16-444d-9f4f-e332410cccaa"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4aeb3ad6-1e06-418e-8878-e66a4ba9337f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8620cf54-0d37-4aa1-832a-eb98e9b36863"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a62dc225-416a-4e36-ba35-a2bd2bbb80f7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("bf90f247-52cc-4bbb-b6e3-9c77b6ff546f"));

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("090d8eb0-f514-4248-8512-cf0d61a262f0"),
                column: "ImageFileName",
                value: "lanche-carnes.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("55f32e65-c82f-4a10-981c-cdb7b0d2715a"),
                column: "ImageFileName",
                value: "bebida-gelada.png");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("86c50c81-c46e-4e79-a591-3b68c75cefda"),
                columns: new[] { "Description", "ImageFileName", "Name" },
                values: new object[] { "Gelado Refrigerante", "bebida-gelada.png", "Refrigerante" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("de797d9f-c473-4bed-a560-e7036ca10ab1"),
                columns: new[] { "Description", "ImageFileName", "Name" },
                values: new object[] { "Doce Pudim", "bebida-gelada.png", "Pudim" });
        }
    }
}
