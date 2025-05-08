namespace DiaryUniverse.Infrastructure.Data.Models;

public class BaseUserEntity : BaseEntity
{
    public User User { get; set; }
    public Guid UserId { get; set; }
}