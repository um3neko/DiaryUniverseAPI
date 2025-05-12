using DiaryUniverse.Infrastructure.Data.Models;

namespace DiaryUniverse.Application.DTOs.Constellation;

public class AddConstellationDto
{
    public string? Name { get; set; }
    public User? User { get; set; }
}