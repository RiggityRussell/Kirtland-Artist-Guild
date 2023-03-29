using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class useraddtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 25, 13, 57, 53, 471, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 25, 13, 57, 53, 471, DateTimeKind.Local).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 3, 25, 13, 57, 53, 471, DateTimeKind.Local).AddTicks(5993));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 3, 25, 13, 57, 53, 471, DateTimeKind.Local).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 3, 25, 13, 57, 53, 471, DateTimeKind.Local).AddTicks(5998));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6395));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6402));
        }
    }
}
