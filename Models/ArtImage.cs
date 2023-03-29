using System.ComponentModel.DataAnnotations;

namespace Kirtland_Artist_Guild.Models
{
    public class ArtImage
    {
        public int ID { get; set; }

        [Required]
        public int ArtID { get; set; } // Foreign key property for one-to-many 
        public Art? Art { get; set; } // Navigation property for one-to-many

        [Required]
        public string FileName { get; set; } = string.Empty;

        [Required]
        public string Source { get; set; } = string.Empty;

    }
}