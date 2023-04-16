using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 5, 52, 705, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 5, 52, 705, DateTimeKind.Local).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 5, 52, 705, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 5, 52, 705, DateTimeKind.Local).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 5, 52, 705, DateTimeKind.Local).AddTicks(8771));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 2, 56, 219, DateTimeKind.Local).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 2, 56, 219, DateTimeKind.Local).AddTicks(2601));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 2, 56, 219, DateTimeKind.Local).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 2, 56, 219, DateTimeKind.Local).AddTicks(2606));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 4, 14, 20, 2, 56, 219, DateTimeKind.Local).AddTicks(2609));
        }
    }
}
