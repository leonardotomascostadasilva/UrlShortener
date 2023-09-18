using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;
using UrlShortner.App.Shared.Repository.Entities;
using UrlShortner.App.Shared.Repository.Interfaces;

namespace UrlShortner.App.Shared.Repository;

public class MemoryCacheRepository : IRepository
{
    private readonly Repository _decorated;
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheRepository(Repository decorated, IMemoryCache memoryCache)
    {
        _decorated = decorated;
        _memoryCache = memoryCache;
    }

    public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : Entity
    {
        string key = $"{predicate}";
        return await _memoryCache.GetOrCreateAsync(
            key,
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(1));

                return _decorated.FirstOrDefaultAsync(predicate);
            });
    }

    public async Task InsertAsync<T>(T entity) where T : Entity
    {
       await _decorated.InsertAsync(entity);
    }
}
