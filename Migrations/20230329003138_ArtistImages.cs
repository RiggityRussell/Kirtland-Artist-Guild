using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class ArtistImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArtistImages_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "Arts",
                keyColumn: "ID",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.CreateIndex(
                name: "IX_ArtistImages_UserID",
                table: "ArtistImages",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistImages");

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
    }
}
