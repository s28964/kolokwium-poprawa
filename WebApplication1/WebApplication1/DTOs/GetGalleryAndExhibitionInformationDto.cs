namespace WebApplication1.DTOs;

public class GetGalleryAndExhibitionInformationDto
{
    public int GalleryId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime EstablishmentDate { get; set; }
    public List<Exhibition> Exhibitions { get; set; } = null!;
}

public class Exhibition
{
    public string Title { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public Artworks Artworks { get; set; } = null!;
}

public class Artworks
{
    public string Title { get; set; } = null!;
    public int YearCreated { get; set; }
    public decimal InsuranceValue { get; set; }
    public Artist Artist { get; set; } = null!;
}

public class Artist
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}