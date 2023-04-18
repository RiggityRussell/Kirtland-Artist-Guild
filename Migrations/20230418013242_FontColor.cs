using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class FontColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fontColor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fontColor",
                table: "AspNetUsers");
        }
    }
}
