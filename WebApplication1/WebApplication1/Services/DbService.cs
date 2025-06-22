using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using Exhibition = WebApplication1.DTOs.Exhibition;

namespace WebApplication1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task <GetGalleryAndExhibitionInformationDto> GetGalleryAndExhibitionInformation(int galleryId)
    {
        var gallery = _context.Galleries.Include(e => e.Exhibitions).ThenInclude(ea => ea.ExhibitionArtworks).ThenInclude(a => a.Artwork).ThenInclude(ar => ar.Artist).FirstOrDefault(g => g.GalleryId == galleryId);
        
        if (gallery == null)
        {
            throw new Exception("Gallery does not exist");
        }

        var result = new GetGalleryAndExhibitionInformationDto()
        {
            GalleryId = gallery.GalleryId,
            Name = gallery.Name,
            EstablishmentDate = gallery.EstablishmentDate,
            Exhibitions = gallery.Exhibitions.Select(e => new Exhibition()
            {
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                NumberOfArtworks = e.NumberOfArtworks,
                Artworks = new Artworks()
                {
                    Title = e.Title
                }
            }).ToList()
        };

        return result;
    }

    public async Task AddNewExhibition(AddNewExhibitionDto dto)
    {
        var exhibition = await _context.Exhibitions.FirstOrDefaultAsync(e => e.Title == dto.Title);
    }
}