using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ArtColors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtColors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArtMediums",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMediums", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Arts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Shipping = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArtStyles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtStyles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArtColorLinks",
                columns: table => new
                {
                    ArtID = table.Column<int>(type: "int", nullable: false),
                    ArtColorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtColorLinks", x => new { x.ArtID, x.ArtColorID });
                    table.ForeignKey(
                        name: "FK_ArtColorLinks_ArtColors_ArtColorID",
                        column: x => x.ArtColorID,
                        principalTable: "ArtColors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtColorLinks_Arts_ArtID",
                        column: x => x.ArtID,
                        principalTable: "Arts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtImages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArtImages_Arts_ArtID",
                        column: x => x.ArtID,
                        principalTable: "Arts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtMediumLinks",
                columns: table => new
                {
                    ArtID = table.Column<int>(type: "int", nullable: false),
                    ArtMediumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtMediumLinks", x => new { x.ArtID, x.ArtMediumID });
                    table.ForeignKey(
                        name: "FK_ArtMediumLinks_ArtMediums_ArtMediumID",
                        column: x => x.ArtMediumID,
                        principalTable: "ArtMediums",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtMediumLinks_Arts_ArtID",
                        column: x => x.ArtID,
                        principalTable: "Arts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtStyleLinks",
                columns: table => new
                {
                    ArtID = table.Column<int>(type: "int", nullable: false),
                    ArtStyleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtStyleLinks", x => new { x.ArtID, x.ArtStyleID });
                    table.ForeignKey(
                        name: "FK_ArtStyleLinks_Arts_ArtID",
                        column: x => x.ArtID,
                        principalTable: "Arts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtStyleLinks_ArtStyles_ArtStyleID",
                        column: x => x.ArtStyleID,
                        principalTable: "ArtStyles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ArtColors",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Black & White" },
                    { 2, "Bright Colors" },
                    { 3, "Pastels" },
                    { 4, "Cool Tones" },
                    { 5, "Warm Tones" }
                });

            migrationBuilder.InsertData(
                table: "ArtMediums",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Oil" },
                    { 2, "Watercolor" },
                    { 3, "Graphite" },
                    { 4, "Sculpture" },
                    { 5, "Photography" },
                    { 6, "Colored Pencil" },
                    { 7, "Mixed Media" }
                });

            migrationBuilder.InsertData(
                table: "ArtStyles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Realism" },
                    { 2, "Abstract" },
                    { 3, "Impressionism" },
                    { 4, "Conceptual Illustration" },
                    { 5, "Expression" },
                    { 6, "Digital" },
                    { 7, "Still Life" },
                    { 8, "Floral" },
                    { 9, "Landscape" }
                });

            migrationBuilder.InsertData(
                table: "Arts",
                columns: new[] { "ID", "Available", "Created", "Description", "Name", "Price", "Shipping", "UserID" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 3, 3, 19, 59, 3, 226, DateTimeKind.Local).AddTicks(4807), "Neat photo", "The Last Supper", 9.9900000000000002, 3.5, 1 },
                    { 2, true, new DateTime(2023, 3, 3, 19, 59, 3, 226, DateTimeKind.Local).AddTicks(4843), "Neat photo", "Poker Dogs", 5.9900000000000002, 3.5, 1 }
                });

            migrationBuilder.InsertData(
                table: "ArtColorLinks",
                columns: new[] { "ArtColorID", "ArtID" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ArtImages",
                columns: new[] { "ID", "ArtID", "FileName", "Source" },
                values: new object[,]
                {
                    { 1, 1, "supper_front.jpg", "/uploads/" },
                    { 2, 1, "supper_back.jpg", "/uploads/" },
                    { 3, 2, "dogs.jpg", "/uploads/" }
                });

            migrationBuilder.InsertData(
                table: "ArtMediumLinks",
                columns: new[] { "ArtID", "ArtMediumID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ArtStyleLinks",
                columns: new[] { "ArtID", "ArtStyleID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtColorLinks_ArtColorID",
                table: "ArtColorLinks",
                column: "ArtColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtImages_ArtID",
                table: "ArtImages",
                column: "ArtID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtMediumLinks_ArtMediumID",
                table: "ArtMediumLinks",
                column: "ArtMediumID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtStyleLinks_ArtStyleID",
                table: "ArtStyleLinks",
                column: "ArtStyleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtColorLinks");

            migrationBuilder.DropTable(
                name: "ArtImages");

            migrationBuilder.DropTable(
                name: "ArtMediumLinks");

            migrationBuilder.DropTable(
                name: "ArtStyleLinks");

            migrationBuilder.DropTable(
                name: "ArtColors");

            migrationBuilder.DropTable(
                name: "ArtMediums");

            migrationBuilder.DropTable(
                name: "Arts");

            migrationBuilder.DropTable(
                name: "ArtStyles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
