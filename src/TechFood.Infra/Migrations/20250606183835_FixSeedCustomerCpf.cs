using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFood.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedCustomerCpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("25b58f54-63bc-42da-8cf6-8162097e72c8"),
                column: "DocumentValue",
                value: "63585272070");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("9887b301-605f-46a6-93db-ac1ce8685723"),
                column: "DocumentValue",
                value: "18032939008");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("25b58f54-63bc-42da-8cf6-8162097e72c8"),
                column: "DocumentValue",
                value: "4511554544");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("9887b301-605f-46a6-93db-ac1ce8685723"),
                column: "DocumentValue",
                value: "000000000191");
        }
    }
}
