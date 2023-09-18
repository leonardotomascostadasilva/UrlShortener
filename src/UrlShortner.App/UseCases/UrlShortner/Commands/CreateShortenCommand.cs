using MediatR;
using UrlShortner.App.UseCases.UrlShortner.Contracts;

namespace UrlShortner.App.UseCases.UrlShortner.Commands;
public sealed class CreateShortenCommand : IRequest<string>
{
    public string LongUrl { get; }
    public string Scheme { get; set; }
    public string Host { get; set; }

    public CreateShortenCommand(ShortenUrlRequest request, string scheme, string host)
    {
        LongUrl = request.Url;
        Scheme = scheme;
        Host = host;
    }
}
