using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 8, 18, 48, 44, 305, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 8, 18, 48, 44, 305, DateTimeKind.Local).AddTicks(2656));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 3, 20, 19, 9, 849, DateTimeKind.Local).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 3, 20, 19, 9, 849, DateTimeKind.Local).AddTicks(3938));
        }
    }
}
