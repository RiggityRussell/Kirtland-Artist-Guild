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

        public string quote { get; set; } = string.Empty;
        public string artistMedium { get; set; } = string.Empty;
        public string bio { get; set; } = string.Empty;
    }
}
