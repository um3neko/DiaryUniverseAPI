using DiaryUniverse.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryUniverse.Infrastructure.Data;

public class DiaryUniverseContext : DbContext
{
    public DiaryUniverseContext(DbContextOptions<DiaryUniverseContext> options) : base(options) { }
    public DbSet<Star> Stars => Set<Star>();
    public DbSet<Constellation> Constellations => Set<Constellation>();

}