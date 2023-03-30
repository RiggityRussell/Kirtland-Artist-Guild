﻿// <auto-generated />
using System;
using Kirtland_Artist_Guild.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kirtland_Artist_Guild.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230329003138_ArtistImages")]
    partial class ArtistImages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.Art", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Shipping")
                        .HasColumnType("float");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Arts");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Available = true,
                            Created = new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7853),
                            Description = "Prints only",
                            Name = "Grandpas Lake",
                            Price = 119.98999999999999,
                            Shipping = 3.5
                        },
                        new
                        {
                            ID = 2,
                            Available = true,
                            Created = new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7887),
                            Description = "Prints and note cards. I have raised horses for over 30 years. When I finished this piece, I realized that I had rendered in this portrait a small part of each horse and pony I have raised.  I feel that this is a compilation of the beautiful souls of all my beloved horses.  ",
                            Name = "Wind Dancer",
                            Price = 1115.99,
                            Shipping = 53.5
                        },
                        new
                        {
                            ID = 3,
                            Available = true,
                            Created = new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7890),
                            Description = "Prints and notecards",
                            Name = "Mackinac Horses",
                            Price = 499.99000000000001,
                            Shipping = 9.9900000000000002
                        },
                        new
                        {
                            ID = 4,
                            Available = true,
                            Created = new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7892),
                            Description = "Prints and notecards. The wood duck, its scientific name, Aix sponsa, can be loosely translated as \"a waterfowl in wedding dress\".  For good reason, its rich greens, blues and purples make it one of the most beautiful of all ducks in North America.  This duck was an absolute joy to work on!  I loved studying his behavior, habitat, courtship and of course his amazing color pattern to achieve my piece.  Although this was the first wood duck that I have done, my love of working with brilliant colors will have me drawing more of this stunning creature. ",
                            Name = "Wedding Dress",
                            Price = 199.99000000000001,
                            Shipping = 9.9900000000000002
                        },
                        new
                        {
                            ID = 5,
                            Available = false,
                            Created = new DateTime(2023, 3, 28, 20, 31, 37, 946, DateTimeKind.Local).AddTicks(7895),
                            Description = "Prints and notecards",
                            Name = "Frost on a Dahlia",
                            Price = 219.99000000000001,
                            Shipping = 0.0
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtColor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ArtColors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Black & White"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Bright Colors"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Pastels"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Cool Tones"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Warm Tones"
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtColorLink", b =>
                {
                    b.Property<int>("ArtID")
                        .HasColumnType("int");

                    b.Property<int>("ArtColorID")
                        .HasColumnType("int");

                    b.HasKey("ArtID", "ArtColorID");

                    b.HasIndex("ArtColorID");

                    b.ToTable("ArtColorLinks");

                    b.HasData(
                        new
                        {
                            ArtID = 1,
                            ArtColorID = 2
                        },
                        new
                        {
                            ArtID = 2,
                            ArtColorID = 4
                        },
                        new
                        {
                            ArtID = 3,
                            ArtColorID = 1
                        },
                        new
                        {
                            ArtID = 4,
                            ArtColorID = 5
                        },
                        new
                        {
                            ArtID = 5,
                            ArtColorID = 2
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ArtID")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ArtID");

                    b.ToTable("ArtImages");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ArtID = 1,
                            FileName = "Grandpas Lake.jpg",
                            Source = "/uploads/"
                        },
                        new
                        {
                            ID = 2,
                            ArtID = 2,
                            FileName = "Wind Dancer.jpg",
                            Source = "/uploads/"
                        },
                        new
                        {
                            ID = 3,
                            ArtID = 3,
                            FileName = "Mackinac horses Peters.jpg",
                            Source = "/uploads/"
                        },
                        new
                        {
                            ID = 4,
                            ArtID = 4,
                            FileName = "Wedding Dress.jpg",
                            Source = "/uploads/"
                        },
                        new
                        {
                            ID = 5,
                            ArtID = 5,
                            FileName = "Frost on a Dahlia.jpg",
                            Source = "/uploads/"
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtistImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("ArtistImages");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtMedium", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ArtMediums");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Oil"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Watercolor"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Graphite"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Sculpture"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Photography"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Colored Pencil"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Mixed Media"
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtMediumLink", b =>
                {
                    b.Property<int>("ArtID")
                        .HasColumnType("int");

                    b.Property<int>("ArtMediumID")
                        .HasColumnType("int");

                    b.HasKey("ArtID", "ArtMediumID");

                    b.HasIndex("ArtMediumID");

                    b.ToTable("ArtMediumLinks");

                    b.HasData(
                        new
                        {
                            ArtID = 1,
                            ArtMediumID = 1
                        },
                        new
                        {
                            ArtID = 2,
                            ArtMediumID = 1
                        },
                        new
                        {
                            ArtID = 3,
                            ArtMediumID = 3
                        },
                        new
                        {
                            ArtID = 3,
                            ArtMediumID = 2
                        },
                        new
                        {
                            ArtID = 4,
                            ArtMediumID = 6
                        },
                        new
                        {
                            ArtID = 5,
                            ArtMediumID = 1
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtStyle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ArtStyles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Realism"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Abstract"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Impressionism"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Conceptual Illustration"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Expression"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Digital"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Still Life"
                        },
                        new
                        {
                            ID = 8,
                            Name = "Floral"
                        },
                        new
                        {
                            ID = 9,
                            Name = "Landscape"
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtStyleLink", b =>
                {
                    b.Property<int>("ArtID")
                        .HasColumnType("int");

                    b.Property<int>("ArtStyleID")
                        .HasColumnType("int");

                    b.HasKey("ArtID", "ArtStyleID");

                    b.HasIndex("ArtStyleID");

                    b.ToTable("ArtStyleLinks");

                    b.HasData(
                        new
                        {
                            ArtID = 1,
                            ArtStyleID = 9
                        },
                        new
                        {
                            ArtID = 2,
                            ArtStyleID = 1
                        },
                        new
                        {
                            ArtID = 3,
                            ArtStyleID = 1
                        },
                        new
                        {
                            ArtID = 4,
                            ArtStyleID = 1
                        },
                        new
                        {
                            ArtID = 5,
                            ArtStyleID = 8
                        });
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("artistMedium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quote")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.Art", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.User", "User")
                        .WithMany("Art")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtColorLink", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.ArtColor", "ArtColor")
                        .WithMany("ArtColorLinks")
                        .HasForeignKey("ArtColorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Kirtland_Artist_Guild.Models.Art", "Art")
                        .WithMany("ArtColorLinks")
                        .HasForeignKey("ArtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("ArtColor");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtImage", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.Art", "Art")
                        .WithMany("ArtImages")
                        .HasForeignKey("ArtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Art");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtistImage", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.User", "User")
                        .WithMany("ArtistImages")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtMediumLink", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.Art", "Art")
                        .WithMany("ArtMediumLinks")
                        .HasForeignKey("ArtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kirtland_Artist_Guild.Models.ArtMedium", "ArtMedium")
                        .WithMany("ArtMediumLinks")
                        .HasForeignKey("ArtMediumID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("ArtMedium");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtStyleLink", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.Art", "Art")
                        .WithMany("ArtStyleLinks")
                        .HasForeignKey("ArtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kirtland_Artist_Guild.Models.ArtStyle", "ArtStyle")
                        .WithMany("ArtStyleLinks")
                        .HasForeignKey("ArtStyleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Art");

                    b.Navigation("ArtStyle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kirtland_Artist_Guild.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Kirtland_Artist_Guild.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.Art", b =>
                {
                    b.Navigation("ArtColorLinks");

                    b.Navigation("ArtImages");

                    b.Navigation("ArtMediumLinks");

                    b.Navigation("ArtStyleLinks");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtColor", b =>
                {
                    b.Navigation("ArtColorLinks");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtMedium", b =>
                {
                    b.Navigation("ArtMediumLinks");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.ArtStyle", b =>
                {
                    b.Navigation("ArtStyleLinks");
                });

            modelBuilder.Entity("Kirtland_Artist_Guild.Models.User", b =>
                {
                    b.Navigation("Art");

                    b.Navigation("ArtistImages");
                });
#pragma warning restore 612, 618
        }
    }
}
