using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kirtland_Artist_Guild.Models
{
    public class User : IdentityUser
    {
        // Inherits all IdentityUser properties

        [NotMapped]
        public IList<string> RoleNames { get; set; } = new List<string>();

        [DataType(DataType.Text)]
        public string? firstName { get; set; }

        [DataType(DataType.Text)]
        public string? lastName { get; set; }

        [DataType(DataType.Text)]
        public string? artistMedium { get; set; }

        [DataType(DataType.Text)]
        public string? quote { get; set; }

        [DataType(DataType.Text)]
        public string? bio { get; set; }

        public ICollection<Art>? Art { get; set; } // Navigation property for one-to-many relationship
        public ICollection<ArtistImage>? ArtistImages { get; set; } // Navigation property for one-to-many relationship

    }
}
