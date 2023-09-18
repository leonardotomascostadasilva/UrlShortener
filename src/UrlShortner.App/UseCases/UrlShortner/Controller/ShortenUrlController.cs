using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UrlShortner.App.UseCases.UrlShortner.Commands;
using UrlShortner.App.UseCases.UrlShortner.Contracts;
using UrlShortner.App.UseCases.UrlShortner.Queries;

namespace UrlShortner.App.UseCases.UrlShortner.Controller;
public sealed class ShortenUrlController : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/shorten");

        group.MapPost("",CreateShortenUrlAsync).WithName(nameof(CreateShortenUrlAsync));

        group.MapGet("{code}", RedirectUrlAsync).WithName(nameof(RedirectUrlAsync));
    }


    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IResult> CreateShortenUrlAsync(ShortenUrlRequest request, IMediator _mediator, HttpContext _httpContext, CancellationToken cancellationToken)
    {
        if (!Uri.TryCreate(request.Url, UriKind.Absolute, out _))
        {
            return Results.BadRequest("The specified URL is invalid");
        }

        var shortUrl = await _mediator.Send(new CreateShortenCommand(request, _httpContext.Request.Scheme, _httpContext.Request.Host.Value), cancellationToken);

        return Results.Ok(shortUrl);
    }

    public async Task<IResult> RedirectUrlAsync(string code, IMediator _mediator, CancellationToken cancellationToken)
    {
        var longUrl = await _mediator.Send(new GetUrlShortnerByIdQuery(code), cancellationToken); 

        if (longUrl is null)
        {
            return Results.NotFound();
        }

        return Results.Redirect(longUrl);
    }
}
