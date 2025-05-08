namespace DiaryUniverse.Infrastructure.Data.Models;

public class Constellation : BaseUserEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<Star>? Stars { get; set; }
    //icons
}