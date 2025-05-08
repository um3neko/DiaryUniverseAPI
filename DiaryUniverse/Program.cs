using DiaryUniverse.Infrastructure.Data;
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