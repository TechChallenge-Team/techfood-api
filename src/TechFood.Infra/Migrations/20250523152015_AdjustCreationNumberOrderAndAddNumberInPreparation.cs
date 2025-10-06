using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFood.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustCreationNumberOrderAndAddNumberInPreparation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Preparation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Preparation");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("d1b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"),
                column: "Number",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("f2b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"),
                column: "Number",
                value: 2);
        }
    }
}
