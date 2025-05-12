using DiaryUniverse.Application;
using DiaryUniverse.Application.DTOs.BaseResponse;
using DiaryUniverse.Application.DTOs.Constellation;
using DiaryUniverse.Application.Services.Interfaces;
using DiaryUniverse.Infrastructure.Data.Models;
using DiaryUniverse.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DiaryUniverse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ConstellationController(IConstellationService constellationServic)
    : ControllerBase
{
    private readonly IConstellationService _service = constellationServic;
    
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetConstellations(Guid id)
    {
        var response = await _service.GetConstellationById(id).ConfigureAwait(false);
        return response.ToActionResult(); // через твой extension method
    }
    
    [HttpPost, Route("Add")]
    public async Task<IActionResult>  AddConstellation([FromBody] AddConstellationDto dto)
    {
        var response = await _service.CreateConstellation(dto).ConfigureAwait(false);
        return response.ToActionResult();
    }
    
    
}