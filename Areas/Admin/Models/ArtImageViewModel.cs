namespace Kirtland_Artist_Guild.Models
{
    public class ArtImageViewModel
    {
        public int ArtID { get; set; }
        public string FileName { get; set; }
        public string Source { get; set; }
        public IFormFile ArtImage { get; set; }
    }
}
