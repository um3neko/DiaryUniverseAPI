using DiaryUniverse.Application.Services;
using DiaryUniverse.Application.Services.Interfaces;
using DiaryUniverse.Infrastructure.Data;
using DiaryUniverse.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DiaryUniverse;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<DiaryUniverseContext>(opt => 
            opt.UseNpgsql(builder.Configuration.GetConnectionString("db")));
        
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        //
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        //
        builder.Services.AddScoped<IConstellationService, ConstellationService>();
        //
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        using (var scope = app.Services.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<DiaryUniverseContext>().Database.Migrate();
        }
        
        app.UseHttpsRedirection();
        app.UseAuthorization();
        
        app.MapControllers();
        app.Run();
    }
}