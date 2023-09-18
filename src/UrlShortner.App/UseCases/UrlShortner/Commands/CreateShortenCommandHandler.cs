using MediatR;
using NanoidDotNet;
using UrlShortner.App.Shared.Repository.Interfaces;
using UrlShortner.App.UseCases.UrlShortner.Entities;
namespace UrlShortner.App.UseCases.UrlShortner.Commands;
public sealed class CreateShortenCommandHandler : IRequestHandler<CreateShortenCommand, string>
{
    private readonly IRepository _repository;

    public CreateShortenCommandHandler(IRepository repository) => _repository = repository;


    public async Task<string> Handle(CreateShortenCommand request, CancellationToken cancellationToken)
    {
        var code = Nanoid.Generate();

        var shortenedUrl = new ShortenedUrlDto(
            request.LongUrl,
            code,
            shortUrl: $"{request.Scheme}://{request.Host}/api/shorten/{code}");

        await _repository.InsertAsync<ShortenedUrl>(shortenedUrl);

        return shortenedUrl.ShortUrl;
    }
}
