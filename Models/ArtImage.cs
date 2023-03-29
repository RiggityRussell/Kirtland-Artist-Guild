namespace Kirtland_Artist_Guild.Models
{
    public class ArtImage
    {
        public int ID { get; set; }

        public int ArtID { get; set; } // Foreign key property for one-to-many 
        public Art? Art { get; set; } // Navigation property for one-to-many

        public string FileName { get; set; }

        public string Source { get; set; }
 
    }

}
