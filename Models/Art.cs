using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kirtland_Artist_Guild.Models
{
    public class Art
    {
        public int ID { get; set; }        

        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool Available { get; set; } = false;

        public DateTime Created { get; set; } = DateTime.Now;

        public double Price { get; set; } = 0.00;

        [Required]
        public string UserID { get; set; } // Foreign key for one-to-many relationship

        // Navigation property for one-to-many relationship
        public ICollection<ArtImage>? ArtImages { get; set; }
        public User? User { get; set; }

        // Navigation properties to linking entities for many-to-many relationship
        public ICollection<ArtMediumLink>? ArtMediumLinks { get; set; }
        public ICollection<ArtColorLink>? ArtColorLinks { get; set; }
        public ICollection<ArtStyleLink>? ArtStyleLinks { get; set; }
    }
}
