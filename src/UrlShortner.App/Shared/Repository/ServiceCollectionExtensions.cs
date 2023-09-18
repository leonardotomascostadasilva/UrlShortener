using Microsoft.Extensions.DependencyInjection.Extensions;
using UrlShortner.App.Shared.Repository.Interfaces;

namespace UrlShortner.App.Shared.Repository;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.TryAddScoped<IRepository, Repository>();
        services.Decorate<IRepository, MemoryCacheRepository>();
        return services;
    }
}
