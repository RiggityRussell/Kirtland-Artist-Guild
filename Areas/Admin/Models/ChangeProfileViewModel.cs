using System.ComponentModel.DataAnnotations;

namespace Kirtland_Artist_Guild.Models
{
    public class ChangeProfileViewModel
    {
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a first name.")]
        [DataType(DataType.Text)]
        public string firstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        [DataType(DataType.Text)]
        public string lastName { get; set; } = string.Empty;

        public string? quote { get; set; }
        public string? artistMedium { get; set; }
        public string? bio { get; set; }
        public string? backgroundColor { get; set; }
        public string? fontColor { get; set; }
        public string? email { get; set; }
        public string? website { get; set; }
        public string? paypal { get; set; }
    }
}
