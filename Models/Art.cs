using System.ComponentModel.DataAnnotations;

namespace Kirtland_Artist_Guild.Models
{
    public enum Medium
    {
        Oils,
        Watercolor,
        Graphite,
        Sculpture,
        Photography,
        ColoredPencil,
        MixedMedia,
    }
    public enum Color
    {
        BlackandWhite,
        BrightColors,
        Pastels,
        CoolTones,
        WarmTones
    }
    public enum Technique
    {
        Realism,
        Abstract,
        Impressionism,
        ConceptualIllustration,
        Expression,
        Digital,
        StillLife,
        Floral,
        Landscape
    }
    public class Art
    {
        public int Id { get; set; }

        public int UserId { get; set; }
    }
}
