using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Gallery> Galleries { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new List<Artist>()
        {
            new Artist() 
            { ArtistId = 1, FirstName = "John", LastName = "Slow", BirthDate = DateTime.Parse("1989-06-07") },
            new Artist() 
            { ArtistId = 2, FirstName = "Jenna", LastName = "Green", BirthDate = DateTime.Parse("1994-04-19") },
        new Artist() 
            { ArtistId = 3, FirstName = "Michael", LastName = "Blue", BirthDate = DateTime.Parse("1978-03-13") },
            
        });

        modelBuilder.Entity<Artwork>().HasData(new List<Artwork>()
        {
            new Artwork() { ArtistId = 1, ArtworkId = 1, Title = "Artwork1", YearCreated = 2022 },
            new Artwork() { ArtistId = 2, ArtworkId = 2, Title = "Artwork2", YearCreated = 2019 },
            new Artwork() { ArtistId = 3, ArtworkId = 3, Title = "Artwork3", YearCreated = 2015 }
            
        });

        modelBuilder.Entity<Gallery>().HasData(new List<Gallery>()
        {
            new Gallery()
                { GalleryId = 1, Name= "Gallery1", EstablishmentDate = DateTime.Parse("1968-04-19")},
            new Gallery()
                { GalleryId = 2, Name= "Gallery2", EstablishmentDate = DateTime.Parse("1976-06-19")},
            new Gallery()
                { GalleryId = 3, Name= "Gallery3", EstablishmentDate = DateTime.Parse("1991-08-19")}
           
        });

        modelBuilder.Entity<Exhibition>().HasData(new List<Exhibition>()
        {
            new Exhibition() { ExhibitionId = 1, GalleryId = 1, Title = "Exhibition1", StartDate = DateTime.Parse("2025-07-17"), EndDate = DateTime.Parse("2025-07-30"), NumberOfArtworks = 5},
            new Exhibition() { ExhibitionId = 2, GalleryId = 2, Title = "Exhibition2", StartDate = DateTime.Parse("2025-06-20"), EndDate = DateTime.Parse("2025-06-25"), NumberOfArtworks = 10},
            new Exhibition() { ExhibitionId = 3, GalleryId = 3, Title = "Exhibition3", StartDate = DateTime.Parse("2025-05-10"), EndDate = DateTime.Parse("2025-05-18"), NumberOfArtworks = 15}
            
            
        });

        modelBuilder.Entity<ExhibitionArtwork>().HasData(new List<ExhibitionArtwork>()
        {
            new ExhibitionArtwork() { ExhibitionId = 1, ArtworkId = 1, InsuranceValue = 10000},
            new ExhibitionArtwork() { ExhibitionId = 2, ArtworkId = 2, InsuranceValue = 20000},
            new ExhibitionArtwork() { ExhibitionId = 3, ArtworkId = 3, InsuranceValue = 30000}
           
           
        });
    }
}