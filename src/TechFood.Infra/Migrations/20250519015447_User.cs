using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechFood.Infra.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameFullName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "varchar(50)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "IsDeleted", "PasswordHash", "Role", "Username", "EmailAddress", "NameFullName" },
                values: new object[] { new Guid("fa09f3a0-f22d-40a8-9cca-0c64e5ed50e4"), false, "AQAAAAIAAYagAAAAEKs0I0Zk5QKKieJTm20PwvTmpkSfnp5BhSl5E35ny8DqffCJA+CiDRnnKRCeOx8+mg==", "admin", "john.admin", "john.admin@techfood.com", "John Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
