using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GalleriesController : ControllerBase
{
    private readonly IDbService _dbService;

    public GalleriesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{galleryId}/exhibitions")]
    public async Task<IActionResult> GetGalleryAndExhibition(int galleryId)
    {
        try
        {
            var order = await _dbService.GetGalleryAndExhibitionInformation(galleryId);
            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}