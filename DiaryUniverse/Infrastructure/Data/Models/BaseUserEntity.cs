namespace DiaryUniverse.Infrastructure.Data.Models;

public class BaseUserEntity : Entity
{
    public User? User { get; set; }
    public Guid UserId { get; set; }
}