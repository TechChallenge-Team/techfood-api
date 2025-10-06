using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechFood.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "FinishedAt",
                table: "Preparation",
                newName: "ReadyAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Preparation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredAt",
                table: "Preparation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("d1b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("f2b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"),
                column: "Status",
                value: 3);

            migrationBuilder.InsertData(
                table: "Preparation",
                columns: new[] { "Id", "CancelledAt", "CreatedAt", "DeliveredAt", "IsDeleted", "OrderId", "ReadyAt", "StartedAt", "Status" },
                values: new object[,]
                {
                    { new Guid("83874d8f-0bc8-42ab-85d9-540a36dcccf4"), null, new DateTime(2025, 5, 13, 22, 2, 36, 0, DateTimeKind.Utc).AddTicks(6354), null, false, new Guid("f2b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"), null, null, 2 },
                    { new Guid("9b50f871-b829-4085-8ae5-118cd1198fbe"), null, new DateTime(2025, 5, 13, 22, 2, 36, 0, DateTimeKind.Utc).AddTicks(6053), null, false, new Guid("d1b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"), null, null, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Preparation",
                keyColumn: "Id",
                keyValue: new Guid("83874d8f-0bc8-42ab-85d9-540a36dcccf4"));

            migrationBuilder.DeleteData(
                table: "Preparation",
                keyColumn: "Id",
                keyValue: new Guid("9b50f871-b829-4085-8ae5-118cd1198fbe"));

            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Preparation");

            migrationBuilder.DropColumn(
                name: "DeliveredAt",
                table: "Preparation");

            migrationBuilder.RenameColumn(
                name: "ReadyAt",
                table: "Preparation",
                newName: "FinishedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("d1b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"),
                columns: new[] { "FinishedAt", "Status" },
                values: new object[] { null, 5 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("f2b5f3a2-4c8e-4b7c-9f0e-5a2d6f3b8c1e"),
                columns: new[] { "FinishedAt", "Status" },
                values: new object[] { null, 4 });
        }
    }
}
