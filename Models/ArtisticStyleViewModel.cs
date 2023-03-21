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

public class MyViewModel
{
    public int Page { get; set; }
    // Other properties for the view can be added here
}
