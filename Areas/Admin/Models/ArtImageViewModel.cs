namespace Kirtland_Artist_Guild.Models
{
    public class ArtImageViewModel
    {
        public int ArtID { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public IFormFile ArtImage { get; set; } = default!;
    }
}
