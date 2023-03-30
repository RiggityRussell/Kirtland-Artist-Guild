using System.ComponentModel.DataAnnotations;

namespace Kirtland_Artist_Guild.Models
{
    public class ArtColor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        // Navigation property to linking entity for many-to-many relationship
        public ICollection<ArtColorLink>? ArtColorLinks { get; set; }
    }
}
