namespace Kirtland_Artist_Guild.Models
{
    public class ArtistImage
    {
        public int ID { get; set; }

        public string UserID { get; set; } // Foreign key property for one-to-many 
        public User? User { get; set; } // Navigation property for one-to-many

        public string FileName { get; set; }

        public string Source { get; set; }
    }
}
