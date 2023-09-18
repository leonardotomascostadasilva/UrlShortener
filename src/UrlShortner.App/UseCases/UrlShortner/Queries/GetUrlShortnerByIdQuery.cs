using MediatR;

namespace UrlShortner.App.UseCases.UrlShortner.Queries;
public sealed class GetUrlShortnerByIdQuery : IRequest<string>
{
    public string Code { get; set; }

    public GetUrlShortnerByIdQuery(string code)
    {
        Code = code;
    }
}
