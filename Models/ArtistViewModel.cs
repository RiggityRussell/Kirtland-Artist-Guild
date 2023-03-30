namespace Kirtland_Artist_Guild.Models
{
    public class ArtistViewModel
    {
        public User User { get; set; } = new User();
        public List<Art> Arts { get; set; } = new List<Art>();
        public List<ArtImage> ArtImages { get; set; } = new List<ArtImage>();
        public List<ArtistImage> ArtistImages { get; set; } = new List<ArtistImage>();
    }
}
