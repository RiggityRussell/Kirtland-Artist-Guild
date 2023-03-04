using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Arts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 3, 20, 14, 26, 37, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 3, 20, 14, 26, 37, DateTimeKind.Local).AddTicks(6525));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Arts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 3, 19, 59, 3, 226, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 3, 19, 59, 3, 226, DateTimeKind.Local).AddTicks(4843));
        }
    }
}
