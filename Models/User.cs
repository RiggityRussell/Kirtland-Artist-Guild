using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kirtland_Artist_Guild.Models
{
    public class User : IdentityUser
    {
        // Inherits all IdentifyUser properties

        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}
