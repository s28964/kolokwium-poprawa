namespace WebApplication1.DTOs;

public class AddNewExhibitionDto
{
    public string Title { get; set; } = null!;
    public string Gallery { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Artwork> Artworks { get; set; } = null!;
}

public class Artwork
{
    public int ArtworkId { get; set; }
    public decimal InsuranceValue { get; set; }
}