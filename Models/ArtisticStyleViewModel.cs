namespace Kirtland_Artist_Guild.Models
{
    public class ArtisticStyleViewModel
    {
        public List<ArtColor> ArtColors { get; set; } = new List<ArtColor>();
        public List<ArtMedium> ArtMediums { get; set; } = new List<ArtMedium>();
        public List<ArtStyle> ArtStyles { get; set; } = new List<ArtStyle>();

        public List<Art> Arts { get; set; } = new List<Art>();
        public List<ArtImage> ArtImages { get; set; } = new List<ArtImage>();
    }
}