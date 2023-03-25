namespace Kirtland_Artist_Guild.Models
{
    public class ArtistViewModel
    {
        public User User { get; set; }
        public List<Art> Arts { get; set; }
        public List<ArtImage> ArtImages { get; set; }
    }
}
