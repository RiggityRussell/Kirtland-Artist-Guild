namespace Kirtland_Artist_Guild.Models
{
    public class ArtMediumLink
    {
        // Composite primary key
        public int ArtID { get; set; } // Foreign key for Art
        public int ArtMediumID { get; set; } // Foreign key for ArtMedium

        // Navigation properties
        public Art Art { get; set; }
        public ArtMedium ArtMedium { get; set; }
    }
}
