using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kirtland_Artist_Guild.Models
{
    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Art> Arts { get; set; }
        public DbSet<ArtImage> ArtImages { get; set; }
        public DbSet<ArtistImage> ArtistImages { get; set; }

        public DbSet<ArtStyle> ArtStyles { get; set; }
        public DbSet<ArtColor> ArtColors { get; set; }
        public DbSet<ArtMedium> ArtMediums { get; set; }

        public DbSet<ArtStyleLink> ArtStyleLinks { get; set; }
        public DbSet<ArtColorLink> ArtColorLinks { get; set; }
        public DbSet<ArtMediumLink> ArtMediumLinks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Manually configure many-to-many relationships
            modelBuilder.Entity<ArtMediumLink>().HasKey(l => new { l.ArtID, l.ArtMediumID }); // Composite primary key for ArtMediumLink
            modelBuilder.Entity<ArtMediumLink>().HasOne(l => l.Art).WithMany(a => a.ArtMediumLinks).HasForeignKey(l => l.ArtID); // One-to-many relationship between Art and ArtMediumLink.
            modelBuilder.Entity<ArtMediumLink>().HasOne(l => l.ArtMedium).WithMany(m => m.ArtMediumLinks).HasForeignKey(l => l.ArtMediumID); // One-to-many relationship between ArtMedium and ArtMediumLink. 

            modelBuilder.Entity<ArtColorLink>().HasKey(l => new { l.ArtID, l.ArtColorID }); // Composite primary key for ArtColorLink
            modelBuilder.Entity<ArtColorLink>().HasOne(l => l.Art).WithMany(a => a.ArtColorLinks).HasForeignKey(l => l.ArtID); // One-to-many relationship between Art and ArtColorLink.
            modelBuilder.Entity<ArtColorLink>().HasOne(l => l.ArtColor).WithMany(c => c.ArtColorLinks).HasForeignKey(l => l.ArtColorID); // One-to-many relationship between ArtColor and ArtColorLink.

            modelBuilder.Entity<ArtStyleLink>().HasKey(l => new { l.ArtID, l.ArtStyleID }); // Composite primary key for ArtStyleLink
            modelBuilder.Entity<ArtStyleLink>().HasOne(l => l.Art).WithMany(a => a.ArtStyleLinks).HasForeignKey(l => l.ArtID); // One-to-many relationship between Art and ArtStyleLink.
            modelBuilder.Entity<ArtStyleLink>().HasOne(l => l.ArtStyle).WithMany(s => s.ArtStyleLinks).HasForeignKey(l => l.ArtStyleID); // One-to-many relationship between ArtStyle and ArtStyleLink.

            // Seed Data, move this to seperate file
            modelBuilder.Entity<ArtMedium>().HasData(
                new ArtMedium { ID = 1, Name = "Oil" },
                new ArtMedium { ID = 2, Name = "Watercolor" },
                new ArtMedium { ID = 3, Name = "Graphite" },
                new ArtMedium { ID = 4, Name = "Sculpture" },
                new ArtMedium { ID = 5, Name = "Photography" },
                new ArtMedium { ID = 6, Name = "Colored Pencil" },
                new ArtMedium { ID = 7, Name = "Mixed Media" }
                );

            modelBuilder.Entity<ArtColor>().HasData(
                new ArtColor { ID = 1, Name = "Black & White" },
                new ArtColor { ID = 2, Name = "Bright Colors" },
                new ArtColor { ID = 3, Name = "Pastels" },
                new ArtColor { ID = 4, Name = "Cool Tones" },
                new ArtColor { ID = 5, Name = "Warm Tones" }
                );

            modelBuilder.Entity<ArtStyle>().HasData(
                new ArtStyle { ID = 1, Name = "Realism" },
                new ArtStyle { ID = 2, Name = "Abstract" },
                new ArtStyle { ID = 3, Name = "Impressionism" },
                new ArtStyle { ID = 4, Name = "Conceptual Illustration" },
                new ArtStyle { ID = 5, Name = "Expression" },
                new ArtStyle { ID = 6, Name = "Digital" },
                new ArtStyle { ID = 7, Name = "Still Life" },
                new ArtStyle { ID = 8, Name = "Floral" },
                new ArtStyle { ID = 9, Name = "Landscape" }
                );

            /*modelBuilder.Entity<Art>().HasData(
                new Art { ID = 1, Name = "Grandpas Lake", Description = "Prints only", Available = true, Price = 119.99 },
                new Art { ID = 2, Name = "Wind Dancer", Description = "Prints and note cards. I have raised horses for over 30 years. When I finished this piece, I realized that I had rendered in this portrait a small part of each horse and pony I have raised.  I feel that this is a compilation of the beautiful souls of all my beloved horses.  ", Available = true, Price = 1115.99 },
                new Art { ID = 3, Name = "Mackinac Horses", Description = "Prints and notecards", Available = true, Price = 499.99 },
                new Art { ID = 4, Name = "Wedding Dress", Description = "Prints and notecards. The wood duck, its scientific name, Aix sponsa, can be loosely translated as \"a waterfowl in wedding dress\".  For good reason, its rich greens, blues and purples make it one of the most beautiful of all ducks in North America.  This duck was an absolute joy to work on!  I loved studying his behavior, habitat, courtship and of course his amazing color pattern to achieve my piece.  Although this was the first wood duck that I have done, my love of working with brilliant colors will have me drawing more of this stunning creature. ", Available = true, Price = 199.99 },
                new Art { ID = 5, Name = "Frost on a Dahlia", Description = "Prints and notecards", Available = false, Price = 219.99}
                );

            modelBuilder.Entity<ArtImage>().HasData(
                new ArtImage { ID = 1, ArtID = 1, FileName = "Grandpas Lake.jpg", Source = "/uploads/" },
                new ArtImage { ID = 2, ArtID = 2, FileName = "Wind Dancer.jpg", Source = "/uploads/" },
                new ArtImage { ID = 3, ArtID = 3, FileName = "Mackinac horses Peters.jpg", Source = "/uploads/" },
                new ArtImage { ID = 4, ArtID = 4, FileName = "Wedding Dress.jpg", Source = "/uploads/" },
                new ArtImage { ID = 5, ArtID = 5, FileName = "Frost on a Dahlia.jpg", Source = "/uploads/" }
                );

            modelBuilder.Entity<ArtMediumLink>().HasData(
                new ArtMediumLink { ArtID = 1, ArtMediumID = 1 },
                new ArtMediumLink { ArtID = 2, ArtMediumID = 1 },
                new ArtMediumLink { ArtID = 3, ArtMediumID = 3 },
                new ArtMediumLink { ArtID = 3, ArtMediumID = 2 },
                new ArtMediumLink { ArtID = 4, ArtMediumID = 6 },
                new ArtMediumLink { ArtID = 5, ArtMediumID = 1 }
                );

            modelBuilder.Entity<ArtColorLink>().HasData(
                new ArtColorLink { ArtID = 1, ArtColorID = 2 },
                new ArtColorLink { ArtID = 2, ArtColorID = 4 },
                new ArtColorLink { ArtID = 3, ArtColorID = 1 },
                new ArtColorLink { ArtID = 4, ArtColorID = 5 },
                new ArtColorLink { ArtID = 5, ArtColorID = 2 }
                );

            modelBuilder.Entity<ArtStyleLink>().HasData(
                new ArtStyleLink { ArtID = 1, ArtStyleID = 9 },
                new ArtStyleLink { ArtID = 2, ArtStyleID = 1 },
                new ArtStyleLink { ArtID = 3, ArtStyleID = 1 },
                new ArtStyleLink { ArtID = 4, ArtStyleID = 1 },
                new ArtStyleLink { ArtID = 5, ArtStyleID = 8 }
                );*/
        }
    }
}
