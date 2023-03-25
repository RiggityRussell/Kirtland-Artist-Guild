using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artistMedium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Shipping = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Arts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, true, new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6361), "Prints only", "Grandpas Lake", 119.98999999999999, 3.5, null },
                    { 2, true, new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6395), "Prints and note cards. I have raised horses for over 30 years. When I finished this piece, I realized that I had rendered in this portrait a small part of each horse and pony I have raised.  I feel that this is a compilation of the beautiful souls of all my beloved horses.  ", "Wind Dancer", 1115.99, 53.5, null },
                    { 3, true, new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6398), "Prints and notecards", "Mackinac Horses", 499.99000000000001, 9.9900000000000002, null },
                    { 4, true, new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6400), "Prints and notecards. The wood duck, its scientific name, Aix sponsa, can be loosely translated as \"a waterfowl in wedding dress\".  For good reason, its rich greens, blues and purples make it one of the most beautiful of all ducks in North America.  This duck was an absolute joy to work on!  I loved studying his behavior, habitat, courtship and of course his amazing color pattern to achieve my piece.  Although this was the first wood duck that I have done, my love of working with brilliant colors will have me drawing more of this stunning creature. ", "Wedding Dress", 199.99000000000001, 9.9900000000000002, null },
                    { 5, false, new DateTime(2023, 3, 25, 0, 32, 22, 124, DateTimeKind.Local).AddTicks(6402), "Prints and notecards", "Frost on a Dahlia", 219.99000000000001, 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "ArtColorLinks",
                columns: new[] { "ArtColorID", "ArtID" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 2 },
                    { 1, 3 },
                    { 5, 4 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "ArtImages",
                columns: new[] { "ID", "ArtID", "FileName", "Source" },
                values: new object[,]
                {
                    { 1, 1, "Grandpas Lake.jpg", "/uploads/" },
                    { 2, 2, "Wind Dancer.jpg", "/uploads/" },
                    { 3, 3, "Mackinac horses Peters.jpg", "/uploads/" },
                    { 4, 4, "Wedding Dress.jpg", "/uploads/" },
                    { 5, 5, "Frost on a Dahlia.jpg", "/uploads/" }
                });

            migrationBuilder.InsertData(
                table: "ArtMediumLinks",
                columns: new[] { "ArtID", "ArtMediumID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 6 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "ArtStyleLinks",
                columns: new[] { "ArtID", "ArtStyleID" },
                values: new object[,]
                {
                    { 1, 9 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 8 }
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
                name: "IX_Arts_UserID",
                table: "Arts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ArtStyleLinks_ArtStyleID",
                table: "ArtStyleLinks",
                column: "ArtStyleID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ArtColors");

            migrationBuilder.DropTable(
                name: "ArtMediums");

            migrationBuilder.DropTable(
                name: "Arts");

            migrationBuilder.DropTable(
                name: "ArtStyles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
