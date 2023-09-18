using Microsoft.EntityFrameworkCore;
using UrlShortner.App.Shared.Configuration;

namespace UrlShortner.App.Shared.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}
