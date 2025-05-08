using DiaryUniverse.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryUniverse.Infrastructure.Data;

public class DiaryUniverseContext : DbContext
{
    public DiaryUniverseContext(DbContextOptions<DiaryUniverseContext> options) : base(options) { }
    public DbSet<Star> Start => Set<Star>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}