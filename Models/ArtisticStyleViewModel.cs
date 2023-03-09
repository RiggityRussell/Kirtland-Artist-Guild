namespace Kirtland_Artist_Guild.Models
{
    public class ArtisticStyleViewModel
    {
        public List<ArtColor> ArtColors { get; set; }
        public List<ArtMedium> ArtMediums { get; set; }
        public List<ArtStyle> ArtStyles { get; set; }


        public List<Art> Arts { get; set; }
        public List<ArtImage> ArtImages { get; set; }
    }
}
