using MediatR;
using UrlShortner.App.Shared.Repository.Interfaces;
using UrlShortner.App.UseCases.UrlShortner.Entities;

namespace UrlShortner.App.UseCases.UrlShortner.Queries;
public sealed class GetUrlShortnerByIdQueryHandler : IRequestHandler<GetUrlShortnerByIdQuery, string>
{
    private readonly IRepository _repository;

    public GetUrlShortnerByIdQueryHandler(IRepository repository) => _repository = repository;

    public async Task<string?> Handle(GetUrlShortnerByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FirstOrDefaultAsync<ShortenedUrl>(s => s.Code == request.Code, request.Code);

        if (entity is null)
        {
            return null;
        }

        return entity.LongUrl;
    }
}
