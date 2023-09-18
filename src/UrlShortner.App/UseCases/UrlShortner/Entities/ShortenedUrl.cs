using UrlShortner.App.Shared.Repository.Entities;

namespace UrlShortner.App.UseCases.UrlShortner.Entities;

public sealed class ShortenedUrl : Entity
{
    public string Id { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortUrl { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime CreatedOnUtc { get; set; }


    public static implicit operator ShortenedUrl(ShortenedUrlDto shortenedUrlDto)
    => new ShortenedUrl()
    {
        Id = shortenedUrlDto.Id,
        Code = shortenedUrlDto.Code,
        CreatedOnUtc = shortenedUrlDto.CreatedOnUtc,
        LongUrl = shortenedUrlDto.LongUrl,
        ShortUrl = shortenedUrlDto.ShortUrl
    };

}
