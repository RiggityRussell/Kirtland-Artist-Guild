using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class ProfileField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "paypal",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "website",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paypal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "website",
                table: "AspNetUsers");
        }
    }
}
