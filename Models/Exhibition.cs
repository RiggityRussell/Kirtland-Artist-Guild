using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kirtland_Artist_Guild.Models
{
    public class Exhibition
    {
        public int ID { get; set; }

        [Required, StringLength(200, ErrorMessage = "Name is too long.")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        public string? FileName { get; set; } = string.Empty;

        public string? Source { get; set; } = string.Empty;
    }
}
