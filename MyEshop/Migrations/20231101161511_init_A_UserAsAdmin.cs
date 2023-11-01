using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEshop.Migrations
{
    public partial class init_A_UserAsAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsAdmin", "Password", "RegisterDate" },
                values: new object[] { 1, "stajmir78@gmail.com", true, "123", new DateTime(2023, 11, 1, 19, 45, 11, 200, DateTimeKind.Local).AddTicks(2643) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreateDate", "IsFinaly", "UserId" },
                values: new object[] { 1, new DateTime(2023, 11, 1, 19, 45, 11, 201, DateTimeKind.Local).AddTicks(1477), false, 1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "DetailId", "Count", "OrderId", "Price", "ProductId" },
                values: new object[] { 1, 1, 1, 555m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "DetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
