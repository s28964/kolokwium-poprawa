using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/exhibitions")]
public class ExhibitionController : ControllerBase
{
    private readonly IDbService _dbService;

    public ExhibitionController(IDbService dbService)
    {
        _dbService = dbService;
    }
    [HttpPost]
    public async Task<IActionResult> AddExhibition(AddNewExhibitionDto dto)
    {
        try
        {
            await _dbService.AddNewExhibition(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}