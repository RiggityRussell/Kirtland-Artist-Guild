using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Kirtland_Artist_Guild.Models
{
    public class Art
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required]
        public bool Available { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public double Price { get; set; }

        public double Shipping { get; set; }
        
        // Navigation property for one-to-many relationship
        public ICollection<ArtImage> ArtImages { get; set; }

        // Navigation properties to linking entities for many-to-many relationship
        public ICollection<ArtMediumLink> ArtMediumLinks { get; set; }
        public ICollection<ArtColorLink> ArtColorLinks { get; set; }
        public ICollection<ArtStyleLink> ArtStyleLinks { get; set; }
    }
}
