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

        public DbSet<Exhibition> Exhibitions { get; set; }


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
                new ArtMedium { ID = 7, Name = "Mixed Media" },
                new ArtMedium { ID = 8, Name = "Charcoal" }
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
                new ArtStyle { ID = 5, Name = "Expressionism" },
                new ArtStyle { ID = 6, Name = "Digital/Photograph" },
                new ArtStyle { ID = 7, Name = "Still Life" },
                new ArtStyle { ID = 8, Name = "Floral" },
                new ArtStyle { ID = 9, Name = "Landscape/Architectural" },
                new ArtStyle { ID = 10, Name = "Portraits/Figurative" },
                new ArtStyle { ID = 11, Name = "Wildlife/Domesticated Animals" }
                );
        }
    }
}
