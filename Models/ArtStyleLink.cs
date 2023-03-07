namespace Kirtland_Artist_Guild.Models
{
    public class ArtStyleLink
    {
        // Composite primary key
        public int ArtID { get; set; } // Foreign key for Art
        public int ArtStyleID { get; set; } // Foreign key for ArtStyle

        // Navigation properties
        public Art Art { get; set; }
        public ArtStyle ArtStyle { get; set; }
    }
}
