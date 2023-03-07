namespace Kirtland_Artist_Guild.Models
{
    public class ArtColorLink
    {
        // Composite primary key
        public int ArtID { get; set; } // Foreign key for Art
        public int ArtColorID { get; set; } // Foreign key for ArtColor

        // Navigation properties
        public Art Art { get; set; }
        public ArtColor ArtColor { get; set; }
    }
}
