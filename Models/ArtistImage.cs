using Microsoft.Build.Framework;

namespace Kirtland_Artist_Guild.Models
{
    public class ArtistImage
    {
        public int ID { get; set; }

        [Required]
        public string UserID { get; set; } // Foreign key property for one-to-many 
        public User? User { get; set; } // Navigation property for one-to-many

        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public string Source { get; set; } = string.Empty;


    }
}
