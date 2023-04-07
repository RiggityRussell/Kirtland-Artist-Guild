namespace Kirtland_Artist_Guild.Models
{
    public class ArtistsViewModel
    {
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<ArtistImage> ArtistImages { get; set; } = null!;
    }
}
