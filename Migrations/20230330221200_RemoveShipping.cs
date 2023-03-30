using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class RemoveShipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shipping",
                table: "Arts");

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 30, 18, 12, 0, 355, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 30, 18, 12, 0, 355, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 3, 30, 18, 12, 0, 355, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 3, 30, 18, 12, 0, 355, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 3, 30, 18, 12, 0, 355, DateTimeKind.Local).AddTicks(9172));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Shipping",
                table: "Arts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Created", "Shipping" },
                values: new object[] { new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7853), 3.5 });

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Created", "Shipping" },
                values: new object[] { new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7887), 53.5 });

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Created", "Shipping" },
                values: new object[] { new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7890), 9.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Created", "Shipping" },
                values: new object[] { new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7892), 9.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7895));
        }
    }
}
