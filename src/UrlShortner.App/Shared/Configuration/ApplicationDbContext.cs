using Microsoft.EntityFrameworkCore;
using UrlShortner.App.UseCases.UrlShortner.Entities;
namespace UrlShortner.App.Shared.Configuration;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShortenedUrl>(builder =>
        {
            builder.HasIndex(s => s.Code).IsUnique();
        });
    }
}