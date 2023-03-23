using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class UserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "artistMedium",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "quote",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 23, 17, 4, 56, 320, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 23, 17, 4, 56, 320, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 3, 23, 17, 4, 56, 320, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 3, 23, 17, 4, 56, 320, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 3, 23, 17, 4, 56, 320, DateTimeKind.Local).AddTicks(6656));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "artistMedium",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "quote",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 23, 0, 32, 44, 751, DateTimeKind.Local).AddTicks(4253));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 23, 0, 32, 44, 751, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 3, 23, 0, 32, 44, 751, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 3, 23, 0, 32, 44, 751, DateTimeKind.Local).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 3, 23, 0, 32, 44, 751, DateTimeKind.Local).AddTicks(4292));
        }
    }
}
