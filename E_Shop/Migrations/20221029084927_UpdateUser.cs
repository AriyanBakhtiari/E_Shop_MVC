using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Shop.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "RegisterDate" },
                values: new object[] { "admin@admin.com", new DateTime(2022, 10, 29, 12, 19, 27, 419, DateTimeKind.Local).AddTicks(5174) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "RegisterDate" },
                values: new object[] { "admin", new DateTime(2022, 10, 29, 12, 17, 6, 473, DateTimeKind.Local).AddTicks(3799) });
        }
    }
}
