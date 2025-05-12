namespace DiaryUniverse.Infrastructure.Data.Models;

public class User : Entity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}