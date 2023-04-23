namespace Kirtland_Artist_Guild.Models
{
    public class ExhibitionImageViewModel
    {
        public Exhibition exhibition { get; set; }
        public IFormFile ExhibitionImage { get; set; } = default!;
    }
}
