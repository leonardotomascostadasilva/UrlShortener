namespace UrlShortner.App.UseCases.UrlShortner.Entities;
public sealed class ShortenedUrlDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string LongUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

    public ShortenedUrlDto(string longUrl, string code, string shortUrl)
    {
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        Code = code;
    }
}
